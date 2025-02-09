namespace Project.Attributes
{
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string _allowedExtensions;
        public AllowedExtensionsAttribute(string allowedExtensions)
        {
            _allowedExtensions = allowedExtensions;
        }

        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            
            if (file != null)
            {
                var extensions = Path.GetExtension(file.FileName);

                var isAllowed = _allowedExtensions.Split(",").Contains(extensions, StringComparer.OrdinalIgnoreCase);

                if(!isAllowed)
                {
                    return new ValidationResult( $"only {_allowedExtensions} are allowed!");
                }
            }
            return ValidationResult.Success;
        }
    }
}
