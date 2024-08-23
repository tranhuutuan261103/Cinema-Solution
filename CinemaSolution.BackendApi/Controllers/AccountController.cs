using CinemaSolution.Application.Account;
using CinemaSolution.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using CinemaSolution.Application.Storage;

namespace CinemaSolution.BackendApi.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IStorageService _storageService;
        private readonly ILogger<AccountController> _logger;
        public AccountController(IAccountService accountService, IStorageService storageService, ILogger<AccountController> logger)
        {
            _accountService = accountService;
            _storageService = storageService;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest rquest)
        {
            try
            {
                var user = await _accountService.Login(rquest);
                if (user == null)
                {
                    return BadRequest("User not found.");
                }
                var token = GenerateToken(user);
                return Json(new { token });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            try
            {
                request.RoleRequest = "Customer";
                var user = await _accountService.Register(request);
                if (user == null)
                {
                    return BadRequest("Register failed.");
                }
                var token = GenerateToken(user);
                return Json(new { token });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("profile")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Profile()
        {
            try
            {
                var userId = HttpContext.Items["UserId"] as string;
                if (string.IsNullOrEmpty(userId))
                {
                    return BadRequest("User ID not found.");
                }
                var user = await _accountService.GetProfile(int.Parse(userId));
                if (user == null)
                {
                    return BadRequest("User not found.");
                }
                return Json(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("avatar")]
        [Authorize(Roles = "Customer")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateAvatar([FromForm] AvatarRequest request)
        {
            try
            {
                if (request.Avatar == null)
                {
                    return BadRequest("Avatar is required.");
                }
                var userId = HttpContext.Items["UserId"] as string;
                if (string.IsNullOrEmpty(userId))
                {
                    return BadRequest("User ID not found.");
                }
                var avatarUrl = await _storageService.UploadFileAsync(
                    request.Avatar.OpenReadStream(),
                    "user_avatar",
                    request.Avatar.FileName);
                var user = await _accountService.UpdateAvatar(int.Parse(userId), avatarUrl);
                if (user == null)
                {
                    return BadRequest("User not found.");
                }
                return Json(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        private static string GenerateToken(AccountViewModel user)
        {
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("MIICWwIBAAKBgHZO8IQouqjDyY47ZDGdw9jPDVHadgfT1kP3igz5xamdVaYPHaN24UZMeSXjW9sWZzwFVbhOAGrjR0MM6APrlvv5mpy67S/K4q4D7Dvf6QySKFzwMZ99Qk10fK8tLoUlHG3qfk9+85LhL/Rnmd9FD7nz8+cYXFmz5LIaLEQATdyNAgMBAAECgYA9ng2Md34IKbiPGIWthcKb5/LC/+nbV8xPp9xBt9Dn7ybNjy/blC3uJCQwxIJxz/BChXDIxe9XvDnARTeN2yTOKrV6mUfI+VmON5gTD5hMGtWmxEsmTfu3JL0LjDe8Rfdu46w5qjX5jyDwU0ygJPqXJPRmHOQW0WN8oLIaDBxIQQJBAN66qMS2GtcgTqECjnZuuP+qrTKL4JzG+yLLNoyWJbMlF0/HatsmrFq/CkYwA806OTmCkUSm9x6mpX1wHKi4jbECQQCH+yVb67gdghmoNhc5vLgnm/efNnhUh7u07OCL3tE9EBbxZFRs17HftfEcfmtOtoyTBpf9jrOvaGjYxmxXWSedAkByZrHVCCxVHxUEAoomLsz7FTGM6ufd3x6TSomkQGLw1zZYFfe+xOh2W/XtAzCQsz09WuE+v/viVHpgKbuutcyhAkB8o8hXnBVz/rdTxti9FG1b6QstBXmASbXVHbaonkD+DoxpEMSNy5t/6b4qlvn2+T6a2VVhlXbAFhzcbewKmG7FAkEAs8z4Y1uI0Bf6ge4foXZ/2B9/pJpODnp2cbQjHomnXM861B/C+jPW3TJJN2cfbAxhCQT2NhzewaqoYzy7dpYsIQ==");
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaims(user),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = credentials,
            };

            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }

        private static ClaimsIdentity GenerateClaims(AccountViewModel user)
        {
            // Set claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Email, user.Email),
            };

            return new ClaimsIdentity(claims);
        }
    }
}
