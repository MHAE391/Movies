namespace API.DataAccess.Repositories.Interfaces
{
    public interface IClassificationRepository
    {
        public Task<Response<Classification>> CreateClassification(CreateClassification classification);  
        public Task<Response<IEnumerable<Classification>>> GetClassifications();
        public Task<Response<Classification>> GetClassification(int id); 
        public Task<Response<Classification>> UpdateClassification(int id , string name);
        public Task<Response<Classification>> DeleteClassification(int id);
    }
}