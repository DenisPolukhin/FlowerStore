using FlowStoreBackend.API.ApplicationStart;
using FlowStoreBackend.Database.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCustomServices();

builder.Services.AddDbContextFactory<DatabaseContext>(options => options.UseNpgsql(builder.Configuration
    .GetConnectionString("DefaultConnection"), opt => opt.UseNodaTime()), ServiceLifetime.Scoped);

builder.Services.AddControllers();
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
