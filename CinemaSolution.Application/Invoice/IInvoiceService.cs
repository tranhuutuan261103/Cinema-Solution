using CinemaSolution.ViewModels.Common.Paging;
using CinemaSolution.ViewModels.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Application.Invoice
{
    public interface IInvoiceService
    {
        Task<int> GetCount();
        Task<decimal> GetTotalPrice();
        Task<PagedResult<InvoiceViewModel>> GetPagedResult(GetInvoicePagingRequest request);
        Task<List<InvoiceViewModel>> GetInvoicesByUserId(int userId);
        Task<InvoiceViewModel> Create(InvoiceCreateRequest request);
    }
}
