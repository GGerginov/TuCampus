using DataLayer.DbContexts;
using DataLayer.Models.ListModels;
using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuCampus.Services.ListsService
{
    public class PresentListService : AbstractDataService<TuCampusDbContext, PresentList>
    {
        public PresentListService(TuCampusDbContext context) : base(context) { }

    }
}
