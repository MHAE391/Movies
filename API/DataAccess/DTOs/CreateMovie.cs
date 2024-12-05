using API.DataAccess.Attributes;
namespace API.DataAccess.DTOs
{
    public class CreateMovie 
    {
        [MinLength(3), MaxLength(100)]
        public required string  Title { get; set; }

        [MinLength(3), MaxLength(500)]
        public required string  Description { get; set; }
        [ValidPoster( new string[] { ".jpg", ".png", ".jpeg" } , 2 * 1024 * 1024 )]
        public required IFormFile Poster { get; set; } 

        [Range(0, 10)]
        public double Rating { get; set; }

        [Range(1, 2025)]
        public int ProductionYear { get; set; }

        public int ClassificationID { get; set; }
    }
}