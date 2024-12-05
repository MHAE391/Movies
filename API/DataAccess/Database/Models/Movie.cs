namespace API.DataAccess.Database.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [MinLength(3) , MaxLength(100)]
        public required string Title { get; set; }
        [MinLength(3),MaxLength(500)]
        public required string Description { get; set; }

        public required byte[] Poster { get; set; }

        [Range(0 , 10)]
        public double Rating { get; set; }
        [Range(1  , 2025)]
        public int ProductionYear { get; set; }

        [ForeignKey(nameof(Classification))]
        public required int ClassificationID { get; set; }
        public virtual Classification Classification { get; set; }
        
    }
}