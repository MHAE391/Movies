namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController(IMoviesService service) : ControllerBase
    {  
        [HttpPost]
        public async Task<ActionResult<Response<MovieDTO>>> CreateMovie( [FromForm] CreateMovie movie)
        {
            var response = await service.CreateMovie(movie);
            return response.IsSuccessed ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMovies()
        {
            var response = await service.GetMovies();
            return response.IsSuccessed ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MovieDTO>> GetMovie(int id)
        {
            var response = await service.GetMovie(id);
            return response.IsSuccessed ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<MovieDTO>> DeleteMovie(int id)
        {
            var response = await service.DeleteMovie(id);
            return response.IsSuccessed ? Ok(response) : BadRequest(response);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<MovieDTO>> UpdateMovie (int id , [FromForm]CreateMovie movie)
        {
            var response = await service.UpdateMovie(id , movie);
            return response.IsSuccessed ? Ok(response) : BadRequest(response);
        }
    }
}