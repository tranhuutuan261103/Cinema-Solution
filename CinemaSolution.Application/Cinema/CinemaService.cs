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

        public async Task<CinemaViewModel> Create(CinemaCreateRequest request)
        {
            try
            {
                var cinema = new Data.Entities.Cinema()
                {
                    Name = request.Name,
                    ProvinceId = request.ProvinceId,
                    Address = request.Address,
                    IsDeleted = false
                };
                cinemaDBContext.Cinemas.Add(cinema);
                await cinemaDBContext.SaveChangesAsync();

                var province = await cinemaDBContext.Provinces.FindAsync(request.ProvinceId);

                return new CinemaViewModel
                {
                    Id = cinema.Id,
                    Name = cinema.Name,
                    Province = new ProvinceViewModel
                    {
                        Id = cinema.ProvinceId,
                        Name = province?.Name
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
    }
}
