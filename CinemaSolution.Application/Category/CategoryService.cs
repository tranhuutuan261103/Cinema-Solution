using CinemaSolution.Data.EF;
using CinemaSolution.ViewModels.Category;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Application.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly CinemaDBContext cinemaDBContext;
        public CategoryService(CinemaDBContext cinemaDBContext)
        {
            this.cinemaDBContext = cinemaDBContext;
        }
        public async Task<List<CategoryViewModel>> GetAllCategories()
        {
            var query = from c in cinemaDBContext.Categories
                        where c.IsDeleted == false
                        select c;
            return await query.Select(c => new CategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name,
            }).ToListAsync();
        }
    }
}
