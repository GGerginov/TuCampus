using DataLayer.DbContexts;
using DataLayer.Models;
using DataLayer.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuCampus.Services.ListsService
{
    public class GradeRecordService : AbstractDataService<TuCampusDbContext, GradeRecord>
    {
        public GradeRecordService(TuCampusDbContext context) : base(context) { }
    }

}
