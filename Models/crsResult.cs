using System.ComponentModel.DataAnnotations.Schema;

namespace Task.Models
{
    [Table("crsResult")]
    public class crsResult
    {
        public int Id { get; set; }
        public int degree { get; set; }

        [ForeignKey("Course")]
        public int CourseID { get; set; }
        public Course Course { get; set; }

        [ForeignKey("Trainee")]
        public int TraineeID { get; set; }
        public Trainee Trainee { get; set; }

    }
}
