using CinemaSolution.ViewModels.Common.Paging;
using CinemaSolution.ViewModels.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Application.Movie
{
    public interface IMovieService
    {
        Task<PagedResult<MovieViewModel>> GetPagedResult(GetMoviePagingRequest request);
        Task<MovieViewModel> GetById(int id);
        Task<MovieViewModel> Create(MovieCreateRequest request);
        Task<MovieViewModel> Update(MovieUpdateRequest request);
        Task<int> Delete(int id);
    }
}
