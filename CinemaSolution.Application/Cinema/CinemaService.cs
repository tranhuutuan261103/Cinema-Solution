using CinemaSolution.Data.EF;
using CinemaSolution.Data.Entities;
using CinemaSolution.ViewModels.Auditorium;
using CinemaSolution.ViewModels.Category;
using CinemaSolution.ViewModels.Cinema;
using CinemaSolution.ViewModels.Common.Paging;
using CinemaSolution.ViewModels.Movie;
using CinemaSolution.ViewModels.Province;
using CinemaSolution.ViewModels.Screening;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Application.Cinema
{
    public class CinemaService : ICinemaService
    {
        private readonly CinemaDBContext cinemaDBContext;
        public CinemaService(CinemaDBContext cinemaDBContext)
        {
            this.cinemaDBContext = cinemaDBContext;
        }
        public async Task<PagedResult<CinemaViewModel>> GetPagedResult(GetCinemaPagingRequest request)
        {
            var query = from c in cinemaDBContext.Cinemas
                        where c.IsDeleted == false && (string.IsNullOrEmpty(request.Keyword) || c.Name.Contains(request.Keyword))
                        select new { c };
            var totalRow = await query.CountAsync();
            var data = await query
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(
                x => new CinemaViewModel
                {
                    Id = x.c.Id,
                    Name = x.c.Name,
                    LogoUrl = x.c.LogoUrl,
                    IsDeleted = x.c.IsDeleted
                }).ToListAsync();
            var pagedResult = new PagedResult<CinemaViewModel>
            {
                TotalRecords = totalRow,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
            return pagedResult;
        }

        public async Task<List<CinemaViewModel>> GetAll()
        {
            var cinemas = await cinemaDBContext.Cinemas.Where(x => x.IsDeleted == false)
                .Select(x => new CinemaViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    LogoUrl = x.LogoUrl,
                    IsDeleted = x.IsDeleted
                }).ToListAsync();
            return cinemas;
        }

        public async Task<List<CinemaViewModel>> GetByProvinceId(int provinceId)
        {
            // Query to get cinemas and their auditoriums based on the province ID
            var cinemas = from c in cinemaDBContext.Cinemas
                          join a in cinemaDBContext.Auditoriums on c.Id equals a.CinemaId
                          join p in cinemaDBContext.Provinces on a.ProvinceId equals p.Id
                          where a.ProvinceId == provinceId
                          select new { c, a, p };

            // Group the results by cinema
            var groupedCinemas = await cinemas
                .GroupBy(x => x.c)
                .Select(g => new CinemaViewModel
                {
                    Id = g.Key.Id,
                    Name = g.Key.Name,
                    LogoUrl = g.Key.LogoUrl,
                    IsDeleted = g.Key.IsDeleted,
                    Auditoriums = g.Select(x => new AuditoriumViewModel
                    {
                        Id = x.a.Id,
                        Name = x.a.Name,
                        Latitude = x.a.Latitude,
                        Longitude = x.a.Longitude,
                        Address = x.a.Address,
                        SeatsPerColumn = x.a.NumberOfRowSeats,
                        SeatsPerRow = x.a.NumberOfColumnSeats,
                        Province = new ProvinceViewModel
                        {
                            Id = x.p.Id,
                            Name = x.p.Name
                        }
                    }).ToList()
                }).ToListAsync();

            return groupedCinemas;
        }
        public async Task<List<CinemaViewModel>> GetScreeningsByMovieId(int movieId, int provinceId, DateTime startDate)
        {
            // Step 1: Fetch the data from the database
            var cinemaData = await (from c in cinemaDBContext.Cinemas
                                    join a in cinemaDBContext.Auditoriums on c.Id equals a.CinemaId
                                    join p in cinemaDBContext.Provinces on a.ProvinceId equals p.Id
                                    join s in cinemaDBContext.Screenings on a.Id equals s.AuditoriumId
                                    join m in cinemaDBContext.Movies on s.MovieId equals m.Id
                                    join ss in cinemaDBContext.Seats on s.Id equals ss.ScreeningId
                                    where a.ProvinceId == provinceId && m.Id == movieId && s.StartDate.Date == startDate.Date
                                    select new
                                    {
                                        Cinema = c,
                                        Auditorium = a,
                                        Province = p,
                                        Screening = s,
                                        Seat = ss,
                                        Movie = m
                                    }).ToListAsync();

            // Step 2: Group the data by Cinema
            var groupedCinemas = cinemaData
                .GroupBy(x => x.Cinema)
                .Select(g => new CinemaViewModel
                {
                    Id = g.Key.Id,
                    Name = g.Key.Name,
                    LogoUrl = g.Key.LogoUrl,
                    IsDeleted = g.Key.IsDeleted,
                    Auditoriums = g.GroupBy(ag => new { ag.Auditorium, ag.Province })
                                    .Select(x => new AuditoriumViewModel
                                    {
                                        Id = x.Key.Auditorium.Id,
                                        Name = x.Key.Auditorium.Name,
                                        Latitude = x.Key.Auditorium.Latitude,
                                        Longitude = x.Key.Auditorium.Longitude,
                                        Address = x.Key.Auditorium.Address,
                                        SeatsPerColumn = x.Key.Auditorium.NumberOfRowSeats,
                                        SeatsPerRow = x.Key.Auditorium.NumberOfColumnSeats,
                                        Province = new ProvinceViewModel
                                        {
                                            Id = x.Key.Province.Id,
                                            Name = x.Key.Province.Name
                                        },
                                        Screenings = x.GroupBy(sg => new { sg.Screening, sg.Movie })
                                                        .Select(sg => new ScreeningViewModel
                                                        {
                                                            Movie = new ViewModels.Movie.MovieViewModel()
                                                            {
                                                                Id = sg.Key.Movie.Id,
                                                                Title = sg.Key.Movie.Title,

                                                            },
                                                            Id = sg.Key.Screening.Id,
                                                            StartTime = sg.Key.Screening.StartTime,
                                                            EndTime = sg.Key.Screening.StartTime + TimeSpan.FromMinutes(sg.Key.Movie.Duration),
                                                            StartDate = sg.Key.Screening.StartDate,
                                                            SeatsAvailable = sg.Count(x => x.Seat.SeatStatusId == 1),
                                                            SeatsTotal = sg.Count(),
                                                        }).ToList()
                                    })
                                    .Where(x => x.Screenings.Any())
                                    .ToList()
                })
                .Where(x => x.Auditoriums.Any())
                .ToList();

            return groupedCinemas;
        }

        public async Task<List<MovieScreeningViewModel>> GetScreeningsByAuditoriumId(int auditoriumId, DateTime startDate)
        {
            // Fetch the data from the database
            var cinemaData = await (from m in cinemaDBContext.Movies
                                    join mic in cinemaDBContext.MovieInCategories on m.Id equals mic.MovieId
                                    join c in cinemaDBContext.Categories on mic.CategoryId equals c.Id
                                    join mi in cinemaDBContext.MovieImages on m.Id equals mi.MovieId
                                    join mit in cinemaDBContext.MovieImageTypes on mi.MovieImageTypeId equals mit.Id
                                    join s in cinemaDBContext.Screenings on m.Id equals s.MovieId
                                    where s.AuditoriumId == auditoriumId && s.StartDate.Date == startDate.Date
                                    select new
                                    {
                                        Movie = m,
                                        Category = c,
                                        MovieImage = mi,
                                        MovieImageType = mit,
                                        Screening = s,
                                        Seat = s.Seats // Get seats directly from the Screening entity
                                    }).ToListAsync();

            // Group by Movie and Screening
            var groupedMovies = cinemaData
                .GroupBy(x => new { x.Movie, x.Screening })
                .Select(g => new MovieScreeningViewModel
                {
                    Id = g.Key.Movie.Id,
                    Title = g.Key.Movie.Title,
                    Duration = g.Key.Movie.Duration,
                    Language = g.Key.Movie.Language,
                    Rating = g.Key.Movie.Rating,
                    Director = g.Key.Movie.Director,
                    MovieImages = g.GroupBy(mig => mig.MovieImage)
                                .Select(mig => new MovieImageViewModel
                                {
                                    Id = mig.Key.Id,
                                    ImageUrl = mig.Key.ImageUrl,
                                    ImageType = mig.Key.MovieImageType.Name
                                }).ToList(),
                    Categories = g.GroupBy(cg => cg.Category)
                                .Select(cg => new CategoryViewModel
                                {
                                    Id = cg.Key.Id,
                                    Name = cg.Key.Name
                                }).ToList(),
                    TrailerUrl = g.Key.Movie.TrailerUrl,
                    Actors = g.Key.Movie.Actors,
                    IsDeleted = g.Key.Movie.IsDeleted,
                    Screenings = g.GroupBy(sg => sg.Screening)
                        .Select(sg => new ScreeningViewModel
                        {
                            Movie = new ViewModels.Movie.MovieViewModel
                            {
                                Id = g.Key.Movie.Id,
                                Title = g.Key.Movie.Title,
                            },
                            Id = sg.Key.Id,
                            StartTime = sg.Key.StartTime,
                            EndTime = sg.Key.StartTime + TimeSpan.FromMinutes(g.Key.Movie.Duration),
                            StartDate = sg.Key.StartDate,
                            SeatsAvailable = sg.Key.Seats.Count(x => x.SeatStatusId == 1),
                            SeatsTotal = sg.Key.Seats.Count()
                        }).ToList()
                })
                .ToList();

            return groupedMovies;
        }

        public async Task<CinemaViewModel> GetById(int id)
        {
            var cinema = await cinemaDBContext.Cinemas.FindAsync(id);
            if (cinema == null)
            {
                throw new Exception("Cinema not found");
            }
            return new CinemaViewModel
            {
                Id = cinema.Id,
                Name = cinema.Name,
                LogoUrl = cinema.LogoUrl,
                IsDeleted = cinema.IsDeleted
            };
        }

        public async Task<CinemaViewModel> Create(CinemaCreateRequest request)
        {
            try
            {
                var cinema = new Data.Entities.Cinema()
                {
                    Name = request.Name,
                    LogoUrl = request.LogoUrl,
                    IsDeleted = false
                };
                cinemaDBContext.Cinemas.Add(cinema);
                await cinemaDBContext.SaveChangesAsync();

                return new CinemaViewModel
                {
                    Id = cinema.Id,
                    Name = cinema.Name,
                    LogoUrl = cinema.LogoUrl,
                    IsDeleted = cinema.IsDeleted
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CinemaViewModel> Update(CinemaUpdateRequest request)
        {
            try
            {
                var cinema = await cinemaDBContext.Cinemas.FindAsync(request.Id);
                if (cinema == null)
                {
                    throw new Exception("Cinema not found");
                }
                cinema.Name = request.Name;
                cinema.LogoUrl = request.LogoUrl;
                await cinemaDBContext.SaveChangesAsync();
                return new CinemaViewModel
                {
                    Id = cinema.Id,
                    Name = cinema.Name,
                    LogoUrl = cinema.LogoUrl,
                    IsDeleted = cinema.IsDeleted
                };
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> Delete(int id)
        {
            var cinema = await cinemaDBContext.Cinemas.FindAsync(id);
            if (cinema == null)
            {
                throw new Exception("Cinema not found");
            }
            cinema.IsDeleted = true;
            return await cinemaDBContext.SaveChangesAsync();
        }
    }
}
