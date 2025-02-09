namespace Project.Settings
{
    public static class FileSettings
    {
        public const string ImagesPath = "/assets/Images/Games";
        public const string AllowedExtensions = ".jpg, .jpeg,.png";
        public const int MaxFileSizeInMB = 1;
        public const int MaxFileSizeInBytes = MaxFileSizeInMB * 1024 * 1024;
    }
}
