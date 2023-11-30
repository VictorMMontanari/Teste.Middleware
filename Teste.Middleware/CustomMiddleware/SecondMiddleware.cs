using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Teste.Middleware.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class SecondMiddleware
    {
        private readonly RequestDelegate _next;

        public SecondMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.WriteAsync("Second Custom Middleware Start!\n\n");
            await _next(httpContext);
            httpContext.Response.WriteAsync("Second Custom Middleware End!\n\n");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class SecondMiddlewareExtensions
    {
        public static IApplicationBuilder UseSecondMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SecondMiddleware>();
        }
    }
}
