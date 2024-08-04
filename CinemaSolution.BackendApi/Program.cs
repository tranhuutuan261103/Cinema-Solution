using CinemaSolution.Application.Category;
using CinemaSolution.Application.Movie;
using CinemaSolution.Application.Province;
using CinemaSolution.Data.EF;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("CinemaSolutionDB");
builder.Services.AddDbContext<CinemaDBContext>(options => options.UseSqlServer(connectionString));

// Inject Services
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient<IProvinceService, ProvinceService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
