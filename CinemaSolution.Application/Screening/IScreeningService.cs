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
        Task<ScreeningViewModel> GetScreeningById(int id);
        Task<ScreeningViewModel> Create(ScreeningCreateRequest request);
        Task<ScreeningViewModel> Update(ScreeningUpdateRequest request);
        Task<int> Delete(int id);
    }
}
