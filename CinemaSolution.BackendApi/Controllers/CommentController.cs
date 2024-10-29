using CinemaSolution.Application.Comment;
using CinemaSolution.ViewModels.Comment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace CinemaSolution.BackendApi.Controllers
{
    [ApiController]
    [Route("api/comments")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly ILogger<CommentController> _logger;

        public CommentController(ICommentService commentService, ILogger<CommentController> logger)
        {
            _commentService = commentService;
            _logger = logger;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll([FromQuery] int movieId, int maxSize = 10)
        {
            try
            {
                var user = User.FindFirst(ClaimTypes.NameIdentifier);
                if (user != null)
                {
                    return Ok(await _commentService.GetAll(movieId, maxSize, int.Parse(user.Value)));
                }
                var comments = await _commentService.GetAll(movieId, maxSize);
                return Ok(comments);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting comments");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Create(CommentCreateRequest request)
        {
            try
            {
                var userId = HttpContext.Items["UserId"] as string;
                if (string.IsNullOrEmpty(userId))
                {
                    return BadRequest("User not found.");
                }
                var comment = await _commentService.Create(int.Parse(userId), request);
                return Ok(comment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating comment");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{commentId}/like")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Like(int commentId)
        {
            try
            {
                var userId = HttpContext.Items["UserId"] as string;
                if (string.IsNullOrEmpty(userId))
                {
                    return BadRequest("User not found.");
                }
                var comment = await _commentService.Like(int.Parse(userId), commentId);
                return Ok(comment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error liking comment");
                return BadRequest(ex.Message);
            }
        }
    }
}
