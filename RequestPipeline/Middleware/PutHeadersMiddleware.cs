namespace RequestPipeline.Middleware;

public class PutHeadersMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        context.Response.Headers.Append("X-Processed-By", "Header inserted by PutHeadersMiddleware");
        await next(context);
    }
}
