namespace RequestPipeline.Middleware;

public class SimpleLoggingMiddleware(RequestDelegate next, ILogger<SimpleLoggingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        logger.LogInformation("--> Requisição iniciando: {Method} {Path}", context.Request.Method, context.Request.Path);
        await next(context);
        logger.LogInformation("<-- Requisição finalizada: {StatusCode}", context.Response.StatusCode);
    }
}
