// https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-7.0

// Start
using Teste.Middleware.CustomMiddleware;
// 01 - Criar uma instancia de WebApplication Builder

var builder = WebApplication.CreateBuilder(args);

// Registrar Custom Middleware como Service
builder.Services.AddTransient<FirstMiddleware>();

// 02 - Criar uma instancia de WebApplication
var app = builder.Build();

// 03 - Criar Middleware
// Middleware Ex 01
app.Use(async(HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Middleware 01\n\n");
    await next(context);
});

// Middleware Ex 02
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Middleware 02\n\n");
    await next(context);
});

// Custom Middleware
// app.UseMiddleware<FirstMiddleware>(); // N�o Precisa caso aja uma Extension
// Extension Middleware
app.UseMyMiddleware();

// Second Custom Middleware
app.UseSecondMiddleware();

// Middleware Ex 03
app.UseWhen(context => context.Request.Query.ContainsKey("IsAuthorized")
            && context.Request.Query["IsAuthorized"] == "true",
    app =>
    {
        app.Use(async (context, next) =>
        {
            await context.Response.WriteAsync("Middleware 03\n\n");
            await next(context);
        });
    });

// Middleware Ex 04
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Middelware 04\n\n");
});

app.Run();
