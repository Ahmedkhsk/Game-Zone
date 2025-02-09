namespace Project.ViewModel
{
    public class EditGameFormViewModel : GameFormViewModel
    {
        public int Id { get; set; }
        public string? CurentCover { get; set; }

        [AllowedExtensions(FileSettings.AllowedExtensions)
            , MaxFileSize(FileSettings.MaxFileSizeInBytes)]
        public IFormFile? Cover { get; set; } = default!;

    }
}
