using System.Collections.Generic;

namespace Domain
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public List<Personnel> Staff { get; set; } = new List<Personnel>();
    }
}
