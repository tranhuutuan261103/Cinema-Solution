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
    }
}
