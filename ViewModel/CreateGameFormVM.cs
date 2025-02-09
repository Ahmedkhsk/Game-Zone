namespace Project.ViewModel
{
    public class CreateGameFormVM : GameFormViewModel
    {


        [AllowedExtensions(FileSettings.AllowedExtensions)
            , MaxFileSize(FileSettings.MaxFileSizeInBytes)]
        public IFormFile Cover { get; set; } = default!;
    }
}
