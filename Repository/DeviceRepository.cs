namespace Project.Repository
{
    public class DeviceRepository:IDeviceRepository
    {
        private readonly Context context;

        public DeviceRepository(Context context)
        {
            this.context = context;
        }

        public void Add(Device obj)
        {
            context.Add(obj);
        }
        public void Update(Device obj)
        {
            context.Update(obj);
        }
        public void Remove(Device obj)
        {
            context.Remove(obj);
        }
        public Device GetByID(int id)
        {
            return context.Devices.FirstOrDefault(e => e.Id == id);
        }
        public List<SelectListItem> SelectAll()
        {
            return context.Devices.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                .OrderBy(c => c.Text)
                .AsNoTracking()
                .ToList();
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
