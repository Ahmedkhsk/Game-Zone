using Microsoft.EntityFrameworkCore;
using Task.Models;

namespace Task.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        Context context;
        public InstructorRepository(Context _context)
        {
            context = _context;
        }
        public void Add(Instractor obj)
        {
            context.Add(obj);
        }
        public void Update(Instractor obj)
        {
            context.Update(obj);
        }
        public void Delete(Instractor obj)
        {
            context.Remove(obj);
        }
        public List<Instractor> getAll()
        {
            return context.Instractors.ToList();
        }
        public Instractor getByID(int id)
        {
            return context.Instractors.FirstOrDefault(e => e.Id == id);
        }
        public List<Instractor> getAllWithDepatCourse()
        {
            return context.Instractors.Include(e => e.Department).Include(e => e.Course).ToList();
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
