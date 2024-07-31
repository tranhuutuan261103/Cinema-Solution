using CinemaSolution.Data.EF;
using CinemaSolution.ViewModels.Cinema;
using CinemaSolution.ViewModels.Common.Paging;
using CinemaSolution.ViewModels.Province;
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
                        join p in cinemaDBContext.Provinces on c.ProvinceId equals p.Id
                        where c.IsDeleted == false && (string.IsNullOrEmpty(request.Keyword) || c.Name.Contains(request.Keyword))
                        select new { c, p };
            if (request.ProvinceId != null)
            {
                query = query.Where(x => x.c.ProvinceId == request.ProvinceId);
            }
            var totalRow = await query.CountAsync();
            var data = await query
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(
                x => new CinemaViewModel
                {
                    Id = x.c.Id,
                    Name = x.c.Name,
                    Province = new ProvinceViewModel
                    {
                        Id = x.p.Id,
                        Name = x.p.Name
                    },
                    Address = x.c.Address,
                    IsDeleted = x.c.IsDeleted
                }).ToListAsync();
            var pagedResult = new PagedResult<CinemaViewModel>
            {
                TotalRecords = totalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<CinemaViewModel> GetById(int id)
        {
            var cinema = await cinemaDBContext.Cinemas.FindAsync(id);
            if (cinema == null)
            {
                throw new Exception("Cinema not found");
            }
            var province = await cinemaDBContext.Provinces.FindAsync(cinema.ProvinceId);
            if (province == null)
            {
                throw new Exception("Province not found");
            }
            return new CinemaViewModel
            {
                Id = cinema.Id,
                Name = cinema.Name,
                Province = new ProvinceViewModel
                {
                    Id = province.Id,
                    Name = province.Name
                },
                Address = cinema.Address,
                IsDeleted = cinema.IsDeleted
            };
        }

        public async Task<CinemaViewModel> Create(CinemaCreateRequest request)
        {
            try
            {
                var province = await cinemaDBContext.Provinces.FindAsync(request.ProvinceId);

                if (province == null)
                {
                    throw new Exception("Province not found");
                }

                var cinema = new Data.Entities.Cinema()
                {
                    Name = request.Name,
                    ProvinceId = request.ProvinceId,
                    Address = request.Address,
                    IsDeleted = false
                };
                cinemaDBContext.Cinemas.Add(cinema);
                await cinemaDBContext.SaveChangesAsync();

                return new CinemaViewModel
                {
                    Id = cinema.Id,
                    Name = cinema.Name,
                    Province = new ProvinceViewModel
                    {
                        Id = cinema.ProvinceId,
                        Name = province.Name
                    },
                    Address = cinema.Address,
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
                var province = await cinemaDBContext.Provinces.FindAsync(request.ProvinceId);
                if (province == null)
                {
                    throw new Exception("Province not found");
                }
                cinema.Name = request.Name;
                cinema.ProvinceId = request.ProvinceId;
                cinema.Address = request.Address;
                await cinemaDBContext.SaveChangesAsync();
                return new CinemaViewModel
                {
                    Id = cinema.Id,
                    Name = cinema.Name,
                    Province = new ProvinceViewModel
                    {
                        Id = cinema.ProvinceId,
                        Name = province.Name
                    },
                    Address = cinema.Address,
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
