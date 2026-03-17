using System;

namespace Domain
{
    public class Personnel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public Department? Department { get; set; }
    }
}
