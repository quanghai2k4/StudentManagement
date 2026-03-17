using System.Collections.Generic;
using DataAccess;
using Domain;

namespace Application
{
    public class PersonnelUseCase
    {
        private readonly PersonnelRepository _repository;
        private readonly DataStore _dataStore;

        public PersonnelUseCase(PersonnelRepository repository, DataStore dataStore)
        {
            _repository = repository;
            _dataStore = dataStore;
        }

        public List<Personnel> GetAllPersonnel()
        {
            return _repository.RetrievePersonnel();
        }

        public Personnel? GetPersonById(int id)
        {
            return _repository.RetrievePerson(id);
        }

        public List<Department> GetAllDepartments()
        {
            return _dataStore.Departments;
        }

        public void AddPerson(Personnel person)
        {
            _repository.CreatePerson(person);
        }

        public void UpdatePerson(Personnel person)
        {
            _repository.UpdatePerson(person);
        }

        public void DeletePerson(int id)
        {
            _repository.DeletePerson(id);
        }
    }
}
