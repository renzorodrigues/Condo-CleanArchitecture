using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace Condominio.Core.Helpers
{
    public class CustomResult
    {
        public HttpStatusCode StatusCode { get; set; } = new HttpResponseMessage().StatusCode;
        public bool IsSuccess { get; set; } = new HttpResponseMessage().IsSuccessStatusCode;
        public List<Error> Errors { get; set; }
        public string Message { get; set; }
    }

    public class Error
    {
        public string Message { get; private set; }

        public Error(string errorMessage)
        {
            this.Message = errorMessage;
        }
    }
}
