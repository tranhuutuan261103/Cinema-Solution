using CinemaSolution.Data.EF;
using CinemaSolution.Data.Entities;
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
        public async Task<CategoryViewModel> GetCategoryById(int id)
        {
            var category = await cinemaDBContext.Categories.FindAsync(id);
            if (category == null)
            {
                throw new Exception("Category not found");
            }
            return new CategoryViewModel()
            {
                Id = category.Id,
                Name = category.Name,
            };
        }

        public async Task<CategoryViewModel> Create(CategoryCreateRequest request)
        {
            Data.Entities.Category category = new Data.Entities.Category()
            {
                Name = request.Name,
                IsDeleted = false,
            };

            cinemaDBContext.Categories.Add(category);
            await cinemaDBContext.SaveChangesAsync();

            return new CategoryViewModel()
            {
                Id = category.Id,
                Name = category.Name,
            };
        }
    }
}
