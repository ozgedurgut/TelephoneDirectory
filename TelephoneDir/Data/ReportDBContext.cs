using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelephoneDir.Interface;
using TelephoneDir.Models;

namespace TelephoneDir.Data
{
    public class ReportDBContext : IReportService
    {
        public readonly IMongoDatabase _db;


        public ReportDBContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }
        public IMongoCollection<Report> reportCollection => _db.GetCollection<Report>("report");

        public IEnumerable<Report> GetAllReport()
        {
            return reportCollection.Find(a => true).ToList();
        }

        public Report GetReportDetails(int id)
        {
            var reportDetails = reportCollection.Find(m => m.id == id).FirstOrDefault();
            return reportDetails;
        }

        public void CreateReport(Report report)
        {
            reportCollection.InsertOne(report);
        }

    }
}
