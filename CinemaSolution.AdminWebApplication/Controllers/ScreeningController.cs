using CinemaSolution.AdminWebApplication.Filters;
using CinemaSolution.Application.Screening;
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
        public ScreeningController(IScreeningService screeningService)
        {
            _screeningService = screeningService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index(int PageIndex = 1, int PageSize = 5, int? movieId = null)
        {
            var request = new GetScreeningPagingRequest
            {
                PageIndex = PageIndex,
                PageSize = PageSize,
                MovieId = movieId
            };
            var screenings = await _screeningService.GetPagedResult(request);
            return View(screenings);
        }
    }
}
