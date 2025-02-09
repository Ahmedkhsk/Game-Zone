using System.ComponentModel.DataAnnotations.Schema;
using Task.Models;

namespace Task.ViewModel
{
    public class InstrutorCourseDeptList
    {
        /*
        public int Id { get; set; }
        public string Name { get; set; }
        public string Imag { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public int DepartmentID { get; set; }
        public int CourseID { get; set; }
        */
        public List<Course> ListCourses { get; set; }
        public List<Department> ListDepartment { get; set; }
    }
}
