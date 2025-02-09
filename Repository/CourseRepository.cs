namespace Task.Repository
{
    public class CourseRepository : ICourseRepository
    {
        Context context;
        private readonly ICourseRepository courseRepo;

        public CourseRepository(Context _context)
        {
            context = _context;
            this.courseRepo = courseRepo;
        }
        public void Add(Course obj)
        {
            context.Add(obj);
        }
        public void Update(Course obj)
        {
            context.Update(obj);
        }
        public void Delete(Course obj)
        {
            context.Remove(obj);
        }
        public List<Course> getAll()
        {
            return context.Courses.Include(e => e.Department).ToList();
        }
        public Course getByID(int id)
        {
            return context.Courses.FirstOrDefault(e => e.Id == id);
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
