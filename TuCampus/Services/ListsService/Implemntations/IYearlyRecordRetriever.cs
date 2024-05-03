using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuCampus.Services.ListsService.Implemntations
{
    public interface IYearlyRecordManagement
    {
        IEnumerable<object> RetrieveRecords(int year, IEnumerable<string> uniqueFields);
        void ProposeRecordUpdate(object record, int requestedYear);
    }

}
