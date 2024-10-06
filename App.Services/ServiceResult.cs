using System.Net;
using System.Text.Json.Serialization;

namespace App.Services
{
    public class ServiceResult<T>
    {
        public T? Data { get; set; }
        public List<string>?  ErrorMessage { get; set; }
        [JsonIgnore]
        public bool IsSuccess => ErrorMessage == null || ErrorMessage.Count == 0;
        [JsonIgnore]
        public bool IsFail => !IsSuccess ;
        [JsonIgnore]
        public HttpStatusCode Status { get; set; }

        public static ServiceResult<T> Success(T data ,HttpStatusCode status=HttpStatusCode.OK)
        {
            return new ServiceResult<T>()
            {
                Data = data,
                Status=status
            };
        }
        //STATİC FACTORY metodlar
        public static ServiceResult<T> Fail(List<string> errorMesaage, HttpStatusCode status=HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T>()
            {
                ErrorMessage = errorMesaage,
                Status=status
            };
        }
        public static ServiceResult<T> Fail(string errorMesaage, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T>()
            {
                ErrorMessage = new List<string> { errorMesaage },     // VEYA BUDA OLABİLİR new List<string> {  errorMesaage }
                Status = status                  
            };
        }

    }




    public class ServiceResult
    {
        
        public List<string>? ErrorMessage { get; set; }
        [JsonIgnore]
        public bool IsSuccess => ErrorMessage == null || ErrorMessage.Count == 0;
        [JsonIgnore]
        public bool IsFail => !IsSuccess;
        [JsonIgnore]
        public HttpStatusCode Status { get; set; }

        public static ServiceResult Success( HttpStatusCode status = HttpStatusCode.OK)
        {
            return new ServiceResult()
            {
                
                Status = status
            };
        }
        //STATİC FACTORY metodlar
        public static ServiceResult Fail(List<string> errorMesaage, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult()
            {
                ErrorMessage = errorMesaage,
                Status = status
            };
        }
        public static ServiceResult Fail(string errorMesaage, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult()
            {
                ErrorMessage = new List<string> { errorMesaage },     // VEYA BUDA OLABİLİR new List<string> {  errorMesaage }
                Status = status
            };
        }

    }
}
