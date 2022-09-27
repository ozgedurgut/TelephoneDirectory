using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelephoneDir.Models
{
    public class ReportDetail
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public String location { get; set; }

        public int personCount { get; set; }
        public int numberCount { get; set; }
    }
}
