using CinemaSolution.AdminWebApplication.Filters;
using CinemaSolution.Application.Auditorium;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaSolution.AdminWebApplication.Controllers
{
    [Route("cinemas/{cinemaId}/auditoriums")]
    [Authorize(Roles = "Administrator")]
    [SetBarActive("cinemas")]
    public class AuditoriumController : Controller
    {
        private readonly IAuditoriumService _auditoriumService;

        public AuditoriumController(IAuditoriumService auditoriumService)
        {
            _auditoriumService = auditoriumService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index(int cinemaId)
        {
            var auditoriums = await _auditoriumService.GetByCinemaId(cinemaId);
            ViewBag.CinemaId = cinemaId;
            return View(auditoriums);
        }

        [HttpPost("{auditoriumId}/delete")]
        public async Task<IActionResult> Delete(int cinemaId, int auditoriumId)
        {
            await _auditoriumService.Delete(auditoriumId);
            return RedirectToAction("Index", new { cinemaId });
        }
    }
}
