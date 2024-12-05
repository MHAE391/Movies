namespace API.DataAccess.Services.Interfaces
{
    public interface IMoviesService
    {
        public Task<Response<MovieDTO>> CreateMovie(CreateMovie movie);   
        public Task<Response<IEnumerable<MovieDTO>>> GetMovies();
        public Task<Response<MovieDTO>> GetMovie(int id);
        public Task<Response<MovieDTO>> DeleteMovie(int id);
        public Task<Response<MovieDTO>> UpdateMovie(int id, CreateMovie movie);
    }
}