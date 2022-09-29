using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelephoneDir.Models;

namespace TelephoneDir.Interface
{
    public interface IReportService
    {

        IMongoCollection<Report> reportCollection { get; }
        IEnumerable<Report> GetAllReport();
        Report GetReportDetails(string id);
        void CreateReport(Report report);
       // object GetReportDetails(string id);
        //    void Update(int id, Report report);

    }
}
