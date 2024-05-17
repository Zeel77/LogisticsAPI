using System.Net;

namespace LogisticsAPI.Response
{
    public class DataResponse<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public HttpStatusCode Status { get; set; }
        public DataResponse(T data, string msg, HttpStatusCode code) 
        {
            Data = data;
            Message = msg;
            Status=code;
        }
    }
}
