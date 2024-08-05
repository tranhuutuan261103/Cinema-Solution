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
