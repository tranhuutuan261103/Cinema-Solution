using CinemaSolution.Data.EF;
using CinemaSolution.ViewModels.Province;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Application.Province
{
    public class ProvinceService : IProvinceService
    {
        private readonly CinemaDBContext cinemaDBContext;
        public ProvinceService(CinemaDBContext cinemaDBContext)
        {
            this.cinemaDBContext = cinemaDBContext;
        }
        public async Task<List<ProvinceViewModel>> GetAll()
        {
            return await cinemaDBContext.Provinces.Select(
                p => new ProvinceViewModel
                {
                    Id = p.Id,
                    Name = p.Name
                }).ToListAsync();
        }
    }
}
