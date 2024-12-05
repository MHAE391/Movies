using Microsoft.Identity.Client;

namespace API.DataAccess.Repositories.Interfaces
{
    public interface IClassificationService
    {
        public Task<Response<ClassificationDTO>> CreateClassification (CreateClassification classification); 
        public Task<Response<IEnumerable<ClassificationDTO>>> GetClassifications ();    

        public Task<Response<ClassificationDTO>> GetClassification(int id);

        public Task<Response<ClassificationDTO>> DeleteClassification (int id);

        public Task<Response<ClassificationDTO>> UpdateClassification (int id , string name);
    }
}