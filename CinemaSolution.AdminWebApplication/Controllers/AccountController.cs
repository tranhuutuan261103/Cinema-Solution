using Azure.Core;
using CinemaSolution.Application.Account;
using CinemaSolution.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost("register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            if (request.IsAcceptRule == false)
            {
                ModelState.AddModelError("", "You must accept the rules");
                return View(request);
            }
            try
            {
                var result = await _accountService.Register(request);

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
            } catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(request);
            }
        }

        [HttpGet("profile")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Profile()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login");
            }
            var profile = await _accountService.GetProfile(int.Parse(userId));
            var request = new UpdateProfileRequest
            {
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Email = profile.Email,
                PhoneNumber = profile.PhoneNumber ?? "",
                Address = profile.Address ?? "",
            };
            return View(request);
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
