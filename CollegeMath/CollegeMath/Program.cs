using CollegeMath.Application.Applications;
using CollegeMath.Application.Interfaces;
using CollegeMath.Configurations;
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

builder.Services.AddIdentityConfig(builder.Configuration);

//Indicando ao c# por quem a interface está sendo implementada
//"Sempre que eu pedir uma IContentApplication me devolva sua implementação no ContentRepository"
builder.Services.AddScoped<IContentApplication, ContentApplication>();
builder.Services.AddScoped<IContentRepository, ContentRepository>();
//builder.Services.AddScoped<IUserApplication, UserApplication>();
//builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ILevelApplication, LevelApplication>();
builder.Services.AddScoped<ILevelRepository, LevelRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
