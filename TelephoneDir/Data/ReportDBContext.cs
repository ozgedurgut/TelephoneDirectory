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
        public IMongoCollection<Contact> contactCollection => _db.GetCollection<Contact>("contact");
        public IMongoCollection<Contact> detailsCollection => _db.GetCollection<Contact>("reportDetail");

        public IEnumerable<Report> GetAllReport()
        {
            return reportCollection.Find(a => true).ToList();
        }
        public Report GetReportDetails(string id)
        {
            var reportDetails = reportCollection.Find(m => m.id==id).FirstOrDefault();         
            return reportDetails;
        }
        public void CreateReport(Report report)
        {
            string location= report.detail.location;
            var filterDefinition = Builders<Contact>.Filter.Eq(p => p.data, location);
            var filterPersonList = contactCollection.Find(filterDefinition).ToList();
            var personCount = contactCollection.Find(filterDefinition).ToList().Count();

            report.detail.personCount = personCount;

            reportCollection.InsertOne(report);

            //return reportCollection.Find(a=>true).ToList();
        }
    }
}
