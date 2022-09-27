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
    public class TelephoneDirDBContext : ITelephoneDirService
    {
        public readonly IMongoDatabase _db;

        public TelephoneDirDBContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<Person> personCollection => _db.GetCollection<Person>("telephoned");
        public IMongoCollection<Contact> contactCollection => _db.GetCollection<Contact>("contact");
        public IMongoCollection<ReportDetail> detailsCollection => _db.GetCollection<ReportDetail>("reportDetail");


        public IEnumerable<Person> GetAllPerson()
        {
            return personCollection.Find(a => true).ToList();
        }
        public Person GetPersonDetails(string name)
        {
            var personDetails = personCollection.Find(m => m.name == name).FirstOrDefault();
            return personDetails;
        }

        public void Create(Person personData)
        {
            personCollection.InsertOne(personData);
            personData.contactData.name = personData.name; 
            contactCollection.InsertOne(personData.contactData);
        }

        public void Update(string name, Person personData)
        {
            var filter = Builders<Person>.Filter.Eq(c => c.name, name);
            var update = Builders<Person>.Update
                .Set("name", personData.name)
                .Set("surname", personData.surname)
                .Set("company", personData.company);

            personCollection.UpdateOne(filter, update);
        }

        public void Delete(string name)
        {
            var filter = Builders<Person>.Filter.Eq(c => c.name, name);
            personCollection.DeleteOne(filter);

        }
    }
}
