namespace API.DataAccess.Attributes
{
    public class ValidPosterAttribute(string[] allowedExtensions ,  int maxFileSize) : ValidationAttribute
    {
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                string fileExtension = Path.GetExtension(file.FileName)?.ToLower();
                if (Array.IndexOf(allowedExtensions, fileExtension) == -1)
                {
                    return new ValidationResult($"Invalid file extension. Allowed extensions are: {string.Join(", ", allowedExtensions)}.");
                }

                // Check file size
                if (file.Length > maxFileSize)
                {
                    return new ValidationResult($"File size exceeds the maximum allowed size of {maxFileSize / (1024 * 1024)} MB.");
                }

                return ValidationResult.Success;
            }

            return new ValidationResult("Invalid file format.");
        }
    }
}