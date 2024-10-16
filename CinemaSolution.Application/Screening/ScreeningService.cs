﻿using CinemaSolution.Data.EF;
using CinemaSolution.Data.Entities;
using CinemaSolution.ViewModels.Auditorium;
using CinemaSolution.ViewModels.Category;
using CinemaSolution.ViewModels.Cinema;
using CinemaSolution.ViewModels.Common.Paging;
using CinemaSolution.ViewModels.Movie;
using CinemaSolution.ViewModels.Screening;
using CinemaSolution.ViewModels.Seat;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Application.Screening
{
    public class ScreeningService : IScreeningService
    {
        private readonly CinemaDBContext cinemaDBContext;
        public ScreeningService(CinemaDBContext cinemaDBContext)
        {
            this.cinemaDBContext = cinemaDBContext;
        }

        public async Task<List<ScreeningViewModel>> GetAll()
        {
            var query = from s in cinemaDBContext.Screenings
                        join m in cinemaDBContext.Movies on s.MovieId equals m.Id
                        join t in cinemaDBContext.Auditoriums on s.AuditoriumId equals t.Id
                        join c in cinemaDBContext.Cinemas on t.CinemaId equals c.Id
                        select new { s, m, t, c };
            var screenings = await query
                .Select(s => new ScreeningViewModel()
                {
                    Id = s.s.Id,
                    Movie = new MovieViewModel()
                    {
                        Id = s.m.Id,
                        Title = s.m.Title,
                        Duration = s.m.Duration,
                    },
                    Auditorium = new AuditoriumViewModel()
                    {
                        Id = s.t.Id,
                        Name = s.t.Name,
                        Cinema = new CinemaViewModel()
                        {
                            Id = s.c.Id,
                            Name = s.c.Name,
                        }
                    },
                    StartTime = s.s.StartTime,
                    StartDate = s.s.StartDate,
                })
                .ToListAsync();
            return screenings;
        }
        public async Task<PagedResult<ScreeningViewModel>> GetPagedResult(GetScreeningPagingRequest request)
        {
            var query = from s in cinemaDBContext.Screenings
                        join m in cinemaDBContext.Movies on s.MovieId equals m.Id
                        join t in cinemaDBContext.Auditoriums on s.AuditoriumId equals t.Id
                        join c in cinemaDBContext.Cinemas on t.CinemaId equals c.Id
                        select new { s, m, t, c };

            // Apply filters before joins
            if (request.MovieId.HasValue)
            {
                query = query.Where(x => x.m.Id == request.MovieId.Value);
            }

            if (request.AuditoriumId.HasValue)
            {
                query = query.Where(x => x.t.Id == request.AuditoriumId.Value);
            }

            var screenings = await query.ToListAsync();

            // Fetch seats data in parallel
            var screeningIds = screenings.Select(x => x.s.Id).ToList();
            var seats = await cinemaDBContext.Seats
                .Where(s => screeningIds.Contains(s.ScreeningId))
                .GroupBy(s => s.ScreeningId)
                .Select(g => new { ScreeningId = g.Key, AvailableSeats = g.Count(s => s.SeatStatusId == 1), SeatTotal = g.Count() })
                .ToListAsync();

            // Combine the data and create the final result
            var data = screenings.Select(s => new ScreeningViewModel()
            {
                Id = s.s.Id,
                Movie = new MovieViewModel()
                {
                    Id = s.m.Id,
                    Title = s.m.Title,
                    Duration = s.m.Duration,
                },
                Auditorium = new AuditoriumViewModel()
                {
                    Id = s.t.Id,
                    Name = s.t.Name,
                    Cinema = new CinemaViewModel()
                    {
                        Id = s.c.Id,
                        Name = s.c.Name,
                    }
                },
                StartTime = s.s.StartTime,
                StartDate = s.s.StartDate,
                EndTime = s.s.StartTime + TimeSpan.FromMinutes(s.m.Duration),
                SeatsAvailable = seats.FirstOrDefault(x => x.ScreeningId == s.s.Id)?.AvailableSeats ?? 0,
                SeatsTotal = seats.FirstOrDefault(x => x.ScreeningId == s.s.Id)?.SeatTotal ?? 0,
                Status = GetStatus(s.s.StartDate, s.s.StartTime),
            }).ToList();

            if (request.Status.HasValue)
            {
                data = data.Where(x => x.Status == request.Status.Value).ToList();
            }

            // Get the total number of records
            int totalRecords = data.Count;

            // Apply paging
            var pagedScreenings = data
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            return new PagedResult<ScreeningViewModel>()
            {
                Items = pagedScreenings,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = totalRecords,
            };
        }

        public async Task<ScreeningViewModel> GetScreeningById(int id)
        {
            var screening = await cinemaDBContext.Screenings.FindAsync(id);
            if (screening == null)
            {
                throw new Exception($"Cannot find a screening: {id}");
            }

            var movie = from m in cinemaDBContext.Movies
                        where m.Id == screening.MovieId
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

            var movieResult = await movie.FirstOrDefaultAsync();

            var auditorium = await cinemaDBContext.Auditoriums.FindAsync(screening.AuditoriumId);
            var cinema = await cinemaDBContext.Cinemas.FindAsync(auditorium.CinemaId);

            var seatPriceTables = await cinemaDBContext.DefaultPriceTables.Select(dpt => new SeatPriceViewModel
            {
                SeatTypeId = dpt.SeatTypeId,
                PersonTypeId = dpt.PersonTypeId,
                Price = dpt.Price,
            }).ToListAsync();

            var seats = from s in cinemaDBContext.Seats
                        join sc in cinemaDBContext.Screenings on s.ScreeningId equals sc.Id
                        join st in cinemaDBContext.SeatTypes on s.SeatTypeId equals st.Id
                        join ss in cinemaDBContext.SeatStatuses on s.SeatStatusId equals ss.Id
                        where sc.Id == id
                        select new { Seat = s, Screening = sc, SeatType = st, SeatStatus = ss };
            var screeningResult = new ScreeningViewModel()
            {
                Id = screening.Id,
                Movie = new MovieViewModel()
                {
                    Id = movieResult.Movie.Id,
                    Title = movieResult.Movie.Title,
                    Duration = movieResult.Movie.Duration,
                    Language = movieResult.Movie.Language,
                    MovieImages = movieResult.Images.Select(i => new MovieImageViewModel()
                    {
                        Id = i.mi.Id,
                        ImageType = i.Name,
                        ImageUrl = i.mi.ImageUrl,
                    }).ToList(),
                    Categories = movieResult.Categories.Select(c => new CategoryViewModel()
                    {
                        Id = c.Id,
                        Name = c.Name,
                    }).ToList(),
                    TrailerUrl = movieResult.Movie.TrailerUrl,
                },
                Auditorium = new AuditoriumViewModel()
                {
                    Id = auditorium.Id,
                    Name = auditorium.Name,
                    SeatsPerRow = auditorium.NumberOfColumnSeats,
                    SeatsPerColumn = auditorium.NumberOfRowSeats,
                    Cinema = new CinemaViewModel()
                    {
                        Id = cinema.Id,
                        Name = cinema.Name,
                        LogoUrl = cinema.LogoUrl,
                    }
                },
                StartTime = screening.StartTime,
                StartDate = screening.StartDate,
                EndTime = screening.StartTime + TimeSpan.FromMinutes(movieResult.Movie.Duration),
                SeatsAvailable = seats.Count(s => s.SeatStatus.IsAvailable),
                SeatsTotal = seats.Count(),
                Seats = seats.Select(s => new SeatViewModel()
                    {
                        Id = s.Seat.Id,
                        Row = s.Seat.Row,
                        Number = s.Seat.Number,
                        SeatStatus = new SeatStatusViewModel()
                        {
                            Id = s.SeatStatus.Id,
                            StatusName = s.SeatStatus.StatusName,
                            IsAvailable = s.SeatStatus.IsAvailable,
                        },
                        SeatType = new SeatTypeViewModel()
                        {
                            Id = s.SeatType.Id,
                            Name = s.SeatType.Name,
                        },
                    }).ToList(),
            };

            foreach (SeatViewModel seat in screeningResult.Seats)
            {
                seat.Prices = seatPriceTables
                    .Where(spt => spt.SeatTypeId == seat.SeatType.Id)
                    .Select(spt => new SeatPriceViewModel
                {
                    SeatTypeId = spt.SeatTypeId,
                    PersonTypeId = spt.PersonTypeId,
                    Price = spt.Price,
                }).ToList();
            }

            return screeningResult;
        }

        public async Task<ScreeningViewModel> Create(ScreeningCreateRequest request)
        {
            var screening = new Data.Entities.Screening()
            {
                MovieId = request.MovieId,
                AuditoriumId = request.Auditorium.Id,
                StartDate = request.StartDate,
                StartTime = request.StartTime,
            };
            await cinemaDBContext.Screenings.AddAsync(screening);
            await cinemaDBContext.SaveChangesAsync();
            var seats = new List<Data.Entities.Seat>();
            foreach (var seat in request.SeatDefaults)
            {
                seats.Add(new Data.Entities.Seat()
                {
                    ScreeningId = screening.Id,
                    Row = seat.Row,
                    Number = seat.Column,
                    SeatTypeId = seat.TypeId,
                    SeatStatusId = 1,
                });
            }
            await cinemaDBContext.Seats.AddRangeAsync(seats);
            await cinemaDBContext.SaveChangesAsync();
            return new ScreeningViewModel()
            {
                Id = screening.Id,
                StartDate = screening.StartDate,
                StartTime= screening.StartTime,
            };
        }

        public async Task<ScreeningViewModel> Update(ScreeningUpdateRequest request)
        {
            var screening = await cinemaDBContext.Screenings.FindAsync(request.Id);
            if (screening == null)
            {
                throw new Exception($"Cannot find a screening: {request.Id}");
            }
            screening.MovieId = request.MovieId;
            screening.StartDate = request.StartDate;
            screening.StartTime = request.StartTime;
            await cinemaDBContext.SaveChangesAsync();
            return new ScreeningViewModel()
            {
                Id = screening.Id,
                StartDate = screening.StartDate,
                StartTime = screening.StartTime,
            };
        }

        public async Task<int> Delete(int id)
        {
            var screening = await cinemaDBContext.Screenings.FindAsync(id);
            if (screening == null)
            {
                throw new Exception($"Cannot find a screening: {id}");
            }
            screening.IsDeleted = true;
            return await cinemaDBContext.SaveChangesAsync();
        }

        public ScreeningStatus GetStatus(DateTime startDate, TimeSpan startTime)
        {
            var currentDateTime = DateTime.Now;
            var screeningDateTime = startDate.Add(startTime);
            var timeToStart = screeningDateTime - currentDateTime;
            var timeToStartInMinutes = timeToStart.TotalMinutes;
            if (timeToStartInMinutes > 30)
            {
                return ScreeningStatus.Future;
            }
            else if (timeToStartInMinutes > 0)
            {
                return ScreeningStatus.Going;
            }
            return ScreeningStatus.Expried;
        }
    }
}
