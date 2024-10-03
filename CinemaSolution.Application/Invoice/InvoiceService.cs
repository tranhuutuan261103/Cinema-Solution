using CinemaSolution.Application.Screening;
using CinemaSolution.Data.EF;
using CinemaSolution.Data.Entities;
using CinemaSolution.ViewModels.Common.Paging;
using CinemaSolution.ViewModels.Invoice;
using CinemaSolution.ViewModels.Movie;
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
        private readonly IScreeningService _screeningService;
        public InvoiceService(CinemaDBContext cinemaDBContext, IScreeningService screeningService)
        {
            this.cinemaDBContext = cinemaDBContext;
            _screeningService = screeningService;
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
                        join m in cinemaDBContext.Movies on screening.MovieId equals m.Id // Inner join with Movies
                        join mi in cinemaDBContext.MovieImages on m.Id equals mi.MovieId into movieImages // Left join MovieImages
                        from movieImage in movieImages.DefaultIfEmpty() // Ensures left join
                        join mit in cinemaDBContext.MovieImageTypes on movieImage.Id equals mit.Id

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
                            Movie = m,
                            MovieImage = movieImage,
                            MovieImageType = mit,
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
                    x.Movie,
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
                            Movie = new MovieViewModel()
                            {
                                Id = g.Key.Movie.Id,
                                Title = g.Key.Movie.Title,
                                Rating = g.Key.Movie.Rating,
                                Duration = g.Key.Movie.Duration,
                                Actors = g.Key.Movie.Actors,
                                Director = g.Key.Movie.Director,
                                EndDate = g.Key.Movie.EndDate,
                                ReleaseDate = g.Key.Movie.ReleaseDate,
                                Language = g.Key.Movie.Language,
                                TrailerUrl = g.Key.Movie.TrailerUrl,
                                MovieImages = g.Where(x => x.Movie != null)
                                    .GroupBy(x => x.MovieImage.Id)
                                    .Select(y => y.First())
                                    .Select(y => new MovieImageViewModel()
                                    {
                                        Id = y.MovieImage.Id,
                                        ImageUrl = y.MovieImage.ImageUrl,
                                        ImageType = y.MovieImageType.Name
                                    }).ToList()
                            }
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

        public async Task<InvoiceViewModel?> GetInvoiceById(int id)
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
                        where i.Id == id
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
                });
            return groupedData.FirstOrDefault();
        }

        public async Task<InvoiceViewModel> Create(InvoiceCreateRequest request)
        {
            ScreeningViewModel screeningViewModel = await _screeningService.GetScreeningById(request.ScreeningId);

            if (request.Seats != null)
            {
                List<int> ints = request.Seats.Select(x => x.Id).ToList();
                var seats = await cinemaDBContext.Seats
                    .Where(x => ints.Contains(x.Id))
                    .ToListAsync();

                var seatPriceTables = await cinemaDBContext.DefaultPriceTables.Select(dpt => new SeatPriceViewModel
                {
                    SeatTypeId = dpt.SeatTypeId,
                    PersonTypeId = dpt.PersonTypeId,
                    Price = dpt.Price,
                }).ToListAsync();

                int totalPrice = 0;

                foreach (Seat seat in seats)
                {
                    if (seat.TicketId != null)
                    {
                        throw new Exception("Seat is already taken");
                    }
                    if (seat.SeatStatusId != 1)
                    {
                        throw new Exception("Seat is not available");
                    }
                    if (seat.ScreeningId != request.ScreeningId)
                    {
                        throw new Exception("Seat not available for this screening");
                    }

                    seat.SeatStatusId = 2;
                    seat.PersonTypeId = request.Seats.FirstOrDefault(x => x.Id == seat.Id).PersonTypeId;
                
                    totalPrice += seatPriceTables.FirstOrDefault(x => x.SeatTypeId == seat.SeatTypeId && x.PersonTypeId == seat.PersonTypeId).Price;
                }

                Ticket ticket = new Ticket()
                {
                    Price = totalPrice,
                    ScreeningId = request.ScreeningId,
                    Seats = seats,
                };

                cinemaDBContext.Tickets.Add(ticket);
                await cinemaDBContext.SaveChangesAsync();

                foreach (Seat seat in seats)
                {
                    seat.TicketId = ticket.Id;
                }

                cinemaDBContext.Seats.UpdateRange(seats);
                await cinemaDBContext.SaveChangesAsync();

                var invoice = new Data.Entities.Invoice()
                {
                    Price = ticket.Price,
                    Discount = 0,
                    SumPrice = ticket.Price,
                    DateOfPurchase = DateTime.Now,
                    TicketId = ticket.Id,
                    UserId = request.UserId,
                    OrderId = null
                };

                cinemaDBContext.Invoices.Add(invoice);
                await cinemaDBContext.SaveChangesAsync();

                return new InvoiceViewModel()
                {
                    Id = invoice.Id,
                    Price = invoice.Price,
                    Discount = invoice.Discount,
                    SumPrice = invoice.SumPrice,
                    DateOfPurchase = invoice.DateOfPurchase,
                    Ticket = new TicketViewModel()
                    {
                        Id = ticket.Id,
                        Price = ticket.Price,
                        Screening = new ScreeningViewModel()
                        {
                            Id = screeningViewModel.Id,
                            StartDate = screeningViewModel.StartDate,
                            StartTime = screeningViewModel.StartTime,
                        },
                        Seats = ticket.Seats.Select(x => new SeatViewModel()
                        {
                            Id = x.Id,
                            Row = x.Row,
                            Number = x.Number,
                        }).ToList()
                    },
                    User = new UserViewModel()
                    {
                        Id = request.UserId
                    },
                    Order = null,
                };
            }

            throw new Exception("No seats selected");
        }
    }
}
