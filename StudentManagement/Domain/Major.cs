using System.Collections.Generic;

namespace Domain
{
    public class Major
    {
        public int Id { get; set; }
        public string MajorName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
