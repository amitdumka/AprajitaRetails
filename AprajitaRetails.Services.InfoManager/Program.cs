using AprajitaRetails.Services.InfoManager;
using Microsoft.Extensions.Hosting;

//var builder = Host.CreateApplicationBuilder(args);
//builder.Services.AddHostedService<Worker>();

//var host = builder.Build();
//host.Run();


//var builder = Host.CreateApplicationBuilder(args);
//builder.Services.AddHostedService<Worker>();

//var host = builder.Build();
//host.Run();

var builder = Host.CreateApplicationBuilder(args);

//builder.Services.AddRazorPages();

builder.Services.AddWindowsService();
builder.Services.AddHostedService<Worker>();

builder.Services.AddHostedService<ServiceA>();
builder.Services.AddHostedService<TimedHostedService>();

builder.Services.AddHostedService<TimedHostedService2>();
builder.Services.AddHostedService<ConsumeScopedServiceHostedService>();
builder.Services.AddScoped<IScopedProcessingService, ScopedProcessingService>();

var app = builder.Build();

//app.MapRazorPages();

app.Run();

