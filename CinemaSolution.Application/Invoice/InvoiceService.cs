using CinemaSolution.Data.EF;
using CinemaSolution.Data.Entities;
using CinemaSolution.ViewModels.Common.Paging;
using CinemaSolution.ViewModels.Invoice;
using CinemaSolution.ViewModels.Screening;
using CinemaSolution.ViewModels.Seat;
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

        //public async Task<List<InvoiceViewModel>> GetInvoicesByUserId(int userId)
        //{
        //    var query = from i in cinemaDBContext.Invoices
        //                join u in cinemaDBContext.Users on i.UserId equals u.Id
        //                join t in cinemaDBContext.Tickets on i.TicketId equals t.Id into tickets // Left join using `into`
        //                from ticket in tickets.DefaultIfEmpty() // DefaultIfEmpty ensures the left join
        //                join s in cinemaDBContext.Screenings on ticket.ScreeningId equals s.Id into screenings // Left join using `into`
        //                from screening in screenings.DefaultIfEmpty() // DefaultIfEmpty ensures the left join
        //                join ss in cinemaDBContext.Seats on ticket.Id equals ss.Id into seats
        //                from seat in seats.DefaultIfEmpty()
        //                where i.UserId == userId
        //                select new { Invoice = i, User = u, Ticket = ticket, Screening = screening, Seat = seat };

        //    var invoices = query.Select(x => new InvoiceViewModel()
        //    {
        //        Id = x.Invoice.Id,
        //        User = new UserViewModel()
        //        {
        //            Username = x.User.Username,
        //            Email = x.User.Email,
        //            Id = x.User.Id
        //        },
        //        Price = x.Invoice.Price,
        //        Discount = x.Invoice.Discount,
        //        SumPrice = x.Invoice.SumPrice,
        //        DateOfPurchase = x.Invoice.DateOfPurchase,
        //        Ticket = x.Ticket == null ? null : new TicketViewModel() // Check if the ticket is null
        //        {
        //            Id = x.Ticket.Id,
        //            Price = x.Ticket.Price,
        //            Screening = new ScreeningViewModel()
        //            {
        //                Id = x.Screening.Id,
        //                StartDate = x.Screening.StartDate,
        //                StartTime = x.Screening.StartTime,
        //            }
        //        }
        //    });

        //    return await invoices.ToListAsync();
        //}

        public async Task<List<InvoiceViewModel>> GetInvoicesByUserId(int userId)
        {
            var query = from i in cinemaDBContext.Invoices
                        join t in cinemaDBContext.Tickets on i.TicketId equals t.Id into tickets // Left join Tickets
                        from ticket in tickets.DefaultIfEmpty() // Ensures left join
                        join s in cinemaDBContext.Screenings on ticket.ScreeningId equals s.Id into screenings // Left join Screenings
                        from screening in screenings.DefaultIfEmpty() // Ensures left join
                        join u in cinemaDBContext.Users on i.UserId equals u.Id // Inner join with Users
                        join seat in cinemaDBContext.Seats on ticket.Id equals seat.TicketId into seats // Left join Seats
                        from seat in seats.DefaultIfEmpty() // Ensures left join

                        join o in cinemaDBContext.Orders on i.OrderId equals o.Id into orders
                        from order in orders.DefaultIfEmpty()
                        join pcio in cinemaDBContext.ProductComboInOrders on order.Id equals pcio.OrderId into productComboInOrders
                        from pcio in productComboInOrders.DefaultIfEmpty()
                        join pc in cinemaDBContext.ProductCombos on pcio.ProductComboId equals pc.Id into productCombos
                        from productCombo in productCombos.DefaultIfEmpty()
                        where i.UserId == userId
                        select new
                        {
                            Invoice = i,
                            User = u,
                            Ticket = ticket,
                            Order = order,
                            Screening = screening,
                            Seat = seat,
                            ProductComboInOrder = pcio,
                            ProductCombo = productCombo
                        };

            // Execute the query and bring the result set into memory
            var raw = await query.ToListAsync();

            // Group data in memory to avoid EF Core translation issues
            var groupedData = raw
                .GroupBy(x => new
                {
                    x.Invoice,
                    x.User,
                    x.Ticket,
                    x.Order,
                    x.Screening,
                })
                .Select(g => new InvoiceViewModel()
                {
                    Id = g.Key.Invoice.Id,
                    User = new UserViewModel()
                    {
                        Username = g.Key.User.Username,
                        Email = g.Key.User.Email,
                        Id = g.Key.User.Id
                    },
                    Price = g.Key.Invoice.Price,
                    Discount = g.Key.Invoice.Discount,
                    SumPrice = g.Key.Invoice.SumPrice,
                    DateOfPurchase = g.Key.Invoice.DateOfPurchase,
                    Ticket = g.Key.Ticket == null ? null : new TicketViewModel()
                    {
                        Id = g.Key.Ticket.Id,
                        Price = g.Key.Ticket.Price,
                        Screening = g.Key.Screening == null ? new ScreeningViewModel() : new ScreeningViewModel()
                        {
                            Id = g.Key.Screening.Id,
                            StartDate = g.Key.Screening.StartDate,
                            StartTime = g.Key.Screening.StartTime,
                        },
                        Seats = g.Where(x => x.Seat != null).Select(y => new SeatViewModel()
                        {
                            Id = y.Seat.Id,
                            Row = y.Seat.Row,
                            Number = y.Seat.Number,
                        }).ToList()
                    },
                    Order = g.Key.Order == null ? null : new OrderViewModel()
                    {
                        Id = g.Key.Order.Id,
                        // Use distinct grouping to prevent duplicate ProductCombos
                        ProductCombos = g
                            .Where(x => x.ProductCombo != null && x.ProductComboInOrder != null)
                            .GroupBy(x => new { x.ProductCombo.Id, x.ProductComboInOrder.Quantity }) // Group by unique properties
                            .Select(y => y.First()) // Take first to avoid duplicates
                            .Select(y => new ProductComboViewModel()
                            {
                                Id = y.ProductCombo.Id,
                                Name = y.ProductCombo.Name,
                                Price = y.ProductCombo.Price,
                                Description = y.ProductCombo.Description,
                                ImageUrl = y.ProductCombo.ImageUrl,
                                Quantity = y.ProductComboInOrder.Quantity,
                            })
                            .ToList(),
                        TotalPrice = g.Key.Order.TotalPrice,
                    }
                })
                .ToList();

            return groupedData;
        }
    }
}
