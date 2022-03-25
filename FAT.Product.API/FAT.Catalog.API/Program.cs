using FAT.Catalog.API.Configuration;
using FAT.Core.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApiConfiguration(builder.Configuration);

builder.Services.AddJwtConfiguration(builder.Configuration);

builder.Services.AddSwaggerConfiguration();

builder.Services.RegisterServices();

var app = builder.Build();

app.UseApiConfiguration(app.Environment);

app.UseSwaggerConfiguration();

app.Run();
