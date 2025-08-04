var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<TaskServiceSingleton>();
builder.Services.AddScoped<TaskServiceScoped>();
builder.Services.AddTransient<TaskServiceTransient>();

var app = builder.Build();

app.MapPost("/singleton", (TaskServiceSingleton service, TaskServiceSingleton service2) =>
{
    return Results.Ok($"Requisi��o processada por um Singleton. Tempo de vida da inst�ncia");
});

app.MapPost("/scoped", (TaskServiceScoped service, TaskServiceScoped service2) =>
{

    return Results.Ok($"Requisi��o processada por um Scoped");
});

app.MapPost("/transient", (TaskServiceTransient service, TaskServiceTransient service2) =>
{
    return Results.Ok($"Requisi��o processada por um Transient");
});

app.Run();