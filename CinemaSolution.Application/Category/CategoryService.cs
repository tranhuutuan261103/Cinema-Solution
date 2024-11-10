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

        public async Task<List<CategoryViewModel>> GetAllCategories()
        {
            var categories = await cinemaDBContext.Categories
                .Where(c => c.IsDeleted == false)
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToListAsync();
            return categories;
        }
        public async Task<PagedResult<CategoryViewModel>> GetPagedResult(GetCategoryPagingRequest request)
        {
            var query = from c in cinemaDBContext.Categories
                        where c.IsDeleted == false && string.IsNullOrEmpty(request.Keyword) || c.Name.Contains(request.Keyword)
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

        public async Task<bool> Delete(int id)
        {
            var category = await cinemaDBContext.Categories.FindAsync(id);
            if (category == null)
            {
                throw new InvalidOperationException("Category not found");
            }

            category.IsDeleted = true;

            // Sử dụng SaveChangesAsync() để cập nhật và trả về true nếu thành công
            return await cinemaDBContext.SaveChangesAsync() > 0;
        }

    }
}
