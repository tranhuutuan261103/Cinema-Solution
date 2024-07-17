using CinemaSolution.Common;
using CinemaSolution.Data.EF;
using CinemaSolution.ViewModels.Account;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Application.Account
{
    public class AccountService : IAccountService
    {
        private readonly CinemaDBContext _context;
        public AccountService(CinemaDBContext context)
        {
            _context = context;
        }

        public async Task<AccountViewModel> Login(LoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == request.Username);
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            GeneratePassword generate = new GeneratePassword(request.Password);
            if (generate.VerifyPassword(user.PasswordSalt, user.PasswordHash))
            {
                var roles = await _context.UsersInRoles
                    .Join(_context.Roles, u => u.RoleId, r => r.Id, (u, r) => new { u, r })
                    .Where(x => x.u.UserId == user.Id)
                    .Select(x => new { x.r })
                    .ToListAsync();

                foreach(var role in roles)
                {
                    if (role.r.Name == request.RoleRequest)
                    {
                        return new AccountViewModel
                        {
                            Id = user.Id,
                            Username = user.Username,
                            Role = role.r.Name,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                        };
                    }
                }
                throw new Exception("User has no role.");
            }
            else
            {
                throw new Exception("Password is incorrect.");
            }
        }
    }
}
