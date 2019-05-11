using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Isdisco_Web_API.Utility
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandling
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<APIException> logger;

        public ExceptionHandling(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            /*try 
            {
                await _next(httpContext);
            }
            catch (APIException exception)
            {
                if (httpContext.Response.HasStarted)
                {
                    logger.LogWarning();
                    throw;
                }
                httpContext.Response.Clear();
                httpContext.Response.StatusCode = exception.StatusCode;
            }*/
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlingExtensions
    {
        public static IApplicationBuilder UseMiddlewareClassTemplate(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandling>();
        }
    }
}
