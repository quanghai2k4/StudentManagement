using System.Collections.Generic;
using System.Linq;
using Domain;

namespace DataAccess
{
    public class PersonnelRepository
    {
        private readonly DataStore _dataStore;

        public PersonnelRepository(DataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public List<Personnel> RetrievePersonnel()
        {
            return _dataStore.PersonnelList;
        }

        public Personnel? RetrievePerson(int id)
        {
            return _dataStore.PersonnelList.FirstOrDefault(p => p.Id == id);
        }

        public void CreatePerson(Personnel person)
        {
            _dataStore.PersonnelList.Add(person);
        }

        public void UpdatePerson(Personnel person)
        {
            var existing = RetrievePerson(person.Id);
            if (existing != null)
            {
                existing.FullName = person.FullName;
                existing.Position = person.Position;
                existing.Salary = person.Salary;
                existing.Department = person.Department;
            }
        }

        public void DeletePerson(int id)
        {
            var person = RetrievePerson(id);
            if (person != null)
            {
                _dataStore.PersonnelList.Remove(person);
            }
        }
    }
}
