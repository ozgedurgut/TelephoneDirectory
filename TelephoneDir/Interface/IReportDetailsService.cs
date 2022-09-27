using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelephoneDir.Models;

namespace TelephoneDir.Interface
{
    interface IReportDetailsService
    {

        IMongoCollection<ReportDetail> detailsCollection { get; }
        IEnumerable<ReportDetail> GetAllReport();
        ReportDetail GetReportDetails(string id);
       
    }
}
