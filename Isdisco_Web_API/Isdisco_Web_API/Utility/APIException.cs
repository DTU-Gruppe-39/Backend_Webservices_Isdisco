using System;
using System.Net;

namespace Isdisco_Web_API.Utility
{
    public class APIException : Exception
    {
        public int StatusCode { get; set; }
        public string Type { get; set; } = @"text/plain";

        public APIException(int statusCode)
        {
            this.StatusCode = statusCode;
        }

        public APIException(int statusCode, string message) : base(message)
        {
            this.StatusCode = statusCode;
        }

        public APIException(int statusCode, Exception inner) : this(statusCode, inner.ToString()) 
        { 
            
        }

        public APIException(int statusCode, Newtonsoft.Json.Linq.JObject errorObject) : this(statusCode, errorObject.ToString())
        {
            this.Type = @"application/json";
        }
    }
}
