namespace API.DataAccess.DTOs
{
    public class CreateClassification
    {
        [MinLength(3) , MaxLength(50)]
        public required string ClassificationName { get; set;} 
        
    }
}