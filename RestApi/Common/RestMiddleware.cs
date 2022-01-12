using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            if (!httpContext.Response.StatusCode.Equals(StatusCodes.Status200OK) || !httpContext.Response.StatusCode.Equals(StatusCodes.Status201Created))
                await _next(httpContext);

            else
                await (_next(httpContext));
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
