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
    }
}
