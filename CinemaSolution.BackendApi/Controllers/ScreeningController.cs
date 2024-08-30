using CinemaSolution.Application.Cinema;
using CinemaSolution.Application.Screening;
using Microsoft.AspNetCore.Mvc;

namespace CinemaSolution.BackendApi.Controllers
{
    [ApiController]
    [Route("api/screenings")]
    public class ScreeningController : Controller
    {
        private readonly ICinemaService _cinemaService;
        private readonly IScreeningService _screeningService;
        private readonly ILogger<ScreeningController> _logger;
        public ScreeningController(ICinemaService cinemaService, IScreeningService screeningService, ILogger<ScreeningController> logger)
        {
            _cinemaService = cinemaService;
            _screeningService = screeningService;
            _logger = logger;
        }

        [HttpGet("movie/{movieId}")]
        public async Task<IActionResult> Index(int movieId, [FromQuery] int provinceId, [FromQuery] DateTime startDate)
        {
            if (startDate == default)
            {
                startDate = DateTime.Now;
            }
            var screenings = await _cinemaService.GetScreeningsByMovieId(movieId, provinceId, startDate);
            return Ok(screenings);
        }

        [HttpGet("auditorium/{auditoriumId}")]
        public async Task<IActionResult> Index(int auditoriumId, [FromQuery] DateTime startDate)
        {
            if (startDate == default)
            {
                startDate = DateTime.Now;
            }
            var screenings = await _cinemaService.GetScreeningsByAuditoriumId(auditoriumId, startDate);
            return Ok(screenings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetScreeningById(int id)
        {
            var screening = await _screeningService.GetScreeningById(id);
            return Ok(screening);
        }
    }
}
