namespace API.DataAccess.Repositories.Interfaces
{
    public interface IMoviesRepository
    {
        public Task<Response<Movie>> CreateMovie(CreateMovie movie , byte[] poster);  
        public Task<Response<IEnumerable<Movie>>> GetMovies();
        public Task<Response<Movie>> GetMovie(int id);  
        public Task<Response<Movie>> UpdateMovie(int id , CreateMovie movie , byte[] poster);
        public Task<Response<Movie>> DeleteMovie(int id);
    }
}