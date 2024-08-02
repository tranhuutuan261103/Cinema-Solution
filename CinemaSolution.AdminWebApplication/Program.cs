using CinemaSolution.Application.Account;
using CinemaSolution.Application.Auditorium;
using CinemaSolution.Application.Category;
using CinemaSolution.Application.Cinema;
using CinemaSolution.Application.Movie;
using CinemaSolution.Application.Province;
using CinemaSolution.Application.Screening;
using CinemaSolution.Application.Storage;
using CinemaSolution.Data.EF;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("CinemaSolutionDB");
builder.Services.AddDbContext<CinemaDBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IAuditoriumService, AuditoriumService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ICinemaService, CinemaService>();
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient<IStorageService, StorageService>();
builder.Services.AddTransient<IProvinceService, ProvinceService>();
builder.Services.AddTransient<IScreeningService, ScreeningService>();

builder.Services.AddAuthentication("CookieAuthentication")
    .AddCookie("CookieAuthentication", config =>
    {
        config.Cookie.Name = "CinemaSolution.Cookie";
        config.LoginPath = "/Account/Login";
        config.AccessDeniedPath = "/Account/AccessDenied";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
