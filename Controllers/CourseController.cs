namespace Task.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository course;
        private readonly IDepartmentRepository dept;
        private readonly ICrsResultRepository crsResultRepo;
        private readonly ITraineeRepository traineeRapo;

        public CourseController
            (ICourseRepository course,IDepartmentRepository dept, ICrsResultRepository crsResultRepo, ITraineeRepository traineeRapo)
        {
            this.course = course;
            this.dept = dept;
            this.crsResultRepo = crsResultRepo;
            this.traineeRapo = traineeRapo;
        }
        public IActionResult Index()
        {
            List<Course> obj = course.getAll();
            return View("Index",obj); //List<Course>
        }

        public IActionResult Add()
        {
            ViewData["DeptList"] = dept.getAll();
            return View("Add");
        }
        public IActionResult SaveAdd(Course obj)
        {
            if (obj.Name != null)
            {
                course.Add(obj);
                course.Save();
                return RedirectToAction("Index");
            }
            ViewData["DeptList"] = dept.getAll();   
            return View("Add", obj);
        }

        //Course/ShowAllTrainee/1
        public IActionResult ShowAllTrainee(int id)
        {
            List<TrDegreeColorWithCourseVM> Trainees = new List<TrDegreeColorWithCourseVM>();
            List<crsResult> crsResult = crsResultRepo.getAll();

            foreach (var item in crsResult)
            {
                if(item.CourseID == id)
                {
                    TrDegreeColorWithCourseVM obj = new TrDegreeColorWithCourseVM();
                    int minDegree = course.getByID(id).minDegree;
                    obj.traineeName = traineeRapo.getByID(item.TraineeID).Name;
                    obj.grade = item.degree;
                    obj.color = obj.grade >= minDegree ? "blue" : "red";
                    Trainees.Add(obj);
                }
            }

            return View("ShowAllTrainee", Trainees);
        }
    }
}
