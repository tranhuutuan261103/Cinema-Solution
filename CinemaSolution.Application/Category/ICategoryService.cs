using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaSolution.ViewModels.Category;
using CinemaSolution.ViewModels.Common.Paging;

namespace CinemaSolution.Application.Category
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAllCategories();
        Task<PagedResult<CategoryViewModel>> GetPagedResult(GetCategoryPagingRequest request);
        Task<CategoryViewModel> GetCategoryById(int id);
        Task<CategoryViewModel> Create(CategoryCreateRequest request);
        Task<CategoryViewModel> Update(CategoryUpdateRequest request);
        Task<bool> Delete(int id);
    }
}
