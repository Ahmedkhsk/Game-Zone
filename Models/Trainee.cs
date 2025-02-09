using System.ComponentModel.DataAnnotations.Schema;

namespace Task.Models
{
    [Table("Trainee")]
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Imag { get; set; }
        public int grade { get; set; }
        public string Address { get; set; }
        
        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
    }
}
