var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<TaskServiceSingleton>();
builder.Services.AddScoped<TaskServiceScoped>();
builder.Services.AddTransient<TaskServiceTransient>();

var app = builder.Build();

app.MapPost("/singleton", async (TaskServiceSingleton service) =>
{
    await service.SimulateWorkAsync();
    return Results.Ok($"Requisição processada por um Singleton. Tempo de vida da instância: {service.GetLifetime()}ms");
});

app.MapPost("/scoped", async (TaskServiceScoped service) =>
{
    await service.SimulateWorkAsync();
    return Results.Ok($"Requisição processada por um Scoped. Tempo de vida da instância: {service.GetLifetime()}ms");
});

app.MapPost("/transient", async (TaskServiceTransient service) =>
{
    await service.SimulateWorkAsync();
    return Results.Ok($"Requisição processada por um Transient. Tempo de vida da instância: {service.GetLifetime()}ms");
});

app.Run();