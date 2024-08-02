using CinemaSolution.Data.EF;
using CinemaSolution.ViewModels.Auditorium;
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
                            select new { s, m, t };

            if (request.MovieId != null)
            {
                screening = screening.Where(x => x.m.Id == request.MovieId);
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
    }
}
