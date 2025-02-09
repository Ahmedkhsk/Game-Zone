using System.ComponentModel.DataAnnotations.Schema;

namespace Task.Models
{
    [Table("Course")]
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int degree { get; set; }
        public int minDegree { get; set; }
        
        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public Department Department { get; set; }

    }
}
