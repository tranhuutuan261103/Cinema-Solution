using CinemaSolution.ViewModels.Cinema;
using CinemaSolution.ViewModels.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Application.Cinema
{
    public interface ICinemaService
    {
        Task<PagedResult<CinemaViewModel>> GetPagedResult(GetCinemaPagingRequest request);
        Task<CinemaViewModel> Create(CinemaCreateRequest request);
    }
}
