using System.Linq;

namespace Project.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly Context context;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly string _imagePath;
        public GameRepository(Context context,IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
            _imagePath = $"{webHostEnvironment.WebRootPath}{FileSettings.ImagesPath}";
        }
        public Game? GetByID(int id)
        {
            return context.Games
                    .Include(c => c.Categorie)
                    .Include(d => d.Devices)
                    .ThenInclude(g => g.Device)
                    .AsNoTracking()
                    .FirstOrDefault(e => e.Id == id);
        }
        public IEnumerable<Game> getAll()
        {
            return context.Games
                .Include(c => c.Categorie)
                .Include(d => d.Devices)
                .ThenInclude(g => g.Device)
                .AsNoTracking()
                .ToList();
        }
        public async Task Add(CreateGameFormVM game)
        {

            var coverNaem = await SaveCover(game.Cover);

            Game gameModel = new Game();
            gameModel.Name = game.Name;
            gameModel.Description = game.Description;
            gameModel.Cover = coverNaem;
            gameModel.CategorieId = game.CategorieId;
            gameModel.Devices = game.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList();

            context.Add(gameModel);

            context.SaveChanges();
        }
        public async Task<Game?> Update(EditGameFormViewModel model)
        {
            var game = context.Games
                        .Include(g => g.Devices)
                        .SingleOrDefault(g => g.Id == model.Id);


            if (game is null)
                return null;

            var hasNewCover = model.Cover is not null;
            var oldCover = game.Cover;

            game.Name = model.Name;
            game.Description = model.Description;
            game.CategorieId = model.CategorieId;
            game.Devices = model.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList();

            if (hasNewCover)
            {
                game.Cover = await SaveCover(model.Cover!);
            }

            var effectRows = context.SaveChanges();

            if (effectRows > 0)
            {
                if (hasNewCover)
                {
                    var cover = Path.Combine(_imagePath, oldCover);
                    File.Delete(cover);
                }
                return game;
            }
            else
            {
                var cover = Path.Combine(_imagePath, game.Cover);
                File.Delete(cover);

                return null;
            }
        }
        public bool Delete(int id)
        {
            var isDeleted = false;
            var game = context.Games.Find(id);

            if (game is null)
                return isDeleted;

            context.Remove(game);

            var effectedRows = context.SaveChanges();
            
            if(effectedRows > 0)
            {
                isDeleted = true;

                var cover = Path.Combine(_imagePath, game.Cover);
                File.Delete(cover);
            }

            return isDeleted;
        }
        private async Task<string> SaveCover(IFormFile Cover)
        {
            var coverNaem = $"{Guid.NewGuid()}{Path.GetExtension(Cover.FileName)}";
            var path = Path.Combine(_imagePath, coverNaem);

            using var stream = File.Create(path);
            await Cover.CopyToAsync(stream);

            return coverNaem;
        }      
    }
}
