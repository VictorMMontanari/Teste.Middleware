namespace Teste.Middleware.CustomMiddleware
{
    public class FirstMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // Antes
            await context.Response.WriteAsync("Custom Middleware Start!\n\n");
            // Call next matter
            await next(context);
            // Depois
            await context.Response.WriteAsync("Custom Middleware End!\n\n");
        }
    }

    // Exetension
    public static class FirstMiddlewareExtension
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<FirstMiddleware>();
        }
    }
}
