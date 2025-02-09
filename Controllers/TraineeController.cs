namespace Task.Controllers
{
    public class TraineeController : Controller
    {
        private readonly ICrsResultRepository crsResultRepo;
        private readonly ICourseRepository courseRepo;
        private readonly ITraineeRepository traineeRapo;
        public TraineeController
            (ICrsResultRepository crsResultRepo, ICourseRepository courseRepo, ITraineeRepository traineeRapo)
        {
            this.crsResultRepo = crsResultRepo;
            this.courseRepo = courseRepo;
            this.traineeRapo = traineeRapo;
        }
        public IActionResult Index()
        {
            return View("Index", traineeRapo.getAll());
        }

        //Trainee/showResult/2?crsid=2
        public IActionResult showResult(int id,int crsid)
        {
            StudentCourseGradeColorViewModel obj = new StudentCourseGradeColorViewModel();
            
            obj.traineeName = traineeRapo.getByID(id).Name;
            obj.courseName = courseRepo.getByID(crsid).Name;
            obj.grade = crsResultRepo.getDegree(id, crsid);
            int minDegree = courseRepo.getByID(crsid).minDegree;

            if(obj.grade >= minDegree)
            {
                obj.color = "blue";
                obj.state = true;
            }
            else
            {
                obj.color = "red";
                obj.state = false;
            }
            return View("showResult",obj); //StudentCourseGradeColorViewModel
        }
        //Trainee/ShowAllCourses/1
        public IActionResult ShowAllCourses(int id) //Id Trainee
        {
            List<Course> courses = new List<Course>();
            List<crsResult> crsResult = crsResultRepo.getAll();
            
            foreach (var item in crsResult)
                if (item.TraineeID == id)
                    courses.Add(courseRepo.getByID(item.CourseID));

            return View("ShowAllCourses", courses);
        }
    }
}
