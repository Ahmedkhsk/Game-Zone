namespace Task.Repository
{
    public class CrsResultRepository : ICrsResultRepository
    {
        Context context;
        public CrsResultRepository(Context _context)
        {
            context = _context;
        }
        public void Add(crsResult obj)
        {
            context.Add(obj);
        }
        public void Update(crsResult obj)
        {
            context.Update(obj);
        }
        public void Delete(crsResult obj)
        {
            context.Remove(obj);
        }
        public List<crsResult> getAll()
        {
            return context.crsResult.ToList();
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public int getDegree(int TID, int CID)
        {
            crsResult obj = context.crsResult.FirstOrDefault(e => e.CourseID == CID && e.TraineeID == TID);
            return obj.degree;
        }
    }
}
