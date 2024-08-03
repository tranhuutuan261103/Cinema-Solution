using CinemaSolution.ViewModels.Common.Paging;
using CinemaSolution.ViewModels.Screening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Application.Screening
{
    public interface IScreeningService
    {
        Task<PagedResult<ScreeningViewModel>> GetPagedResult(GetScreeningPagingRequest request);
        Task<ScreeningViewModel> Create(ScreeningCreateRequest request);
        Task<int> Delete(int id);
    }
}
