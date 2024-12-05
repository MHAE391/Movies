using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DataAccess.DTOs
{
    public class MovieDTO : BaseDTO
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required byte[] Poster { get; set; }
        public double Rating { get; set; }
        public int ProductionYear { get; set; }
        public int? ClassificationID  { get; set; }
        public string? ClassificationName { get; set; }
    }
}