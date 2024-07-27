using CinemaSolution.Data.EF;
using CinemaSolution.Data.Entities;
using CinemaSolution.ViewModels.Category;
using CinemaSolution.ViewModels.Common.Paging;
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
        public async Task<PagedResult<CategoryViewModel>> GetAllCategories(GetCategoryPagingRequest request)
        {
            var query = from c in cinemaDBContext.Categories
                        where c.IsDeleted == false
                        select c;

            // Total records count
            int totalRow = await query.Select(c => c.Id).Distinct().CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToListAsync();

            var pagedResult = new PagedResult<CategoryViewModel>()
            {
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = totalRow,
            };
            return pagedResult;
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

        public async Task<CategoryViewModel> Update(CategoryUpdateRequest request)
        {
            var category = await cinemaDBContext.Categories.FindAsync(request.Id);
            if (category == null)
            {
                throw new Exception("Category not found");
            }
            category.Name = request.Name;
            await cinemaDBContext.SaveChangesAsync();
            return new CategoryViewModel()
            {
                Id = category.Id,
                Name = category.Name,
            };
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                var category = await cinemaDBContext.Categories.FindAsync(id);
                if (category == null)
                {
                    throw new Exception("Category not found");
                }
                category.IsDeleted = true;
                return await cinemaDBContext.SaveChangesAsync();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Delete category failed");
            }
        }
    }
}
