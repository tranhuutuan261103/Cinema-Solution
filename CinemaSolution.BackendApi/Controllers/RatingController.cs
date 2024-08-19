using CinemaSolution.Application.Rating;
using Microsoft.AspNetCore.Mvc;

namespace CinemaSolution.BackendApi.Controllers
{
    [ApiController]
    [Route("api/ratings")]
    public class RatingController : Controller
    {
        private readonly IRatingService _ratingService;
        private readonly ILogger<RatingController> _logger;
        public RatingController(IRatingService ratingService, ILogger<RatingController> logger)
        {
            _ratingService = ratingService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int movieId)
        {
            var ratings = await _ratingService.GetAllRatingCount(movieId);
            return Json(ratings);
        }
    }
}
