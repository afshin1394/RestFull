using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Common
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RestMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RestMiddleware> _logger;

        public RestMiddleware(RequestDelegate next, ILogger<RestMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
           
            switch (httpContext.Response.StatusCode)
            {
                case StatusCodes.Status200OK:
                    break;
                case StatusCodes.Status400BadRequest:
                    break;
                case StatusCodes.Status404NotFound:
                    break;
                case StatusCodes.Status503ServiceUnavailable:
                    
                    break;
                case StatusCodes.Status504GatewayTimeout:
                    break;
            }
            

             await( _next(httpContext));
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RestMiddlewareExtensions
    {
        public static IApplicationBuilder UseRestMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RestMiddleware>();
        }
    }
}
