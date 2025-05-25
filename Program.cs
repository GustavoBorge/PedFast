using Microsoft.EntityFrameworkCore;
using Pedfast.Features.Extensions;
using Pedfast.Entities;
using Pedfast.Features.Status;

var builder = WebApplication.CreateBuilder(args);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurac�o String Conex�o
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<PedfastDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Service
builder.Services.AddScoped<StatusService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Mapeamento das rotas 
app.MapAllRoutes();

app.Run();