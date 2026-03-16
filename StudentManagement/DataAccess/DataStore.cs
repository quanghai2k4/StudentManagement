using System.Collections.Generic;
using Domain;

namespace DataAccess
{
    public class DataStore
    {
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Major> Majors { get; set; } = new List<Major>();

        public DataStore()
        {
            SeedData();
        }

        private void SeedData()
        {
            var majorIT = new Major { Id = 1, MajorName = "Information Technology", Description = "IT Department" };
            var majorBiz = new Major { Id = 2, MajorName = "Business Administration", Description = "Business School" };

            Majors.Add(majorIT);
            Majors.Add(majorBiz);

            Students.Add(new Student 
            { 
                Id = 1, 
                FirstName = "Nguyen", 
                LastName = "A", 
                DateOfBirth = new DateOnly(2003, 1, 1), 
                Major = majorIT 
            });

            Students.Add(new Student 
            { 
                Id = 2, 
                FirstName = "Tran", 
                LastName = "B", 
                DateOfBirth = new DateOnly(2004, 5, 20), 
                Major = majorBiz 
            });
        }
    }
}
