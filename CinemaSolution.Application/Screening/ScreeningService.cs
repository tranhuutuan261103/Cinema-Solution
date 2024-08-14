﻿using CinemaSolution.Data.EF;
using CinemaSolution.ViewModels.Auditorium;
using CinemaSolution.ViewModels.Cinema;
using CinemaSolution.ViewModels.Common.Paging;
using CinemaSolution.ViewModels.Movie;
using CinemaSolution.ViewModels.Screening;
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

            // Get the total number of records
            int totalRecords = await query.CountAsync();

            // Paginate the results
            var screenings = await query
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

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
                SeatsAvailable = seats.FirstOrDefault(x => x.ScreeningId == s.s.Id)?.AvailableSeats ?? 0,
                SeatsTotal = seats.FirstOrDefault(x => x.ScreeningId == s.s.Id)?.SeatTotal ?? 0,
            }).ToList();

            return new PagedResult<ScreeningViewModel>()
            {
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = totalRecords,
            };
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
    }
}