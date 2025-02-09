using Task.Models;

namespace Task.Repository
{
    public interface IInstructorRepository
    {
        public void Add(Instractor obj);
        public void Update(Instractor obj);
        public void Delete(Instractor obj);
        public List<Instractor> getAll();
        public Instractor getByID(int id);
        public List<Instractor> getAllWithDepatCourse();
        public void Save();

    }
}
