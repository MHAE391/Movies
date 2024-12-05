namespace API.DataAccess.Database
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Movie>Movies {get; set;}
        public DbSet<Classification> Classifications {get; set;}
    }
}