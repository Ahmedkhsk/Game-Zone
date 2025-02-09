namespace Project.Repository
{
    public interface IGameDeviceRepository
    {
        public void Add(GameDevice obj);
        public void Remove(GameDevice obj);
        public void Update(GameDevice obj);
        public GameDevice GetByID(int DeviceID,int GameID);
        public void Save();
    }
}
