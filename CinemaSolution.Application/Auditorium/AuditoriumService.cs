using CinemaSolution.Data.EF;
using CinemaSolution.ViewModels.Auditorium;
using CinemaSolution.ViewModels.Common.Paging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Application.Auditorium
{
    public class AuditoriumService : IAuditoriumService
    {
        private readonly CinemaDBContext cinemaDBContext;
        public AuditoriumService(CinemaDBContext cinemaDBContext)
        {
            this.cinemaDBContext = cinemaDBContext;
        }
        public async Task<PagedResult<AuditoriumViewModel>> GetByCinemaId(int cinemaId)
        {
            var query = from a in cinemaDBContext.Auditoriums
                        where a.CinemaId == cinemaId
                        select new AuditoriumViewModel()
                        {
                            Id = a.Id,
                            Name = a.Name,
                            CinemaId = a.CinemaId,
                            SeatsPerRow = a.NumberOfColumnSeats,
                            SeatsPerColumn = a.NumberOfRowSeats
                        };
            var data = await query.ToListAsync();
            var result = new PagedResult<AuditoriumViewModel>()
            {
                Items = data,
                TotalRecords = data.Count,
                PageIndex = 1,
                PageSize = data.Count
            };
            return result;
        }

        public async Task<AuditoriumViewModel> Create(AuditoriumCreateRequest request)
            {
                var auditorium = new Data.Entities.Auditorium()
                    {
                        Name = request.Name,
                        CinemaId = request.CinemaId,
                        NumberOfColumnSeats = request.SeatsPerRow,
                        NumberOfRowSeats = request.SeatsPerColumn,
                        SeatMapVector = string.Join("",request.Seats.Select(x => x.TypeId))
                    };
                cinemaDBContext.Auditoriums.Add(auditorium);
                await cinemaDBContext.SaveChangesAsync();
                return new AuditoriumViewModel()
                    {
                        Id = auditorium.Id,
                        Name = auditorium.Name,
                        CinemaId = auditorium.CinemaId,
                        SeatsPerRow = auditorium.NumberOfColumnSeats,
                        SeatsPerColumn = auditorium.NumberOfRowSeats
                    };
            }

        public async Task<int> Delete(int auditoriumId)
        {
            var auditorium = await cinemaDBContext.Auditoriums.FindAsync(auditoriumId);
            if (auditorium == null)
            {
                throw new Exception($"Cannot find a auditorium: {auditoriumId}");
            }
            cinemaDBContext.Auditoriums.Remove(auditorium);
            return await cinemaDBContext.SaveChangesAsync();
        }
    }
}
