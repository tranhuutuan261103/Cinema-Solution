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
                            Address = user.Address,
                            AvatarUrl = user.AvatarUrl,
                            BackgroundUrl = user.BackgroundUrl,
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

        public async Task<AccountViewModel> Register(RegisterRequest request)
        {
            try
            {
                if (request.Password != request.ConfirmPassword)
                {
                    throw new Exception("Password and Confirm Password do not match.");
                }
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == request.Username);
                if (user != null)
                {
                    throw new Exception("Username is already taken.");
                }
                var role = await _context.Roles.FirstOrDefaultAsync(x => x.Name == request.RoleRequest);
                if (role == null)
                {
                    throw new Exception("Role not found.");
                }
                var newUser = new Data.Entities.User
                {
                    Username = request.Username,
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    PhoneNumber = request.PhoneNumber,
                    Address = request.Address,
                };
                GeneratePassword generate = new GeneratePassword(request.Password);
                newUser.PasswordSalt = generate.GetSalt();
                newUser.PasswordHash = generate.GetPasswordHash();
                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();
                _context.UsersInRoles.Add(new Data.Entities.UserInRole
                {
                    UserId = newUser.Id,
                    RoleId = role.Id,
                });
                await _context.SaveChangesAsync();
                return new AccountViewModel
                {
                    Id = newUser.Id,
                    Username = newUser.Username,
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    Email = newUser.Email,
                    Role = role.Name,
                };
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AccountViewModel> GetProfile(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            var roles = await _context.UsersInRoles
                .Join(_context.Roles, u => u.RoleId, r => r.Id, (u, r) => new { u, r })
                .Where(x => x.u.UserId == user.Id)
                .Select(x => new { x.r })
                .ToListAsync();
            foreach (var role in roles)
            {
                return new AccountViewModel
                {
                    Id = user.Id,
                    Username = user.Username,
                    Role = role.r.Name,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Address = user.Address,
                    AvatarUrl = user.AvatarUrl,
                };
            }
            throw new Exception("User has no role.");
        }

        public async Task<AccountViewModel> UpdateAvatar(int userId, string avatarUrl)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            user.AvatarUrl = avatarUrl;
            await _context.SaveChangesAsync();
            return new AccountViewModel
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                AvatarUrl = user.AvatarUrl,
            };
        }
    }
}
