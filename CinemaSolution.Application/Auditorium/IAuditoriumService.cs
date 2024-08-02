using CinemaSolution.ViewModels.Auditorium;
using CinemaSolution.ViewModels.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Application.Auditorium
{
    public interface IAuditoriumService
    {
        Task<PagedResult<AuditoriumViewModel>> GetByCinemaId(int cinemaId);
        Task<AuditoriumViewModel> GetById(int auditoriumId);
        Task<AuditoriumViewModel> Create(AuditoriumCreateRequest request);
        Task<AuditoriumViewModel> Update(AuditoriumUpdateRequest request);
        Task<int> Delete(int auditoriumId);
    }
}
