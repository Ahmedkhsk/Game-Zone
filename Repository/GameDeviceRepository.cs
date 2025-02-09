namespace Project.Repository
{
    public class GameDeviceRepository : IGameDeviceRepository
    {
        private readonly Context context;

        public GameDeviceRepository(Context context)
        {
            this.context = context;
        }

        public void Add(GameDevice obj)
        {
            context.Add(obj);
        }
        public void Update(GameDevice obj)
        {
            context.Update(obj);
        }
        public void Remove(GameDevice obj)
        {
            context.Remove(obj);
        }

        public GameDevice GetByID(int DeviceID, int GameID)
        {
            return context.GameDevice.FirstOrDefault(e =>  e.GameId == GameID && e.DeviceId == DeviceID);
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
