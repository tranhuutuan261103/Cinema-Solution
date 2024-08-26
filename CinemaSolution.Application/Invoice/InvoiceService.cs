using CinemaSolution.Data.EF;
using CinemaSolution.ViewModels.Common.Paging;
using CinemaSolution.ViewModels.Invoice;
using CinemaSolution.ViewModels.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Application.Invoice
{
    public class InvoiceService : IInvoiceService
    {
        private readonly CinemaDBContext cinemaDBContext;
        public InvoiceService(CinemaDBContext cinemaDBContext)
        {
            this.cinemaDBContext = cinemaDBContext;
        }

        public async Task<int> GetCount()
        {
            return await cinemaDBContext.Invoices.CountAsync();
        }

        public async Task<decimal> GetTotalPrice()
        {
            return await cinemaDBContext.Invoices.SumAsync(x => x.SumPrice);
        }

        public async Task<PagedResult<InvoiceViewModel>> GetPagedResult(GetInvoicePagingRequest request)
        {
            var invoices = from i in cinemaDBContext.Invoices
                           join u in cinemaDBContext.Users on i.UserId equals u.Id
                           select new InvoiceViewModel()
                           {
                               Id = i.Id,
                               User = new UserViewModel()
                               {
                                   Username = u.Username,
                                   Email = u.Email,
                                   Id = u.Id
                               },
                               Price = i.Price,
                               Discount = i.Discount,
                               SumPrice = i.SumPrice,
                               DateOfPurchase = i.DateOfPurchase
                           };

            int count = await invoices.CountAsync();

            var data = await invoices.Skip((request.PageIndex - 1) * request.PageSize)
                                    .Take(request.PageSize)
                                    .ToListAsync();

            var pagedResult = new PagedResult<InvoiceViewModel>()
            {
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = count
            };

            return pagedResult;
        }
    }
}
