
namespace API.DataAccess.Repositories.Implementation
{
    public class MoviesRepository(ApplicationDbContext context) : IMoviesRepository
    {
        public async Task<Response<Movie>> CreateMovie(CreateMovie movie , byte[] poster )  
        {
            var newMovie = new Movie 
            {
                Title = movie.Title,
                Description = movie.Description,
                Poster = poster,
                ProductionYear = movie.ProductionYear,
                Rating = movie.Rating,
                ClassificationID = movie.ClassificationID,
                Classification = context.Classifications.First(x=> x.Id == movie.ClassificationID),
            };

            await context.Movies.AddAsync(newMovie);
            await context.SaveChangesAsync();

            return new Response<Movie>
            {
                IsSuccessed = true,
                Data = newMovie
            };
        }
        public async Task<Response<IEnumerable<Movie>>> GetMovies()
        {
            var movies = await context.Movies.ToListAsync();
            return new Response<IEnumerable<Movie>>
            {
                IsSuccessed = true,
                Data = movies
            };
        }
        public async Task<Response<Movie>> GetMovie(int id)
        {
            var movie = await context.Movies.FirstOrDefaultAsync(x => x.Id == id);
            return new Response<Movie> 
            { 
                IsSuccessed = movie is not null ,
                Data = movie ,
                Errores = movie is null ? new List<string> {$" No Movie with Id : {id}"} : null
            };
        }
        public async Task<Response<Movie>> UpdateMovie(int id , CreateMovie movie , byte[] poster)
        {
            var oldMovie = await GetMovie(id);
            if(!oldMovie.IsSuccessed) return oldMovie;
            oldMovie.Data!.Title = movie.Title;
            oldMovie.Data!.Description = movie.Description;
            oldMovie.Data.Poster = poster;
            oldMovie.Data.ProductionYear = movie.ProductionYear;
            oldMovie.Data.ClassificationID = movie.ClassificationID;
            context.Movies.Update(oldMovie.Data);
            await context.SaveChangesAsync();
            return new Response<Movie> {IsSuccessed = true , Data = oldMovie.Data };
        }
        public async Task<Response<Movie>> DeleteMovie(int id)
        {
            var movie = await GetMovie(id);
            if(!movie.IsSuccessed) return movie;
            context.Movies.Remove(movie.Data!);
            await context.SaveChangesAsync();
            return movie;
        }
    }
}