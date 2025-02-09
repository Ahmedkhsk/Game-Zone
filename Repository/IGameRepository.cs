namespace Project.Repository
{
    public interface IGameRepository
    {
        public IEnumerable<Game> getAll();
        public Game? GetByID(int id);
        public Task Add(CreateGameFormVM model);
        public Task<Game?> Update(EditGameFormViewModel model);
        public bool Delete(int id);

    }
}
