using CinemaSolution.Data.EF;
using CinemaSolution.Data.Entities;
using CinemaSolution.ViewModels.Common.Paging;
using CinemaSolution.ViewModels.Invoice;
using CinemaSolution.ViewModels.Screening;
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

        public async Task<List<InvoiceViewModel>> GetInvoicesByUserId(int userId)
        {
            var query = from i in cinemaDBContext.Invoices
                        join u in cinemaDBContext.Users on i.UserId equals u.Id
                        join t in cinemaDBContext.Tickets on i.TicketId equals t.Id into tickets // Left join using `into`
                        from ticket in tickets.DefaultIfEmpty() // DefaultIfEmpty ensures the left join
                        join s in cinemaDBContext.Screenings on ticket.ScreeningId equals s.Id into screenings // Left join using `into`
                        from screening in screenings.DefaultIfEmpty() // DefaultIfEmpty ensures the left join
                        where i.UserId == userId
                        select new { Invoice = i, User = u, Ticket = ticket, Screening = screening };

            var invoices = query.Select(x => new InvoiceViewModel()
            {
                Id = x.Invoice.Id,
                User = new UserViewModel()
                {
                    Username = x.User.Username,
                    Email = x.User.Email,
                    Id = x.User.Id
                },
                Price = x.Invoice.Price,
                Discount = x.Invoice.Discount,
                SumPrice = x.Invoice.SumPrice,
                DateOfPurchase = x.Invoice.DateOfPurchase,
                Ticket = x.Ticket == null ? null : new TicketViewModel() // Check if the ticket is null
                {
                    Id = x.Ticket.Id,
                    Price = x.Ticket.Price,
                    Screening = new ScreeningViewModel()
                    {
                        Id = x.Screening.Id,
                        StartDate = x.Screening.StartDate,
                        StartTime = x.Screening.StartTime,
                    }
                }
            });

            return await invoices.ToListAsync();
        }
    }
}
