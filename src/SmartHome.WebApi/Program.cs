using SmartHome.WebApi.Modules.Sensors.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastucture(builder.Configuration);


var app = builder.Build();


app.Run();
