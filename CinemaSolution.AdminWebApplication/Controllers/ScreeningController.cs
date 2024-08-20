using CinemaSolution.AdminWebApplication.Filters;
using CinemaSolution.Application.Auditorium;
using CinemaSolution.Application.Movie;
using CinemaSolution.Application.Screening;
using CinemaSolution.Data.Entities;
using CinemaSolution.ViewModels.Auditorium;
using CinemaSolution.ViewModels.Screening;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaSolution.AdminWebApplication.Controllers
{
    [Route("screenings")]
    [Authorize(Roles = "Administrator")]
    [SetBarActive("screening")]
    public class ScreeningController : Controller
    {
        private readonly IScreeningService _screeningService;
        private readonly IMovieService _movieService;
        private readonly IAuditoriumService _auditoriumService;
        public ScreeningController(IScreeningService screeningService, IMovieService movieService, IAuditoriumService auditoriumService)
        {
            _screeningService = screeningService;
            _movieService = movieService;
            _auditoriumService = auditoriumService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index(int PageIndex = 1, int PageSize = 5, int? movieId = null, int? auditoriumId = null)
        {
            var request = new GetScreeningPagingRequest
            {
                PageIndex = PageIndex,
                PageSize = PageSize,
                MovieId = movieId,
                AuditoriumId = auditoriumId
            };
            var screenings = await _screeningService.GetPagedResult(request);
            if (auditoriumId != null)
            {
                ViewBag.AuditoriumId = auditoriumId;
            }
            return View(screenings);
        }

        [HttpGet("create")]
        public async Task<IActionResult> Create(int auditoriumId)
        {
            var movies = await _movieService.GetMovieOnGoing();
            ViewBag.Movies = movies;

            var auditorium = await _auditoriumService.GetById(auditoriumId);

            var seats = new List<SeatDefaultViewModel>();
            int[] seatMapVector = auditorium.SeatMapVector.Select(c => int.Parse(c.ToString())).ToArray();
            for (int i = 0; i < auditorium.SeatsPerRow; i++)
            {
                for (int j = 0; j < auditorium.SeatsPerColumn; j++)
                {
                    seats.Add(new SeatDefaultViewModel
                    {
                        Row = i + 1,
                        Column = j + 1,
                        TypeId = seatMapVector[i * auditorium.SeatsPerColumn + j]
                    });
                }
            }
            var request = new ScreeningCreateRequest()
            {
                Auditorium= auditorium,
                SeatDefaults = seats,
                StartDate = DateTime.Now.AddDays(1),
            };

            return View(request);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(ScreeningCreateRequest request)
        {
            if (request.MovieId == 0 || request.Auditorium.Id == 0)
            {
                var movies = await _movieService.GetMovieOnGoing();
                ViewBag.Movies = movies;
                return View(request);
            }
            var result = await _screeningService.Create(request);
            if (result.Id != 0)
            {
                TempData["SuccessMessage"] = "Screening created successfully";
                return RedirectToAction("Index", request.Auditorium.Id);
            }
            else
            {
                TempData["ErrorMessage"] = "Screening created failed";
                return View(request);
            }
        }

        [HttpGet("{id}/update")]
        public async Task<IActionResult> Update(int id)
        {
            var screening = await _screeningService.GetScreeningById(id);
            var movies = await _movieService.GetMovieOnGoing();
            ViewBag.Movies = movies;

            if (screening.Auditorium == null || screening.Movie == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.MovieId = screening.Movie.Id;
            ViewBag.MovieName = screening.Movie.Title;

            var auditorium = await _auditoriumService.GetById(screening.Auditorium.Id);

            var seats = new List<SeatDefaultViewModel>();
            int[] seatMapVector = auditorium.SeatMapVector.Select(c => int.Parse(c.ToString())).ToArray();
            for (int i = 0; i < auditorium.SeatsPerRow; i++)
            {
                for (int j = 0; j < auditorium.SeatsPerColumn; j++)
                {
                    seats.Add(new SeatDefaultViewModel
                    {
                        Row = i + 1,
                        Column = j + 1,
                        TypeId = seatMapVector[i * auditorium.SeatsPerColumn + j]
                    });
                }
            }

            var request = new ScreeningUpdateRequest()
            {
                Id = screening.Id,
                StartDate = screening.StartDate,
                StartTime = screening.StartTime,
                SeatDefaults = seats,
                Auditorium = auditorium,
                MovieId = screening.Movie.Id
            };

            return View(request);
        }

        [HttpPost("{id}/update")]
        public async Task<IActionResult> Update(ScreeningUpdateRequest request)
        {
            if (request.MovieId == 0 || request.Auditorium.Id == 0)
            {
                var movies = await _movieService.GetMovieOnGoing();
                ViewBag.Movies = movies;
                return View(request);
            }

            var result = await _screeningService.Update(request);
            if (result.Id != 0)
            {
                TempData["SuccessMessage"] = "Screening updated successfully";
                return RedirectToAction("Index", request.Auditorium.Id);
            }
            else
            {
                TempData["ErrorMessage"] = "Screening updated failed";
                return View(request);
            }
        }

        [HttpPost("{id}/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _screeningService.Delete(id);
            if (result > 0)
            {
                TempData["SuccessMessage"] = "Screening deleted successfully";
            }
            else
            {
                TempData["ErrorMessage"] = "Screening deleted failed";
            }
            return RedirectToAction("Index");
        }
    }
}
