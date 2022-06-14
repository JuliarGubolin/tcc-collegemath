using CollegeMath.Application.Applications;
using CollegeMath.Application.Interfaces;
using CollegeMath.Infra.Context;
using CollegeMath.Infra.Interfaces;
using CollegeMath.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("CollegeMathConnection");
builder.Services.AddDbContext<CollegeMathContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IContentApplication, ContentApplication>();
builder.Services.AddScoped<IContentRepository, ContentRepository>();
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
