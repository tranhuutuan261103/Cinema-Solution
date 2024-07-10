using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaSolution.ViewModels.Category;

namespace CinemaSolution.Application.Category
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAllCategories();
    }
}
