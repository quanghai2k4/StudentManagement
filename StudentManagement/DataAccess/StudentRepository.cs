using System.Collections.Generic;
using System.Linq;
using Domain;

namespace DataAccess
{
    public class StudentRepository
    {
        private readonly DataStore _dataStore;

        public StudentRepository(DataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public List<Student> RetrieveStudents()
        {
            return _dataStore.Students;
        }

        public Student? RetrieveStudent(int id)
        {
            return _dataStore.Students.FirstOrDefault(s => s.Id == id);
        }

        public void CreateStudent(Student student)
        {
            _dataStore.Students.Add(student);
        }

        public void UpdateStudent(Student student)
        {
            var existing = RetrieveStudent(student.Id);
            if (existing != null)
            {
                existing.FirstName = student.FirstName;
                existing.LastName = student.LastName;
                existing.DateOfBirth = student.DateOfBirth;
                existing.Major = student.Major;
            }
        }

        public void DeleteStudent(int id)
        {
            var student = RetrieveStudent(id);
            if (student != null)
            {
                _dataStore.Students.Remove(student);
            }
        }

        public List<Major> RetrieveMajors()
        {
            return _dataStore.Majors;
        }
    }
}
