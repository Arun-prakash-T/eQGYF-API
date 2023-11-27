using eQERPGYF_WebAPI;
using eQERPGYF_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//var dbhost = "148.66.134.164";
//var dbname = "eQGYF_API_QA";
//var dbpassword = "eQaeqa0!2345";
//var connectionstring = $"Data Source={dbhost};Initial Catalog={dbname};User ID=sa;Password={dbpassword};Encrypt=True;TrustServerCertificate=True;";
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddDbContext<CoreDbContext>(opt => opt.UseSqlServer(connectionstring));
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

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.Run();










