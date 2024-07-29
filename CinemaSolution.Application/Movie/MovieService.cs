using CinemaSolution.Data.EF;
using CinemaSolution.ViewModels.Category;
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
                        select new { m, c };

            if (!string.IsNullOrEmpty(request.Category))
            {
                query = query.Where(x => x.c.Name.Contains(request.Category));
            }
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.m.Title.Contains(request.Keyword));
            }

            // Total records count
            int totalRow = await query.Select(x => x.m.Id).Distinct().CountAsync();

            // Paginate the query
            var groupedQuery = query
                .GroupBy(x => x.m)
                .Select(g => new MovieViewModel
                {
                    Id = g.Key.Id,
                    Title = g.Key.Title,
                    Description = g.Key.Description,
                    Duration = g.Key.Duration,
                    Language = g.Key.Language,
                    ReleaseDate = g.Key.ReleaseDate,
                    EndDate = g.Key.EndDate,
                    Director = g.Key.Director,
                    Rating = g.Key.Rating,
                    Actors = g.Key.Actors,
                    IsDeleted = g.Key.IsDeleted,
                    TrailerUrl = g.Key.TrailerUrl,
                    Categories = g.Select(x => new CategoryViewModel()
                    {
                        Id = x.c.Id,
                        Name = x.c.Name
                    }).ToList()
                });

            var data = await groupedQuery
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            var pagedResult = new PagedResult<MovieViewModel>()
            {
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = totalRow
            };

            return pagedResult;
        }

        public async Task<MovieViewModel> Create(MovieCreateRequest request)
        {
            // Create new movie
            var movie = new Data.Entities.Movie()
            {
                Title = request.Title,
                Language = request.Language,
                Director = request.Director,
                Actors = request.Actors,
                Description = request.Description,
                TrailerUrl = request.TrailerUrl,
                ReleaseDate = request.ReleaseDate,
                EndDate = request.EndDate,
                Duration = request.Duration,
            };
            cinemaDBContext.Movies.Add(movie);
            await cinemaDBContext.SaveChangesAsync();

            // Create movie in categories
            foreach (var category in request.Categories)
            {
                var movieInCategory = new Data.Entities.MovieInCategory()
                {
                    MovieId = movie.Id,
                    CategoryId = category.Item.Id
                };
                cinemaDBContext.MovieInCategories.Add(movieInCategory);
            }
            await cinemaDBContext.SaveChangesAsync();

            // Create movie images
            cinemaDBContext.MovieImages.Add(new Data.Entities.MovieImage()
            {
                MovieId = movie.Id,
                ImageUrl = "https://via.placeholder.com/600x900",
                MovieImageTypeId = (int)Data.Enums.MovieImageType.ThumbnailImage3x2
            });
            cinemaDBContext.MovieImages.Add(new Data.Entities.MovieImage()
            {
                MovieId = movie.Id,
                ImageUrl = "https://via.placeholder.com/900x600",
                MovieImageTypeId = (int)Data.Enums.MovieImageType.ThumbnailImage2x3
            });
            await cinemaDBContext.SaveChangesAsync();

            // Return the created movie
            return new MovieViewModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                Duration = movie.Duration,
                Language = movie.Language,
                Director = movie.Director,
                Actors = movie.Actors,
                Description= movie.Description,
                ReleaseDate= movie.ReleaseDate,
                EndDate= movie.EndDate,
                TrailerUrl= movie.TrailerUrl,
                Categories = request.Categories.Select(x => new CategoryViewModel()
                {
                    Id = x.Item.Id,
                    Name = x.Item.Name
                }).ToList(),
                MovieImages = new List<MovieImageViewModel>()
                {
                    new MovieImageViewModel()
                    {
                        Id = 1,
                        ImageUrl = "https://via.placeholder.com/600x900",
                        ImageType = "Poster"
                    },
                    new MovieImageViewModel()
                    {
                        Id = 2,
                        ImageUrl = "https://via.placeholder.com/900x600",
                        ImageType = "Backdrop"
                    }
                }
            };
        }
    }
}
