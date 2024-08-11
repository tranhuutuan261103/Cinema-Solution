using CinemaSolution.AdminWebApplication.Filters;
using CinemaSolution.Application.User;
using CinemaSolution.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaSolution.AdminWebApplication.Controllers
{
    [Route("users")]
    [Authorize(Roles = "Administrator")]
    [SetBarActive("user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 5, int? roleId = null,string? keyword = null)
        {
            var request = new GetUserPagingRequest()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                RoleId = roleId,
                Keyword = keyword
            };

            if (roleId.HasValue)
            {
                ViewData["RoleId"] = roleId;
            }

            var users = await _userService.GetPagedResult(request);
            return View(users);
        }
    }
}
