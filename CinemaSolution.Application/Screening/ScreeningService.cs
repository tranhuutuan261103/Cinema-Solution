using CinemaSolution.Data.EF;
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
            var screening = from s in cinemaDBContext.Screenings
                            join m in cinemaDBContext.Movies on s.MovieId equals m.Id
                            join t in cinemaDBContext.Auditoriums on s.AuditoriumId equals t.Id
                            join c in cinemaDBContext.Cinemas on t.CinemaId equals c.Id
                            select new { s, m, t, c };

            if (request.MovieId != null)
            {
                screening = screening.Where(x => x.m.Id == request.MovieId);
            }

            if (request.AuditoriumId != null)
            {
                screening = screening.Where(x => x.t.Id == request.AuditoriumId);
            }

            int totalRow = await screening.CountAsync();
            var data = await screening.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ScreeningViewModel()
                {
                    Id = x.s.Id,
                    Movie = new MovieViewModel()
                    {
                        Id = x.m.Id,
                        Title = x.m.Title,
                        Duration = x.m.Duration,
                    },
                    Auditorium = new AuditoriumViewModel()
                    {
                        Id = x.t.Id,
                        Name = x.t.Name,
                        Cinema = new CinemaViewModel()
                        {
                            Id = x.c.Id,
                            Name = x.c.Name,
                        }
                    },
                    StartTime = x.s.StartTime,
                    StartDate = x.s.StartDate,
                }).ToListAsync();

            return new PagedResult<ScreeningViewModel>()
            {
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = totalRow,
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
