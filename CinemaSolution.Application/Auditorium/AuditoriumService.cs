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

        public async Task<PagedResult<AuditoriumViewModel>> GetPagedResult(GetAuditoriumPagingRequest request)
        {
            var query = from a in cinemaDBContext.Auditoriums
                        join c in cinemaDBContext.Cinemas on a.CinemaId equals c.Id
                        join p in cinemaDBContext.Provinces on a.ProvinceId equals p.Id
                        select new AuditoriumViewModel()
                        {
                            Id = a.Id,
                            Name = a.Name,
                            Cinema = new ViewModels.Cinema.CinemaViewModel()
                            {
                                Id = c.Id,
                                Name = c.Name
                            },
                            Province = new ViewModels.Province.ProvinceViewModel()
                            {
                                Id = p.Id,
                                Name = p.Name
                            },
                            SeatsPerRow = a.NumberOfColumnSeats,
                            SeatsPerColumn = a.NumberOfRowSeats,
                            Address = a.Address,
                            Latitude = a.Latitude,
                            Longitude = a.Longitude,
                        };
            if (request.CinemaId.HasValue)
            {
                query = query.Where(x => x.Cinema.Id == request.CinemaId);
            }
            if (request.ProvinceId.HasValue)
            {
                query = query.Where(x => x.Province.Id == request.ProvinceId);
            }
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.Name.Contains(request.Keyword));
            }

            var totalRecords = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();
            var result = new PagedResult<AuditoriumViewModel>()
            {
                Items = data,
                TotalRecords = totalRecords,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
            return result;
        }
        public async Task<PagedResult<AuditoriumViewModel>> GetByCinemaId(int cinemaId)
        {
            var query = from a in cinemaDBContext.Auditoriums
                        join c in cinemaDBContext.Cinemas on a.CinemaId equals c.Id
                        where a.CinemaId == cinemaId
                        select new AuditoriumViewModel()
                        {
                            Id = a.Id,
                            Name = a.Name,
                            Cinema = new ViewModels.Cinema.CinemaViewModel()
                            {
                                Id = c.Id,
                                Name = c.Name
                            },
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

        public async Task<AuditoriumViewModel> GetById(int auditoriumId)
        {
            var auditoriumQuery = from a in cinemaDBContext.Auditoriums
                                  join c in cinemaDBContext.Cinemas on a.CinemaId equals c.Id
                                  where a.Id == auditoriumId
                                  select new AuditoriumViewModel()
                                  {
                                      Id = a.Id,
                                      Name = a.Name,
                                      Cinema = new ViewModels.Cinema.CinemaViewModel()
                                      {
                                          Id = c.Id,
                                          Name = c.Name
                                      },
                                      SeatsPerRow = a.NumberOfColumnSeats,
                                      SeatsPerColumn = a.NumberOfRowSeats,
                                      SeatMapVector = a.SeatMapVector
                                  };
            var auditorium = await auditoriumQuery.FirstOrDefaultAsync();
            if (auditorium == null)
            {
                throw new Exception($"Cannot find a auditorium: {auditoriumId}");
            }
            return auditorium;
        }

        public async Task<AuditoriumViewModel> Create(AuditoriumCreateRequest request)
        {
            var cinema = await cinemaDBContext.Cinemas.FindAsync(request.CinemaId);
            if (cinema == null)
            {
                throw new Exception($"Cannot find a cinema: {request.CinemaId}");
            }
            var auditorium = new Data.Entities.Auditorium()
                {
                    Name = request.Name,
                    CinemaId = request.CinemaId,
                    Address = request.Address,
                    Latitude = request.Latitude,
                    Longitude = request.Longitude,
                    ProvinceId = request.ProvinceId,
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
                Cinema = new ViewModels.Cinema.CinemaViewModel() 
                {
                    Id = cinema.Id,
                    Name = cinema.Name
                },
                SeatsPerRow = auditorium.NumberOfColumnSeats,
                SeatsPerColumn = auditorium.NumberOfRowSeats
            };
        }

        public async Task<AuditoriumViewModel> Update(AuditoriumUpdateRequest request)
        {
            var auditorium = await cinemaDBContext.Auditoriums.FindAsync(request.Id);
            if (auditorium == null)
            {
                throw new Exception($"Cannot find a auditorium: {request.Id}");
            }
            var cinema = await cinemaDBContext.Cinemas.FindAsync(request.CinemaId);
            if (cinema == null)
            {
                throw new Exception($"Cannot find a cinema: {request.CinemaId}");
            }
            auditorium.Name = request.Name;
            auditorium.CinemaId = request.CinemaId;
            auditorium.Address = request.Address;
            auditorium.Latitude = request.Latitude;
            auditorium.Longitude = request.Longitude;
            auditorium.ProvinceId = request.ProvinceId;
            auditorium.NumberOfColumnSeats = request.SeatsPerRow;
            auditorium.NumberOfRowSeats = request.SeatsPerColumn;
            auditorium.SeatMapVector = string.Join("", request.Seats.Select(x => x.TypeId));
            await cinemaDBContext.SaveChangesAsync();
            return new AuditoriumViewModel()
            {
                Id = auditorium.Id,
                Name = auditorium.Name,
                Cinema = new ViewModels.Cinema.CinemaViewModel()
                {
                    Id = cinema.Id,
                    Name = cinema.Name
                },
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
