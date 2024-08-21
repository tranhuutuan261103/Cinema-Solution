using CinemaSolution.AdminWebApplication.Filters;
using CinemaSolution.AdminWebApplication.Models;
using CinemaSolution.Application.Movie;
using CinemaSolution.Application.Screening;
using CinemaSolution.Application.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CinemaSolution.AdminWebApplication.Controllers
{
    [SetBarActive("home")]
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IScreeningService _screeningService;
        private readonly IUserService _userService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IMovieService movieService, IScreeningService screeningService, IUserService userService, ILogger<HomeController> logger)
        {
            _movieService = movieService;
            _screeningService = screeningService;
            _userService = userService;
            _logger = logger;
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.GetMovieOnGoing();
            ViewBag.Movies = movies;
            ViewBag.MovieCount = movies.Count();

            var screenings = await _screeningService.GetAll();
            ViewBag.Screenings = screenings;
            ViewBag.ScreeningCount = screenings.Count();
            ViewBag.ScreeningFuture = screenings.Where(x => x.StartDate >= DateTime.Now).Count();

            var userCount = await _userService.GetCount();
            ViewBag.UserCount = userCount;
            var userCustomerCount = await _userService.GetCount(2);
            ViewBag.UserCustomerCount = userCustomerCount;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}