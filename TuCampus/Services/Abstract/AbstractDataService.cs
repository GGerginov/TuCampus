using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Diagnostics.Eventing.Reader;

namespace DataLayer.Services
{
    public abstract class AbstractDataService<TContext, TEntity> where TContext : DbContext where TEntity : class
    {
        protected readonly TContext _context;

        protected AbstractDataService(TContext context)
        {
            _context = context;
        }

        public List<string> GetAllPropertyNames()
        {
            return typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                  .Select(prop => prop.Name)
                                  .ToList();
        }


        public async Task<List<TEntity>> GetRecordsByFieldAsync(string fieldName, object value)
        {
            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var property = Expression.Property(parameter, fieldName);
            var propertyType = property.Type;

            if (value == null)
            {
                return await _context.Set<TEntity>().ToListAsync();
            }

            if (value is string stringValue && !TryConvertStringValue(stringValue, propertyType, out value))
            {
                throw new ArgumentException($"Cannot convert value to the type {propertyType.Name}.");
            }

            var constant = Expression.Constant(value, propertyType);
            var equals = Expression.Equal(property, constant);
            var lambda = Expression.Lambda<Func<TEntity, bool>>(equals, parameter);

            var results = await _context.Set<TEntity>().Where(lambda).ToListAsync();

            // Check if the field is DateTime and no results found
            if (propertyType == typeof(DateTime) && results.Count == 0)
            {
                var dateValue = (DateTime)value;
                var latestYear = await _context.Set<TEntity>()
                                        .OrderByDescending(x => EF.Property<DateTime>(x, fieldName).Year)
                                        .Select(x => EF.Property<DateTime>(x, fieldName).Year)
                                        .FirstOrDefaultAsync();
                
                if (latestYear != 0 && latestYear < dateValue.Year) // Ensure there's a valid year
                {
              
                    var yearLimit = new DateTime(latestYear,12, 31);

                    var yearPredicate = Expression.LessThanOrEqual(property, Expression.Constant(yearLimit));
                  
                    var yearLambda = Expression.Lambda<Func<TEntity, bool>>(yearPredicate, parameter);

                    results = await _context.Set<TEntity>().Where(yearLambda).ToListAsync();
                }
            }

            return results;
        }

        private async Task<List<TEntity>> GetRecordsByQueryAsync(string fieldName, object value, List<string> uniqueFields)
        {
            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var property = Expression.Property(parameter, fieldName);
            var propertyType = property.Type;

            if (value is string stringValue && !TryConvertStringValue(stringValue, propertyType, out value))
            {
                throw new ArgumentException($"Cannot convert value to the type {propertyType.Name}.");
            }

            var constant = Expression.Constant(value, propertyType);
            var equals = Expression.Equal(property, constant);
            var lambda = Expression.Lambda<Func<TEntity, bool>>(equals, parameter);

            IQueryable<TEntity> query = _context.Set<TEntity>().Where(lambda);

            if (uniqueFields.Any())
            {
                foreach (var uniqueField in uniqueFields)
                {
                    query = query.GroupBy(Expression.Lambda<Func<TEntity, object>>(
                        Expression.Convert(Expression.Property(parameter, uniqueField), typeof(object)), parameter))
                        .Select(g => g.FirstOrDefault());
                }
            }

            return await query.ToListAsync();
        }



        private bool TryConvertStringValue(string stringValue, Type targetType, out object convertedValue)
        {
            convertedValue = null;
            try
            {
                // Handle common types explicitly
                if (targetType == typeof(int))
                {
                    convertedValue = int.Parse(stringValue);
                }
                else if (targetType == typeof(DateTime))
                {
                    convertedValue = DateTime.Parse(stringValue);
                }
                else if (targetType == typeof(double))
                {
                    convertedValue = double.Parse(stringValue);
                }
                else
                {
                    // Fallback for other convertible types
                    convertedValue = Convert.ChangeType(stringValue, targetType);
                }
                return true;
            }
            catch
            {
                return false; // Conversion failed
            }
        }


    }
}
