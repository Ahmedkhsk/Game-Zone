using Task.Models;

namespace Task.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        Context context;
        public DepartmentRepository(Context _context)
        {
            context = _context;
        }
        public void Add(Department obj)
        {
            context.Add(obj);
        }
        public void Update(Department obj)
        {
            context.Update(obj);
        }
        public void Delete(Department obj)
        {
            context.Remove(obj);
        }
        public List<Department> getAll()
        {
            return context.Departments.ToList();
        }
        public Department getByID(int id)
        {
            return context.Departments.FirstOrDefault(e => e.Id == id);
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
