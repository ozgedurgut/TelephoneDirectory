using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelephoneDir.Models;

namespace TelephoneDir.Interface
{
    public interface IReportDetailsService
    {
        IMongoCollection<ReportDetail> detailsCollection { get; }
        IEnumerable<ReportDetail> GetAllReportDetails();
      //  void Create(ReportDetail reportDetail);
        ReportDetail GetReportDetails(string id);
       
    }
}
