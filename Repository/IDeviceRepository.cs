namespace Project.Repository
{
    public interface IDeviceRepository
    {
        public void Add(Device obj);
        public void Remove(Device obj);
        public void Update(Device obj);
        public Device GetByID(int id);
        public List<SelectListItem> SelectAll();
        public void Save();
    }
}
