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

        public async Task<List<MovieViewModel>> GetMovies(MovieStatus movieStatus, int? categoryId = null)
        {
            var moviesQuery = from m in cinemaDBContext.Movies
                              where movieStatus == MovieStatus.ValidNow ? (m.EndDate >= DateTime.Now && m.ReleaseDate <= DateTime.Now)
                                : (movieStatus == MovieStatus.ComingSoon ? m.ReleaseDate > DateTime.Now : m.EndDate < DateTime.Now)
                              select new
                              {
                                  Movie = m,
                                  Categories = (from mc in cinemaDBContext.MovieInCategories
                                                join c in cinemaDBContext.Categories on mc.CategoryId equals c.Id
                                                where mc.MovieId == m.Id
                                                select c).ToList(),
                                  Images = (from mi in cinemaDBContext.MovieImages
                                            join mit in cinemaDBContext.MovieImageTypes on mi.MovieImageTypeId equals mit.Id
                                            where mi.MovieId == m.Id
                                            select new { mi, mit.Name }).ToList()
                              };

            if (categoryId.HasValue)
            {
                moviesQuery = moviesQuery.Where(x => x.Categories.Any(c => c.Id == categoryId.Value));
            }

            var result = await moviesQuery.ToListAsync();
            var movies = result.Select(x => new MovieViewModel
            {
                Id = x.Movie.Id,
                Title = x.Movie.Title,
                Description = x.Movie.Description,
                Duration = x.Movie.Duration,
                Language = x.Movie.Language,
                ReleaseDate = x.Movie.ReleaseDate,
                EndDate = x.Movie.EndDate,
                Director = x.Movie.Director,
                Rating = x.Movie.Rating,
                Actors = x.Movie.Actors,
                IsDeleted = x.Movie.IsDeleted,
                TrailerUrl = x.Movie.TrailerUrl,
                Categories = x.Categories.Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList(),
                MovieImages = x.Images.Select(i => new MovieImageViewModel
                {
                    Id = i.mi.Id,
                    ImageUrl = i.mi.ImageUrl,
                    ImageType = i.Name
                }).ToList()
            }).ToList();
            return movies;
        }

        public async Task<List<MovieViewModel>> GetMovieOnGoing()
        {
            var moviesQuery = from m in cinemaDBContext.Movies
                              where m.EndDate >= DateTime.Now && m.ReleaseDate <= DateTime.Now
                              select new
                              {
                                  Movie = m,
                                  Categories = (from mc in cinemaDBContext.MovieInCategories
                                                join c in cinemaDBContext.Categories on mc.CategoryId equals c.Id
                                                where mc.MovieId == m.Id
                                                select c).ToList(),
                                  Images = (from mi in cinemaDBContext.MovieImages
                                            join mit in cinemaDBContext.MovieImageTypes on mi.MovieImageTypeId equals mit.Id
                                            where mi.MovieId == m.Id
                                  select new { mi, mit.Name }).ToList()
                              };

            var result = await moviesQuery.ToListAsync();
            var movies = result.Select(x => new MovieViewModel
            {
                Id = x.Movie.Id,
                Title = x.Movie.Title,
                Description = x.Movie.Description,
                Duration = x.Movie.Duration,
                Language = x.Movie.Language,
                ReleaseDate = x.Movie.ReleaseDate,
                EndDate = x.Movie.EndDate,
                Director = x.Movie.Director,
                Rating = x.Movie.Rating,
                Actors = x.Movie.Actors,
                IsDeleted = x.Movie.IsDeleted,
                TrailerUrl = x.Movie.TrailerUrl,
                Categories = x.Categories.Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList(),
                MovieImages = x.Images.Select(i => new MovieImageViewModel
                {
                    Id = i.mi.Id,
                    ImageUrl = i.mi.ImageUrl,
                    ImageType = i.Name
                }).ToList()
            }).ToList();
            return movies;
        }

        public async Task<List<MovieViewModel>> GetMovieOnFuture()
        {
            var moviesQuery = from m in cinemaDBContext.Movies
                              where m.ReleaseDate > DateTime.Now
                              select new
                              {
                                  Movie = m,
                                  Categories = (from mc in cinemaDBContext.MovieInCategories
                                                join c in cinemaDBContext.Categories on mc.CategoryId equals c.Id
                                                where mc.MovieId == m.Id
                                                select c).ToList(),
                                  Images = (from mi in cinemaDBContext.MovieImages
                                            join mit in cinemaDBContext.MovieImageTypes on mi.MovieImageTypeId equals mit.Id
                                            where mi.MovieId == m.Id
                                            select new { mi, mit.Name }).ToList()
                              };

            var result = await moviesQuery.ToListAsync();
            var movies = result.Select(x => new MovieViewModel
            {
                Id = x.Movie.Id,
                Title = x.Movie.Title,
                Description = x.Movie.Description,
                Duration = x.Movie.Duration,
                Language = x.Movie.Language,
                ReleaseDate = x.Movie.ReleaseDate,
                EndDate = x.Movie.EndDate,
                Director = x.Movie.Director,
                Rating = x.Movie.Rating,
                Actors = x.Movie.Actors,
                IsDeleted = x.Movie.IsDeleted,
                TrailerUrl = x.Movie.TrailerUrl,
                Categories = x.Categories.Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList(),
                MovieImages = x.Images.Select(i => new MovieImageViewModel
                {
                    Id = i.mi.Id,
                    ImageUrl = i.mi.ImageUrl,
                    ImageType = i.Name
                }).ToList()
            }).ToList();
            return movies;
        }

        public async Task<PagedResult<MovieViewModel>> GetPagedResult(GetMoviePagingRequest request)
        {
            var query = from m in cinemaDBContext.Movies
                        join mc in cinemaDBContext.MovieInCategories on m.Id equals mc.MovieId
                        join c in cinemaDBContext.Categories on mc.CategoryId equals c.Id
                        where m.IsDeleted == false
                        select new { m, c };

            if (!string.IsNullOrEmpty(request.Category))
            {
                query = query.Where(x => x.c.Name.Contains(request.Category));
            }
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.m.Title.Contains(request.Keyword));
            }

            if (request.Status == MovieStatus.ValidNow)
            {
                query = query.Where(x => x.m.EndDate >= DateTime.Now && x.m.ReleaseDate <= DateTime.Now);
            }
            else if (request.Status == MovieStatus.ComingSoon)
            {
                query = query.Where(x => x.m.ReleaseDate > DateTime.Now);
            }
            else if (request.Status == MovieStatus.Expired)
            {
                query = query.Where(x => x.m.EndDate < DateTime.Now);
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

        public async Task<MovieViewModel> GetById(int id)
        {
            var movieQuery = from m in cinemaDBContext.Movies
                             where m.Id == id
                             select new
                             {
                                 Movie = m,
                                 Categories = (from mc in cinemaDBContext.MovieInCategories
                                               join c in cinemaDBContext.Categories on mc.CategoryId equals c.Id
                                               where mc.MovieId == m.Id
                                               select c).ToList(),
                                 Images = (from mi in cinemaDBContext.MovieImages
                                           join mit in cinemaDBContext.MovieImageTypes on mi.MovieImageTypeId equals mit.Id
                                           where mi.MovieId == m.Id
                                           select new { mi, mit.Name }).ToList()
                             };

            var result = await movieQuery.FirstOrDefaultAsync();
            if (result == null)
            {
                throw new Exception("Movie not found");
            }

            var data = new MovieViewModel
            {
                Id = result.Movie.Id,
                Title = result.Movie.Title,
                Description = result.Movie.Description,
                Duration = result.Movie.Duration,
                Language = result.Movie.Language,
                ReleaseDate = result.Movie.ReleaseDate,
                EndDate = result.Movie.EndDate,
                Director = result.Movie.Director,
                Rating = result.Movie.Rating,
                Actors = result.Movie.Actors,
                IsDeleted = result.Movie.IsDeleted,
                TrailerUrl = result.Movie.TrailerUrl,
                Categories = result.Categories.Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList(),
                MovieImages = result.Images.Select(i => new MovieImageViewModel
                {
                    Id = i.mi.Id,
                    ImageUrl = i.mi.ImageUrl,
                    ImageType = i.Name
                }).ToList()
            };

            return data;
        }

        public async Task<MovieViewModel> Create(MovieCreateRequest request)
        {
            try
            {
                // Initialize new movie entity
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

                // Associate movie with selected categories
                var selectedCategories = request.Categories
                    .Where(category => category.IsSelected)
                    .Select(category => new Data.Entities.MovieInCategory
                    {
                        MovieId = movie.Id,
                        CategoryId = category.Item.Id
                    });
                cinemaDBContext.MovieInCategories.AddRange(selectedCategories);
                await cinemaDBContext.SaveChangesAsync();

                // Add movie images if URLs are available
                if (!string.IsNullOrEmpty(request.ThumbnailImage3x2Url))
                {
                    cinemaDBContext.MovieImages.Add(new Data.Entities.MovieImage
                    {
                        MovieId = movie.Id,
                        ImageUrl = request.ThumbnailImage3x2Url,
                        MovieImageTypeId = (int)Data.Enums.MovieImageType.ThumbnailImage3x2
                    });
                }
                if (!string.IsNullOrEmpty(request.ThumbnailImage2x3Url))
                {
                    cinemaDBContext.MovieImages.Add(new Data.Entities.MovieImage
                    {
                        MovieId = movie.Id,
                        ImageUrl = request.ThumbnailImage2x3Url,
                        MovieImageTypeId = (int)Data.Enums.MovieImageType.ThumbnailImage2x3
                    });
                }
                await cinemaDBContext.SaveChangesAsync();

                // Build and return the MovieViewModel
                return new MovieViewModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Duration = movie.Duration,
                    Language = movie.Language,
                    Director = movie.Director,
                    Actors = movie.Actors,
                    Description = movie.Description,
                    ReleaseDate = movie.ReleaseDate,
                    EndDate = movie.EndDate,
                    TrailerUrl = movie.TrailerUrl,
                    Categories = request.Categories
                        .Where(category => category.IsSelected)
                        .Select(category => new CategoryViewModel
                        {
                            Id = category.Item.Id,
                            Name = category.Item.Name
                        }).ToList(),
                    MovieImages = new List<MovieImageViewModel>
                    {
                        new MovieImageViewModel { Id = 1, ImageUrl = request.ThumbnailImage3x2Url ?? "https://via.placeholder.com/600x900", ImageType = "Poster" },
                        new MovieImageViewModel { Id = 2, ImageUrl = request.ThumbnailImage2x3Url ?? "https://via.placeholder.com/900x600", ImageType = "Backdrop" }
                    }
                };
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                throw new ApplicationException("An error occurred while creating the movie", ex);
            }
        }

        public async Task<MovieViewModel> Update(MovieUpdateRequest request)
        {
            var movie = await cinemaDBContext.Movies.FindAsync(request.Id);
            if (movie == null)
            {
                throw new Exception("Movie not found");
            }
            movie.Title = request.Title;
            movie.Language = request.Language;
            movie.Director = request.Director;
            movie.Actors = request.Actors;
            movie.Description = request.Description;
            movie.TrailerUrl = request.TrailerUrl;
            movie.ReleaseDate = request.ReleaseDate;
            movie.EndDate = request.EndDate;
            movie.Duration = request.Duration;

            // Update movie in categories
            var movieInCategories = await cinemaDBContext.MovieInCategories
                .Where(x => x.MovieId == request.Id)
                .ToListAsync();
            foreach (var movieInCategory in movieInCategories)
            {
                cinemaDBContext.MovieInCategories.Remove(movieInCategory);
            }
            foreach (var category in request.Categories)
            {
                if (category.IsSelected == false)
                {
                    continue;
                }
                var movieInCategory = new Data.Entities.MovieInCategory()
                {
                    MovieId = movie.Id,
                    CategoryId = category.Item.Id
                };
                cinemaDBContext.MovieInCategories.Add(movieInCategory);
            }
            await cinemaDBContext.SaveChangesAsync();

            // Update movie images
            var movieImages = await cinemaDBContext.MovieImages
                .Where(x => x.MovieId == request.Id)
                .ToListAsync();
            if (request.ThumbnailImage3x2Url != null)
            {
                var movieImage = movieImages.FirstOrDefault(x => x.MovieImageTypeId == (int)Data.Enums.MovieImageType.ThumbnailImage3x2);
                if (movieImage != null)
                {
                    movieImage.ImageUrl = request.ThumbnailImage3x2Url;
                }
                else
                {
                    cinemaDBContext.MovieImages.Add(new Data.Entities.MovieImage()
                    {
                        MovieId = movie.Id,
                        ImageUrl = request.ThumbnailImage3x2Url,
                        MovieImageTypeId = (int)Data.Enums.MovieImageType.ThumbnailImage3x2
                    });
                }
            }
            if (request.ThumbnailImage2x3Url != null)
            {
                var movieImage = movieImages.FirstOrDefault(x => x.MovieImageTypeId == (int)Data.Enums.MovieImageType.ThumbnailImage2x3);
                if (movieImage != null)
                {
                    movieImage.ImageUrl = request.ThumbnailImage2x3Url;
                }
                else
                {
                    cinemaDBContext.MovieImages.Add(new Data.Entities.MovieImage()
                    {
                        MovieId = movie.Id,
                        ImageUrl = request.ThumbnailImage2x3Url,
                        MovieImageTypeId = (int)Data.Enums.MovieImageType.ThumbnailImage2x3
                    });
                }
            }
            await cinemaDBContext.SaveChangesAsync();

            return new MovieViewModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                Duration = movie.Duration,
                Language = movie.Language,
                Director = movie.Director,
                Actors = movie.Actors,
                Description = movie.Description,
                ReleaseDate = movie.ReleaseDate,
                EndDate = movie.EndDate,
                TrailerUrl = movie.TrailerUrl,
                Categories = request.Categories.Select(x => new CategoryViewModel()
                {
                    Id = x.Item.Id,
                    Name = x.Item.Name
                }).ToList()
            };
        }

        public async Task<int> Delete(int id)
        {
            var movie = await cinemaDBContext.Movies.FindAsync(id);
            if (movie == null)
            {
                throw new Exception("Movie not found");
            }
            movie.IsDeleted = true;
            return await cinemaDBContext.SaveChangesAsync();
        }
    }
}
