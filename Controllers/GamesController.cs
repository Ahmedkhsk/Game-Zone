using Project.Models;

namespace Project.Controllers
{
    public class GamesController : Controller
    {
        private readonly ICategorieRepository categorieRepo;
        private readonly IGameRepository gameRepository;
        private readonly IDeviceRepository deviceRepository;

        public GamesController(ICategorieRepository CategorieRepo,IGameRepository gameRepository,IDeviceRepository deviceRepository)
        {
            categorieRepo = CategorieRepo;
            this.gameRepository = gameRepository;
            this.deviceRepository = deviceRepository;
        }
        public IActionResult Index()
        {
            return View("Index",gameRepository.getAll());
        }
        public IActionResult Details(int id)
        {
            var game = gameRepository.GetByID(id);

            if (game is null)
                return NotFound();

            return View("Details", game);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CreateGameFormVM createGameFormVM = new CreateGameFormVM()
            {
                Categories = categorieRepo.SelectAll(),
                Devices = deviceRepository.SelectAll()
            };
            return View("Create", createGameFormVM);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveCreate(CreateGameFormVM model)
        {
            if(!ModelState.IsValid)
            {
                model.Categories = categorieRepo.SelectAll();
                model.Devices = deviceRepository.SelectAll();
                return View("Create", model);   
            }
            await gameRepository.Add(model);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var game = gameRepository.GetByID(id);

            if (game is null)
                return NotFound();

            EditGameFormViewModel viewModel = new EditGameFormViewModel();

            viewModel.Id = id;
            viewModel.Name = game.Name;
            viewModel.Description = game.Description;
            viewModel.CategorieId = game.CategorieId;
            viewModel.SelectedDevices = game.Devices.Select(d => d.DeviceId).ToList();
            viewModel.Categories = categorieRepo.SelectAll(); 
            viewModel.Devices = deviceRepository.SelectAll();
            viewModel.CurentCover = game.Cover;

            return View(viewModel);
        }
        
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditGameFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = categorieRepo.SelectAll();
                model.Devices = deviceRepository.SelectAll();
                return View("Edit", model);
            }

            var game = await gameRepository.Update(model);

            if (game is null)
                return BadRequest();

            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var isDeleted = gameRepository.Delete(id);

            
            return isDeleted ? Ok() : BadRequest();
        }

    }
}
