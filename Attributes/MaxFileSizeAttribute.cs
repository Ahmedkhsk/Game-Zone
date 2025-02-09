namespace Project.Attributes
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _MaxFileSize;
        public MaxFileSizeAttribute(int MaxFileSize)
        {
            _MaxFileSize = MaxFileSize;
        }

        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if (file != null)
            {
                if (file.Length > _MaxFileSize)
                {
                    return new ValidationResult($"Maximum alllwed size is {_MaxFileSize} Bytes");
                }
            }
            return ValidationResult.Success;
        }
    }
}
