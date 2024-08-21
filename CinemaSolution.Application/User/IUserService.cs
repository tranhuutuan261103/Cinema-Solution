using CinemaSolution.ViewModels.Common.Paging;
using CinemaSolution.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Application.User
{
    public interface IUserService
    {
        Task<int> GetCount(int? roleId = null);
        Task<PagedResult<UserViewModel>> GetPagedResult(GetUserPagingRequest request);
    }
}
