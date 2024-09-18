using Cerberus.API.Interfaces;
using Cerberus.API.Repository;
using Cerberus.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString)));

//Repository
#region
builder.Services.AddScoped<IVictimRepository, VictimRepository>();
#endregion

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
