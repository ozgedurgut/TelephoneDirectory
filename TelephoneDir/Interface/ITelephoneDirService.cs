using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelephoneDir.Models;

namespace TelephoneDir.Interface
{
    public interface ITelephoneDirService
    {
        IMongoCollection<Person> personCollection { get; }
        IEnumerable<Person> GetAllPerson();
        Person GetPersonDetails(string name);
        void Create(Person personData);
        void Update(string name, Person personData);
        void Delete(string name);
    }
}
