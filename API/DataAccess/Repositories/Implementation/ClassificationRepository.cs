namespace API.DataAccess.Repositories.Implementation
{
    public class ClassificationRepository(ApplicationDbContext context) : IClassificationRepository
    {
        public async Task<Response<Classification>> CreateClassification(CreateClassification classification)
        {
            var oldClassification = await GetClassificationWithName(classification.ClassificationName);
            if(oldClassification.IsSuccessed)
            {
                var newClassification = new Classification { Name = classification.ClassificationName}; 
                await context.Classifications.AddAsync( newClassification );
                await context.SaveChangesAsync();
                return new Response<Classification> 
                {
                    IsSuccessed = true,
                    Data = newClassification
                };
            }
            return oldClassification;
        }

        public  async Task<Response<Classification>> DeleteClassification(int id)
        {
            var classification = await GetClassification(id);
            if(!classification.IsSuccessed) return classification;
            if(classification.Data!.Movies.Count() > 0) return new Response<Classification>{ Errores = new List<string> {"Can't Delete Classification Has Moviess!!"} , Data = classification.Data};
            context.Classifications.Remove(classification.Data!);
            await context.SaveChangesAsync();
            return classification;
        }

        public async Task<Response<IEnumerable<Classification>>> GetClassifications()
        {
            var classifications = await context.Classifications.ToListAsync();
            return new Response<IEnumerable<Classification>>
            {
                IsSuccessed = true,
                Data = classifications
            };
        }

        public async Task<Response<Classification>> GetClassification(int id)
        {
            var classification = await context.Classifications.FirstOrDefaultAsync(x => x.Id == id);
            return new Response<Classification> 
            { 
                IsSuccessed = classification is not null ,
                Data = classification ,
                Errores = classification is null ? new List<string> {$" No Classification with Id : {id}"} : null
            };
        }

        public async Task<Response<Classification>> UpdateClassification(int id , string name)
        {
            var oldClassificationWithId = await GetClassification(id);
            if(!oldClassificationWithId.IsSuccessed) return oldClassificationWithId;
            var oldClassificationWithName = await GetClassificationWithName(name);
            if(!oldClassificationWithName.IsSuccessed) return oldClassificationWithName;
            oldClassificationWithId.Data!.Name = name;
            context.Classifications.Update(oldClassificationWithId.Data);
            await context.SaveChangesAsync();
            return new Response<Classification> {IsSuccessed = true , Data = oldClassificationWithId.Data };
        }

        private async Task<Response<Classification>> GetClassificationWithName (string name)
        {
            var classification = await context.Classifications.FirstOrDefaultAsync(x => x.Name == name);
            return new Response<Classification> 
            { 
                IsSuccessed = classification is null ,
                Data = classification ,
                Errores = classification is not null ? new List<string> {$" Classification with Name: {name} Already Exist"} : null
            };
        }
    }
}