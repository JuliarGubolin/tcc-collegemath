using CollegeMath.Application.Helpers;
using CollegeMath.Configurations;
using CollegeMath.Infra.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var connectionString = builder.Configuration.GetConnectionString("CollegeMathConnection");
//builder.Services.AddDbContext<CollegeMathContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddIdentityConfig(builder.Configuration);

builder.Services.AddDependencyInjection();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
