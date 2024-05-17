using System.Net;

namespace LogisticsAPI.Response
{
    public interface IDataResponse<T> where T : class
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public HttpStatusCode Status { get; set; }
    }
}
