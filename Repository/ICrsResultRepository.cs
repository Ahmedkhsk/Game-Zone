using Task.Models;

namespace Task.Repository
{
    public interface ICrsResultRepository
    {
        public void Add(crsResult obj);
        public void Update(crsResult obj);
        public void Delete(crsResult obj);
        public List<crsResult> getAll();
        public int getDegree(int TID, int CID);
        public void Save();
    }
}
