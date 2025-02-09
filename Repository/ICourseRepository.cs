namespace Task.Repository
{
    public interface ICourseRepository
    {
        public void Add(Course obj);
        public void Update(Course obj);
        public void Delete(Course obj);
        public List<Course> getAll();
        public Course getByID(int id);
        public void Save();
        

    }
}
