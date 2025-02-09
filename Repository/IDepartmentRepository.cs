using Task.Models;

namespace Task.Repository
{
    public interface IDepartmentRepository
    {
        public void Add(Department obj);
        public void Update(Department obj);
        public void Delete(Department obj);
        public List<Department> getAll();
        public Department getByID(int id);
        public void Save();
    }
}
