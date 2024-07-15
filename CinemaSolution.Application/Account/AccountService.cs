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
        public async Task<int> Login(LoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == request.Username);
            if (user == null)
            {
                return -1;
            }
            GeneratePassword generate = new GeneratePassword(request.Password);
            if (generate.VerifyPassword(user.PasswordSalt, generate.GetPasswordHash()))
            {
                return -1;
            }
            return user.Id;
        }
    }
}
