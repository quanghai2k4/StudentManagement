using System.Collections.Generic;
using DataAccess;
using Domain;

namespace Application
{
    public class PersonnelUseCase
    {
        private readonly PersonnelRepository _repository;

        public PersonnelUseCase(PersonnelRepository repository)
        {
            _repository = repository;
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
            return _repository.RetrieveDepartments();
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
