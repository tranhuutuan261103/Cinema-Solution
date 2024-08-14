using CinemaSolution.Application.Cinema;
using Microsoft.AspNetCore.Mvc;

namespace CinemaSolution.BackendApi.Controllers
{
    [ApiController]
    [Route("api/screenings")]
    public class ScreeningController : Controller
    {
        private readonly ICinemaService _cinemaService;
        private readonly ILogger<ScreeningController> _logger;
        public ScreeningController(ICinemaService cinemaService, ILogger<ScreeningController> logger)
        {
            _cinemaService = cinemaService;
            _logger = logger;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index(int provinceId, DateTime startDate)
        {
            var screenings = await _cinemaService.GetScreeningsByProvinceId(provinceId, startDate);
            return Ok(screenings);
        }
    }
}
