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
        Task<List<CinemaViewModel>> GetAll();
        Task<CinemaViewModel> GetById(int id);
        Task<CinemaViewModel> Create(CinemaCreateRequest request);
        Task<CinemaViewModel> Update(CinemaUpdateRequest request);
        Task<int> Delete(int id);
    }
}
