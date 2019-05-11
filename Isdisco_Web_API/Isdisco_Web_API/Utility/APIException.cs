using System;
using System.Net;

namespace Isdisco_Web_API.Utility
{
    public class APIException
    {
        private HttpStatusCode StatusCode { get; set; }
        private string Type { get; set; } = @"text/plain";

        public APIException(HttpStatusCode statusCode)
        {
            this.StatusCode = statusCode;
        }

        public APIException(HttpStatusCode statusCode, string message) : base(message)
        {
            this.StatusCode = statusCode;
        }

        public APIException(HttpStatusCode statusCode, Exception inner) : this(statusCode, inner.ToString()) 
        { 
            
        }

        public APIException(HttpStatusCode statusCode, Newtonsoft.Json.Linq.JObject errorObject) : this(statusCode, errorObject.ToString())
        {
            this.Type = @"application/json";
        }
    }
}
