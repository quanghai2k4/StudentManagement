using System.Collections.Generic;
using Domain;

namespace DataAccess
{
    public class DataStore
    {
        public List<Personnel> PersonnelList { get; set; } = new List<Personnel>();
        public List<Department> Departments { get; set; } = new List<Department>();

        public DataStore()
        {
            SeedData();
        }

        private void SeedData()
        {
            var dept1 = new Department { Id = 1, DepartmentName = "HR", Location = "Floor 1" };
            var dept2 = new Department { Id = 2, DepartmentName = "Engineering", Location = "Floor 5" };
            
            Departments.Add(dept1);
            Departments.Add(dept2);

            PersonnelList.Add(new Personnel { Id = 1, FullName = "John Doe", Position = "HR Manager", Salary = 3000, Department = dept1 });
            PersonnelList.Add(new Personnel { Id = 2, FullName = "Jane Smith", Position = "Software Engineer", Salary = 5000, Department = dept2 });
        }
    }
}
