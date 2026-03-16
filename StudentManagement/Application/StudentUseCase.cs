using System.Collections.Generic;
using DataAccess;
using Domain;

namespace Application
{
    public class StudentUseCase
    {
        private readonly StudentRepository _repository;
        private readonly DataStore _dataStore; // Cần dùng để lấy danh sách Major

        public StudentUseCase(StudentRepository repository, DataStore dataStore)
        {
            _repository = repository;
            _dataStore = dataStore;
        }

        public List<Student> GetAllStudents()
        {
            return _repository.RetrieveStudents();
        }

        public Student? GetStudentById(int id)
        {
            return _repository.RetrieveStudent(id);
        }

        public List<Major> GetAllMajors()
        {
            return _dataStore.Majors;
        }

        public void AddStudent(Student student)
        {
            _repository.CreateStudent(student);
        }

        public void UpdateStudent(Student student)
        {
            _repository.UpdateStudent(student);
        }

        public void DeleteStudent(int id)
        {
            _repository.DeleteStudent(id);
        }
    }
}
