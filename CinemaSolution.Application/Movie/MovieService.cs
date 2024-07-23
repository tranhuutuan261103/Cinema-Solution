using CinemaSolution.Data.EF;
using CinemaSolution.ViewModels.Common.Paging;
using CinemaSolution.ViewModels.Movie;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Application.Movie
{
    public class MovieService : IMovieService
    {
        private readonly CinemaDBContext cinemaDBContext;
        public MovieService(CinemaDBContext cinemaDBContext)
        {
            this.cinemaDBContext = cinemaDBContext;
        }

        public async Task<PagedResult<MovieViewModel>> GetPagedResult(GetMoviePagingRequest request)
        {
            var query = from m in cinemaDBContext.Movies
                        join mc in cinemaDBContext.MovieInCategories on m.Id equals mc.MovieId
                        join c in cinemaDBContext.Categories on mc.CategoryId equals c.Id
                        select new { m, mc, c };
            if (!string.IsNullOrEmpty(request.Category))
            {
                query = query.Where(x => x.c.Name.Contains(request.Category));
            }
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.m.Title.Contains(request.Keyword));
            }
            List<MovieViewModel> movies = new List<MovieViewModel>();
            foreach (var item in query)
            {
                MovieViewModel movie = new MovieViewModel()
                {
                    Id = item.m.Id,
                    Title = item.m.Title,
                    Description = item.m.Description,
                    Duration = item.m.Duration,
                    Language = item.m.Language,
                    ReleaseDate = item.m.ReleaseDate,
                    EndDate = item.m.EndDate,
                    Director = item.m.Director,
                    Rating = item.m.Rating,
                    Actors = item.m.Actors,
                    IsDeleted = item.m.IsDeleted,
                    TrailerUrl = item.m.TrailerUrl
                };
                movies.Add(movie);
            }
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).ToListAsync();
            var pagedResult = new PagedResult<MovieViewModel>()
            {
                Items = movies,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = totalRow
            };
            return pagedResult;
        }
    }
}
