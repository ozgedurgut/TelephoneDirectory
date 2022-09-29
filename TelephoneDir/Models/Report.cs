using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelephoneDir.Models
{
    public class Report
    {

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string id { get; set; }
        public DateTime time { get; set; }
        public bool status { get; set; } //0 is pending 1 is ready
        public ReportDetail detail { get; set; }



    }


}
