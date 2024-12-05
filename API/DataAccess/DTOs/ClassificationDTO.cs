namespace API.DataAccess.DTOs
{
    public class ClassificationDTO : BaseDTO
    {
        public required string Name { get; set; }
        public IEnumerable<ClassificationMovie>? ClassificationMovies { get; set; } = null;
    }

    public class ClassificationMovie : BaseDTO 
    {
        public required string Name { get; set;}
    }
}