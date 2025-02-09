using Microsoft.EntityFrameworkCore;

namespace Task.Models
{
    public class Context:DbContext
    {
        public DbSet<Instractor> Instractors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<crsResult> crsResult { get; set; }
        public Context():base()
        {
            
        }
        public Context(DbContextOptions options):base(options)
        {
            
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=.; Initial Catalog=DB_Task_MVC;Integrated Security=True; Encrypt=False; Trust Server Certificate=True");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
