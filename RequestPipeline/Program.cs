var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseMiddleware<SimpleLoggingMiddleware>();
app.UseMiddleware<SecurityMiddleware>();
app.UseMiddleware<PutHeadersMiddleware>();
app.MapGet("/hello", () => "Hello World!");
app.MapGet("/notfound", () => Results.StatusCode(400));

app.Run();