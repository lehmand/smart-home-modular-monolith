using SmartHome.WebApi.Modules.Sensors.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddInfrastucture(builder.Configuration);

app.Run();
