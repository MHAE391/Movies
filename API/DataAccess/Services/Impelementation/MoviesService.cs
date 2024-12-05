namespace API.DataAccess.Services.Implementation
{
    public class MoviesService(IClassificationRepository classificationRepository , IMoviesRepository moviesRepository) : IMoviesService
    {
        public async Task<Response<MovieDTO>> CreateMovie(CreateMovie movie)
        {
            var classification = await classificationRepository.GetClassification(movie.ClassificationID);
            if (!classification.IsSuccessed) return new Response<MovieDTO> { Errores = classification.Errores };
            using var memoryStream = new MemoryStream();
            await movie.Poster.CopyToAsync( memoryStream );
           var result = await moviesRepository.CreateMovie( movie , memoryStream.ToArray() );
            return new Response<MovieDTO> 
            {
                Errores = result.Errores,
                IsSuccessed = result.IsSuccessed,
                Data = result.Data is null ? null : new MovieDTO 
                {
                    Id = result.Data.Id,
                    Title = result.Data.Title,
                    Description = result.Data.Description,
                    Poster = result.Data.Poster,
                    ProductionYear = result.Data.ProductionYear,
                    Rating = result.Data.Rating,
                    ClassificationID = result.Data.ClassificationID,
                    ClassificationName = classification.Data!.Name
                }
            };
        }   

        public async Task<Response<IEnumerable<MovieDTO>>> GetMovies()
        {
            var movies = await moviesRepository.GetMovies();
            return new Response<IEnumerable<MovieDTO>> 
            {
                IsSuccessed = movies.IsSuccessed,
                Errores = movies.Errores,
                Data = movies.Data is null ? null : movies.Data. Select( x => 
                new MovieDTO 
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Poster = x.Poster,
                    ProductionYear = x.ProductionYear,
                    Rating = x.Rating,
                    ClassificationID =  x.Classification.Id ,
                    ClassificationName = x.Classification.Name
                }
                )
            };
        }

        public async Task<Response<MovieDTO>> GetMovie(int id)
        {
            var response = await moviesRepository.GetMovie(id);
            return new Response<MovieDTO> 
            {
                IsSuccessed = response.IsSuccessed,
                Errores = response.Errores,
                Data = response.Data is null ? null : new MovieDTO 
                {
                    Id = response.Data.Id,
                    Description = response.Data.Description,
                    Poster = response.Data.Poster,
                    Title = response.Data.Title,
                    ProductionYear = response.Data.ProductionYear,
                    Rating = response.Data.Rating,
                     ClassificationID = response.Data.Classification.Id ,
                    ClassificationName = response.Data.Classification.Name
                }
            };
        }

        public async Task<Response<MovieDTO>> DeleteMovie(int id)
        {
            var response = await moviesRepository.DeleteMovie(id);
            return new Response<MovieDTO>
            { 
                IsSuccessed = response.IsSuccessed,
                Errores = response.Errores,
                Data = response.Data is null ? null : new MovieDTO
                {
                    Id = response.Data.Id,
                    Title = response.Data.Title,
                    Description = response.Data.Description,
                    Poster = response.Data.Poster,
                    Rating = response.Data.Rating,
                    ProductionYear = response.Data.ProductionYear,
                    ClassificationID =  response.Data.Classification is null ? null : response.Data.Classification.Id ,
                    ClassificationName = response.Data.Classification is null ? null : response.Data.Classification.Name
                }  
            };  
        }

        public async Task<Response<MovieDTO>> UpdateMovie(int id , CreateMovie movie)
        {
            var classification = await classificationRepository.GetClassification(movie.ClassificationID);
            if (!classification.IsSuccessed) return new Response<MovieDTO> { Errores = classification.Errores };
            using var memoryStream = new MemoryStream();
            await movie.Poster.CopyToAsync( memoryStream );
            var response = await moviesRepository.UpdateMovie(id , movie , memoryStream.ToArray());
            return new Response<MovieDTO>
            { 
                IsSuccessed = response.IsSuccessed,
                Errores = response.Errores,
                Data = response.Data is null ? null : new MovieDTO
                {
                    Id = response.Data.Id,
                    Title = response.Data.Title,
                    Description = response.Data.Description,
                    Poster = response.Data.Poster,
                    Rating = response.Data.Rating,
                    ProductionYear = response.Data.ProductionYear,
                    ClassificationID =  response.Data.Classification is null ? null : response.Data.Classification.Id ,
                    ClassificationName = response.Data.Classification is null ? null : response.Data.Classification.Name
                }  
            };  
        }

    }
}