using WorkerComRefit.Extensions;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.Injection(builder.Configuration);

var host = builder.Build();
host.Run();
