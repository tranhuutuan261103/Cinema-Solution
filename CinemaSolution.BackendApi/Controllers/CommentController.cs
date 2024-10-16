﻿using CinemaSolution.Application.Comment;
using CinemaSolution.ViewModels.Comment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetAll([FromQuery] int movieId)
        {
            try
            {
                var user = User.FindFirst(ClaimTypes.NameIdentifier);
                if (user != null)
                {
                    return Ok(await _commentService.GetAll(movieId, int.Parse(user.Value)));
                }
                var comments = await _commentService.GetAll(movieId);
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
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var comment = await _commentService.Create(userId, request);
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
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var comment = await _commentService.Like(userId, commentId);
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
