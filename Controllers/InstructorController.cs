namespace Task.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IInstructorRepository instructor;
        private readonly ICourseRepository course;
        private readonly IDepartmentRepository dept;

        //Context context = new Context();

        public InstructorController(IInstructorRepository _instructor, ICourseRepository _course , IDepartmentRepository _dept)
        {
            instructor = _instructor;
            course = _course;
            dept = _dept;
        }
        //Instructor/Index
        public IActionResult Index()
        {
            List<Instractor> Instractor = instructor.getAllWithDepatCourse();
            return View("Index", Instractor); //List<Instractor>
        }
        //Instructor/Details/1
        //Instructor/Details?1
        public IActionResult Details(int id)
        {
            Instractor insModel = instructor.getByID(id);

            return View("Details", insModel);
        }

        public IActionResult Add()
        {
            InstrutorCourseDeptList obj = new InstrutorCourseDeptList();
            List<Course> Courseli = course.getAll();
            List <Department> Departmentli = dept.getAll();
            obj.ListCourses = Courseli;
            obj.ListDepartment = Departmentli;
            return View("Add", obj);//InstrutorCourseDeptList
        }
        //Instructor/SaveAdd
        [HttpPost]
        public IActionResult SaveAdd(Instractor obj)
        {
            if(obj != null)
            {
                instructor.Add(obj);
                instructor.Save();
                return RedirectToAction("Index");
            }
            return View("SaveAdd");
        }
    }
}
