namespace Task.Repository
{
    public class TraineeRepository : ITraineeRepository
    {
        Context context;
        public TraineeRepository(Context _context)
        {
            context = _context;
        }
        public void Add(Trainee obj)
        {
            context.Add(obj);
        }
        public void Update(Trainee obj)
        {
            context.Update(obj);
        }
        public void Delete(Trainee obj)
        {
            context.Remove(obj);
        }
        public List<Trainee> getAll()
        {
            return context.Trainees.ToList();
        }
        public Trainee getByID(int id)
        {
            return context.Trainees.FirstOrDefault(e => e.Id == id);
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
