using System.ComponentModel.DataAnnotations.Schema;

namespace Task.Models
{
    [Table("Department")]
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manager { get; set; }
        public ICollection<Instractor> Instractors { get; set; }
        public ICollection<Trainee> Trainees { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
