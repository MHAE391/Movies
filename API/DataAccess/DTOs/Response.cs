namespace API.DataAccess.DTOs
{
    public class Response<T> where T : class
    {
        public bool IsSuccessed {set; get;}
        public IEnumerable<string>? Errores {set; get;} = null;

        public T? Data {set; get;}
    }
}