using Azure.Core;
using CinemaSolution.Application.Account;
using CinemaSolution.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CinemaSolution.AdminWebApplication.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            try
            {
                request.RoleRequest = "Administrator";
                var result = await _accountService.Login(request);

                // Set claims
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, result.Id.ToString()),
                        new Claim(ClaimTypes.Name, $"{result.FirstName} {result.LastName}"),
                        new Claim(ClaimTypes.Role, result.Role),
                        new Claim(ClaimTypes.Email, result.Email),
                    };
                var claimsIdentity = new ClaimsIdentity(claims, "CookieAuthentication");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync("CookieAuthentication", claimsPrincipal);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(request);
            }
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("CookieAuthentication");
            return RedirectToAction("Login");
        }

        [HttpGet("forgot-password")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpGet("access-denied")]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
