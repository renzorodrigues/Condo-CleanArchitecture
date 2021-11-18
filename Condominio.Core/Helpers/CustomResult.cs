using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace Condominio.Core.Helpers
{
    public class CustomResult
    {
        public HttpStatusCode StatusCode { get; set; } = new HttpResponseMessage().StatusCode;
        public bool IsSuccess { get; set; } = new HttpResponseMessage().IsSuccessStatusCode;
        public List<Errors> Errors { get; set; }
        public string Message { get; set; }
    }

    public class Errors
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }

        public Errors(string propertyName, string errorMessage)
        {
            this.PropertyName = propertyName;
            this.ErrorMessage = errorMessage;
        }
    }
}
