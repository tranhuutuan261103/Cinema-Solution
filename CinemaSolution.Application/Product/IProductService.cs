using CinemaSolution.ViewModels.Common.Paging;
using CinemaSolution.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Application.Product
{
    public interface IProductService
    {
        Task<List<ProductComboViewModel>> GetProductCombos();
        Task<PagedResult<ProductComboViewModel>> GetPagedResult(GetProductPagingRequest request);
        Task<ProductComboViewModel?> GetById(int id);
    }
}
