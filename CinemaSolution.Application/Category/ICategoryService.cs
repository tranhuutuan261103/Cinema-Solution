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
        Task<PagedResult<CategoryViewModel>> GetAllCategories(GetCategoryPagingRequest request);
        Task<CategoryViewModel> GetCategoryById(int id);
        Task<CategoryViewModel> Create(CategoryCreateRequest request);
        Task<CategoryViewModel> Update(CategoryUpdateRequest request);
        Task<int> Delete(int id);
    }
}
