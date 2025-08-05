namespace RequestPipeline.Middleware;

public class SecurityMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.ContainsKey("X-My-Secret-Header"))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Acesso não autorizado. Header 'X-My-Secret-Header' ausente.");
            return;
        }

        await next(context);
    }
}
