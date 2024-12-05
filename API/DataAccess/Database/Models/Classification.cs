namespace API.DataAccess.Database.Models
{
    public class Classification
    {
        [Key]
        public int Id { get; set; }

        [MinLength(3) , MaxLength(50)]
        public required string Name { get; set; }

        public virtual IEnumerable<Movie> Movies{ get; set; } 
    }
}