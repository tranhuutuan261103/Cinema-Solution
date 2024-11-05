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

        [HttpPost("{id}/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                int effected = await _userService.UpdateUserStatus(id, true);
                if (effected == 0)
                {
                    TempData["Error"] = "Delete user failed";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Success"] = "Delete user successful";
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index");
            }
        }

        [HttpPost("{id}/enable")]
        public async Task<IActionResult> Enable(int id)
        {
            try
            {
                int effected = await _userService.UpdateUserStatus(id, false);
                if (effected == 0)
                {
                    TempData["Error"] = "Enable user failed";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Success"] = "Enable user successful";
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index");
            }
        }
    }
}
