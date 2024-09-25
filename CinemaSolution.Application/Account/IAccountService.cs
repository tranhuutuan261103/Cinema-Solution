using CinemaSolution.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Application.Account
{
    public interface IAccountService
    {
        Task<AccountViewModel> Login(LoginRequest request);
        Task<AccountViewModel> Register(RegisterRequest request);
        Task<AccountViewModel> GetProfile(int userId);
        Task<AccountViewModel> UpdateAvatar(int v, string avatarUrl);
        Task<AccountViewModel> UpdateBackground(int userId, string avatarUrl);
        Task<AccountViewModel> UpdateProfile(int userId, UpdateProfileRequest request);
    }
}
