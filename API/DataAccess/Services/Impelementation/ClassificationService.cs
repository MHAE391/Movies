namespace API.DataAccess.Services.Implementation
{
    public class ClassificationService(IClassificationRepository repository) : IClassificationService
    {
        public async Task<Response<ClassificationDTO>> CreateClassification(CreateClassification classification)
        {
            Response<Classification> repoResponse = await repository.CreateClassification(classification);
            return new Response<ClassificationDTO> 
            {
                IsSuccessed = repoResponse.IsSuccessed,
                Data = repoResponse.Data is null ? null :  new ClassificationDTO 
                {
                    Name = repoResponse.Data.Name,
                    Id = repoResponse.Data.Id,
                    ClassificationMovies = null
                },
                Errores = repoResponse.Errores
            };   
        }

        public async Task<Response<IEnumerable<ClassificationDTO>>> GetClassifications()
        {
            Response<IEnumerable<Classification>> classifications =  await repository.GetClassifications();
            return new Response<IEnumerable<ClassificationDTO>>
            {
                IsSuccessed = classifications.IsSuccessed,
                Data = classifications.Data?.Select ( x => new ClassificationDTO 
                {   Id = x.Id ,
                    Name = x.Name,
                    ClassificationMovies = x.Movies.Select ( y => new ClassificationMovie { Id = y.Id , Name = y.Title } )
                }),
                Errores = classifications.Errores 
            };
        }
        public async Task<Response<ClassificationDTO>> GetClassification(int id)
        {
            Response<Classification> classification =  await repository.GetClassification(id);
            return new Response<ClassificationDTO> 
            {
                IsSuccessed = classification.IsSuccessed,
                Data = classification.Data is null ? null : 
                new ClassificationDTO 
                {
                    Id =    classification.Data.Id,
                    Name = classification.Data.Name,
                    ClassificationMovies = classification.Data.Movies.Select( y => new ClassificationMovie { Id = y.Id , Name = y.Title } )
                },
                Errores = classification.Errores
            };
        } 
        public async Task<Response<ClassificationDTO>> DeleteClassification(int id)
        {
            var response =  await repository.DeleteClassification(id);
            return new Response<ClassificationDTO>
            { 
                IsSuccessed = response.IsSuccessed,
                Data = response.Data is null ? null : new ClassificationDTO
                {
                    Id =    response.Data.Id,
                    Name = response.Data.Name,
                    ClassificationMovies = response.Data.Movies.Select( y => new ClassificationMovie { Id = y.Id , Name = y.Title } )
                },
                Errores = response.Errores 
            };  
        }
        public async Task<Response<ClassificationDTO>> UpdateClassification (int id , string name)
        {
            var response = await repository.UpdateClassification(id,name);
              return new Response<ClassificationDTO>
            { 
                IsSuccessed = response.IsSuccessed,
                Data = response.Data is null ? null : new ClassificationDTO
                {
                    Id =    response.Data.Id,
                    Name = response.Data.Name,
                    ClassificationMovies = response.Data.Movies.Select( y => new ClassificationMovie { Id = y.Id , Name = y.Title } )
                },
                Errores = response.Errores 
            };  
        }

    }
}