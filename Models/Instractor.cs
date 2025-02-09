using System.ComponentModel.DataAnnotations.Schema;

namespace Task.Models
{
    [Table("Instractor")]
    public class Instractor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Imag { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public Department Department { get; set; }

        [ForeignKey("Course")]
        public int CourseID { get; set; }
        public Course Course { get; set; }
    }
}
