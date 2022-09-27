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
    public class ReportDetailsDBContext : IReportDetailsService
    {
        public readonly IMongoDatabase _db;
        public ReportDetailsDBContext(IOptions<Settings>options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<ReportDetail> detailsCollection => _db.GetCollection<ReportDetail>("reportDetail");

        public IEnumerable<ReportDetail> GetAllReport()
        {
            return detailsCollection.Find(a => true).ToList();
        }

        public ReportDetail GetReportDetails(string location)
        {
            var reportDetails = detailsCollection.Find(m => m.location == location).FirstOrDefault();
            return reportDetails;
        }
    }
}
