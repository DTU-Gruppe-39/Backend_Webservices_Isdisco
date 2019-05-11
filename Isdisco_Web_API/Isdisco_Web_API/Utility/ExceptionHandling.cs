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

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try 
            {
                await _next(httpContext);
            }
            catch (APIException exception)
            {
                if (httpContext.Response.HasStarted)
                {
                    logger.LogWarning("response sended, http status code will not be executed");
                    throw;
                }
                httpContext.Response.Clear();
                httpContext.Response.StatusCode = exception.StatusCode;
                await httpContext.Response.WriteAsync(exception.Message);

                return;
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlingExtensions
    {
        public static IApplicationBuilder UseCustomAPIExceptionHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandling>();
        }
    }
}
