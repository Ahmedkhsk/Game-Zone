namespace Task.Repository
{
    public interface ITraineeRepository
    {
        public void Add(Trainee obj);
        public void Update(Trainee obj);
        public void Delete(Trainee obj);
        public List<Trainee> getAll();
        public Trainee getByID(int id);
        public void Save();
    }
}
