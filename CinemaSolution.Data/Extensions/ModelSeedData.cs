using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaSolution.Data.Entities;
using CinemaSolution.Common;
using Microsoft.EntityFrameworkCore;

namespace CinemaSolution.Data.Extensions
{
    public static class ModelSeedData
    {
        public static void Seeding(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    Id = 1,
                    Name = "Administrator",
                    Description = "Administrator"
                },
                new Role()
                {
                    Id = 2,
                    Name = "User",
                    Description = "User"
                }
            );



            GeneratePassword admimPass = new GeneratePassword("admin");
            GeneratePassword userPass = new GeneratePassword("user");

            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    Username = "admin",
                    PasswordSalt = admimPass.GetSalt(),
                    PasswordHash = admimPass.GetPasswordHash(),
                    FirstName = "Admin",
                    LastName = "Admin",
                    Email = "admin@gmail.com",
                    Address = "Address",
                    PhoneNumber = "0482648163",
                    IsDeleted = false,
                },
                new User()
                {
                    Id = 2,
                    Username = "user",
                    PasswordSalt = userPass.GetSalt(),
                    PasswordHash = userPass.GetPasswordHash(),
                    FirstName = "User",
                    LastName = "User",
                    Email = "user@email.com",
                    Address = "Address",
                    PhoneNumber = "0481726361",
                    IsDeleted = false,
                },
                new User()
                {
                    Id = 3,
                    Username = "user2",
                    PasswordSalt = userPass.GetSalt(),
                    PasswordHash = userPass.GetPasswordHash(),
                    FirstName = "User2",
                    LastName = "User2",
                    Email = "user2@email.com",
                    Address = "Address",
                    PhoneNumber = "0382736162",
                    IsDeleted = false,
                }
            );

            modelBuilder.Entity<UserInRole>().HasData(
                new UserInRole()
                {
                    UserId = 1,
                    RoleId = 1
                },
                new UserInRole()
                {
                    UserId = 1,
                    RoleId = 2
                },
                new UserInRole()
                {
                    UserId = 2,
                    RoleId = 2
                },
                new UserInRole()
                {
                    UserId = 3,
                    RoleId = 2
                }
            );

            // Category
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    Name = "Action",
                },
                new Category()
                {
                    Id = 2,
                    Name = "Adventure",
                },
                new Category()
                {
                    Id = 3,
                    Name = "Animation",
                },
                new Category()
                {
                    Id = 4,
                    Name = "Comedy",
                },
                new Category()
                {
                    Id = 5,
                    Name = "Crime",
                },
                new Category()
                {
                    Id = 6,
                    Name = "Documentary",
                },
                new Category()
                {
                    Id = 7,
                    Name = "Drama",
                }
            );

            modelBuilder.Entity<Movie>().HasData(
                new Movie()
                {
                    Id = 1,
                    Title = "The Old Guard",
                    Description = "Four undying warriors who've secretly protected humanity for centuries become targeted for their mysterious powers just as they discover a new immortal.",
                    Duration = 125,
                    Rating = 9,
                    Language = "English",
                    TrailerUrl = "https://www.youtube.com/embed/aK-X2d0lJ_s",
                    IsDeleted = false,
                    Director = "Gina Prince-Bythewood",
                    Actors = "Charlize Theron, KiKi Layne, Marwan Kenzari, Luca Marinelli, Harry Melling",
                    ReleaseDate = new DateTime(2024, 5, 20),
                    EndDate = new DateTime(2024, 12, 20)
                },
                new Movie()
                {
                    Id = 2,
                    Title = "The Kissing Booth 2",
                    Description = "In the sequel to 2018's THE KISSING BOOTH, high school senior Elle juggles a long-distance relationship with her dreamy boyfriend Noah, college applications, and a new friendship with a handsome classmate that could change everything.",
                    Duration = 130,
                    Rating = 7,
                    Language = "English",
                    TrailerUrl = "https://www.youtube.com/embed/ZR2JlDnT2l8",
                    IsDeleted = false,
                    Director = "Vince Marcello",
                    Actors = "Joey King, Joel Courtney, Jacob Elordi",
                    ReleaseDate = new DateTime(2024, 5, 20),
                    EndDate = new DateTime(2024, 12, 20)
                }
            );

            // MovieCategory
            modelBuilder.Entity<MovieInCategory>().HasData(
               new MovieInCategory()
               {
                   MovieId = 1,
                   CategoryId = 1
               },
                new MovieInCategory()
                {
                    MovieId = 1,
                    CategoryId = 2
                },
                new MovieInCategory()
                {
                    MovieId = 1,
                    CategoryId = 3
                },
                new MovieInCategory()
                {
                    MovieId = 2,
                    CategoryId = 4
                },
                new MovieInCategory()
                {
                    MovieId = 2,
                    CategoryId = 5
                },
                new MovieInCategory()
                {
                    MovieId = 2,
                    CategoryId = 6
                }
            );


            // MovieImageType
            modelBuilder.Entity<MovieImageType>().HasData(
                new MovieImageType()
                {
                    Id = 1,
                    Name = "Poster",
                    Description = "Poster"
                },
                new MovieImageType()
                {
                    Id = 2,
                    Name = "Backdrop",
                    Description = "Backdrop"
                }
            );

            // MovieImage
            modelBuilder.Entity<MovieImage>().HasData(
                new MovieImage()
                {
                    Id = 1,
                    MovieId = 1,
                    MovieImageTypeId = 1,
                    ImageUrl = "https://image.tmdb.org/t/p/w500/7D430eqZj8y3oVkLFfsWXGRcpEG.jpg",
                    IsPoster = true,
                },
                new MovieImage()
                {
                    Id = 2,
                    MovieId = 1,
                    MovieImageTypeId = 2,
                    ImageUrl = "https://image.tmdb.org/t/p/w500/5aXp2s4l6g5PcMMesIj63mx8hmJ.jpg",
                    IsPoster = false,
                },
                new MovieImage()
                {
                    Id = 3,
                    MovieId = 2,
                    MovieImageTypeId = 1,
                    ImageUrl = "https://image.tmdb.org/t/p/w500/7D430eqZj8y3oVkLFfsWXGRcpEG.jpg",
                    IsPoster = true,
                },
                new MovieImage()
                {
                    Id = 4,
                    MovieId = 2,
                    MovieImageTypeId = 2,
                    ImageUrl = "https://image.tmdb.org/t/p/w500/5aXp2s4l6g5PcMMesIj63mx8hmJ.jpg",
                    IsPoster = false,
                });

            // Comment
            modelBuilder.Entity<Comment>().HasData(
                new Comment()
                {
                    Id = 1,
                    MovieId = 1,
                    UserId = 2,
                    Content = "This is a comment",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                },
                new Comment()
                {
                    Id = 2,
                    MovieId = 1,
                    UserId = 3,
                    Content = "This is a comment",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                }
            );

            // Rating
            modelBuilder.Entity<Rating>().HasData(
                new Rating()
                {
                    MovieId = 1,
                    UserId = 2,
                    Value = 10
                },
                new Rating()
                {
                    MovieId = 1,
                    UserId = 3,
                    Value = 8
                },
                new Rating()
                {
                    MovieId = 2,
                    UserId = 2,
                    Value = 6
                },
                new Rating()
                {
                    MovieId = 2,
                    UserId = 3,
                    Value = 8
                }
            );

            modelBuilder.Entity<Province>().HasData(
                new Province()
                {
                    Id = 1,
                    Name = "Hà Nội"
                },
                               new Province()
                               {
                                   Id = 2,
                                   Name = "Đà Nẵng"
                               }
            );

            modelBuilder.Entity<Cinema>().HasData(
                new Cinema()
                {
                    Id = 1,
                    Name = "CGV Hà Nội",
                    Address = "Hà Nội",
                    ProvinceId = 1
                },
                new Cinema()
                {
                    Id = 2,
                    Name = "CGV Đà Nẵng",
                    Address = "Đà Nẵng",
                    ProvinceId = 2
                }
            );

            modelBuilder.Entity<Auditorium>().HasData(
                new Auditorium()
                {
                    Id = 1,
                    Name = "A1",
                    CinemaId = 1,
                    SeatMapVector = "111111111111|111111111111|222222222222|222222222222|222222222222|111111111111|111111111111|111111111111|111111111111|111111111111|111111111111|111111111111"
                },
                new Auditorium()
                {
                    Id = 2,
                    Name = "A2",
                    CinemaId = 1,
                    SeatMapVector = "111111111111|111111111111|222222222222|222222222222|222222222222|111111111111|111111111111|111111111111|111111111111|111111111111|111111111111|111111111111"
                },
                new Auditorium()
                {
                    Id = 3,
                    Name = "A3",
                    CinemaId = 2,
                    SeatMapVector = "111111111111|111111111111|222222222222|222222222222|222222222222|111111111111|111111111111|111111111111|111111111111|111111111111|111111111111|111111111111"
                },
                new Auditorium()
                {
                    Id = 4,
                    Name = "A4",
                    CinemaId = 2,
                    SeatMapVector = "111111111111|111111111111|222222222222|222222222222|222222222222|111111111111|111111111111|111111111111|111111111111|111111111111|111111111111|111111111111"
                }
            );

            modelBuilder.Entity<Screening>().HasData(new Screening()
            {
                Id = 1,
                MovieId = 1,
                AuditoriumId = 1,
                StartDate = new DateTime(2024, 5, 20),
                StartTime = new TimeSpan(10, 0, 0),
                IsDeleted = false
            },
                new Screening()
                {
                    Id = 2,
                    MovieId = 1,
                    AuditoriumId = 1,
                    StartDate = new DateTime(2024, 5, 20),
                    StartTime = new TimeSpan(20, 0, 0),
                    IsDeleted = false
                },
                new Screening()
                {
                    Id = 3,
                    MovieId = 1,
                    AuditoriumId = 2,
                    StartDate = new DateTime(2024, 5, 20),
                    StartTime = new TimeSpan(20, 0, 0),
                    IsDeleted = false
                },
                new Screening()
                {
                    Id = 4,
                    MovieId = 2,
                    AuditoriumId = 3,
                    StartDate = new DateTime(2024, 5, 20),
                    StartTime = new TimeSpan(20, 0, 0),
                    IsDeleted = false
                }
            );

            modelBuilder.Entity<SeatType>().HasData(
                new SeatType()
                {
                    Id = 1,
                    Name = "Normal",
                    Description = "Normal",
                },
                new SeatType()
                {
                    Id = 2,
                    Name = "VIP",
                    Description = "VIP",
                }
            );

            modelBuilder.Entity<SeatStatus>().HasData(
                new SeatStatus()
                {
                    Id = 1,
                    StatusName = "Có thể đặt",
                    StatusDescription = "Có thể đặt"
                },
                new SeatStatus()
                {
                    Id = 2,
                    StatusName = "Không thể đặt",
                    StatusDescription = "Không thể đặt"
                }
            );

            modelBuilder.Entity<PersonType>().HasData(
                new PersonType()
                {
                    Id = 1,
                    Name = "Người lớn",
                    Description = "Người lớn từ 12 đến 60 tuổi"
                },
                new PersonType()
                {
                    Id = 2,
                    Name = "Trẻ em và người lớn tuổi",
                    Description = "Trẻ em từ 0 đến 12 tuổi và người lớn từ 60 tuổi trở lên"
                },
                new PersonType()
                {
                    Id = 3,
                    Name = "Sinh viên",
                    Description = "Sinh viên có thẻ"
                }
            );


            modelBuilder.Entity<Ticket>().HasData(
                new Ticket()
                {
                    Id = 1,
                    ScreeningId = 1,
                    Price = 80000,
                },
                new Ticket()
                {
                    Id = 2,
                    ScreeningId = 1,
                    Price = 80000,
                },
                new Ticket()
                {
                    Id = 3,
                    ScreeningId = 1,
                    Price = 80000,
                });

            List<Seat> seats = new List<Seat>();
            for (int k = 0; k < 4; k++)
            {
                for (int i = 0; i < 12; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        seats.Add(new Seat()
                        {
                            Id = k * 12 * 12 + i * 12 + j + 1,
                            Row = i + 1,
                            Number = j + 1,
                            SeatTypeId = 2,
                            SeatStatusId = 1,
                            ScreeningId = k + 1
                        });
                    }
                }
            }

            foreach (var seat in seats)
            {
                if (seat.Id == 1)
                {
                    seat.SeatTypeId = 1;
                    seat.SeatStatusId = 2;
                    seat.TicketId = 1;
                    seat.PersonTypeId = 1;
                }

                if (seat.Id == 2)
                {
                    seat.SeatTypeId = 1;
                    seat.SeatStatusId = 2;
                    seat.TicketId = 2;
                    seat.PersonTypeId = 1;
                }

                if (seat.Id == 3)
                {
                    seat.SeatTypeId = 1;
                    seat.SeatStatusId = 2;
                    seat.TicketId = 3;
                    seat.PersonTypeId = 1;
                }
            }

            modelBuilder.Entity<Seat>().HasData(seats);

            modelBuilder.Entity<DefaultPriceTable>().HasData(
                new DefaultPriceTable()
                {
                    PersonTypeId = 1,
                    SeatTypeId = 1,
                    Price = 80000
                },
                new DefaultPriceTable()
                {
                    PersonTypeId = 2,
                    SeatTypeId = 1,
                    Price = 60000
                },
                new DefaultPriceTable()
                {
                    PersonTypeId = 3,
                    SeatTypeId = 1,
                    Price = 50000
                },
                new DefaultPriceTable()
                {
                    PersonTypeId = 1,
                    SeatTypeId = 2,
                    Price = 100000
                },
                new DefaultPriceTable()
                {
                    PersonTypeId = 2,
                    SeatTypeId = 2,
                    Price = 80000
                },
                new DefaultPriceTable()
                {
                    PersonTypeId = 3,
                    SeatTypeId = 2,
                    Price = 70000
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    Name = "Bắp rang",
                    Description = "Bắp rang",
                    IsDeleted = false
                },
                new Product()
                {
                    Id = 2,
                    Name = "Nước ngọt size L",
                    Description = "Nước ngọt size L",
                    IsDeleted = false
                },
                new Product()
                {
                    Id = 3,
                    Name = "Snack",
                    Description = "Snack",
                    IsDeleted = false
                },
                new Product()
                {
                    Id = 4,
                    Name = "OP Head",
                    Description = "OP Head",
                    IsDeleted = false
                }
            );

            modelBuilder.Entity<ProductCombo>().HasData(
                new ProductCombo()
                {
                    Id = 1,
                    Name = "iCombo 1 Big Extra STD",
                    Description = "1 Ly nước ngọt size L + 01 Hộp bắp + 1 Snack",
                    ImageUrl = "https://www.galaxycine.vn/media/2023/3/31/menuboard-combo1-2-2022-coonline-combo1_1680280126585.jpg",
                    Price = 109000,
                    IsDeleted = false
                },
                new ProductCombo()
                {
                    Id = 2,
                    Name = "Combo 2",
                    Description = "Combo 2",
                    ImageUrl = "https://www.galaxycine.vn/media/2023/3/31/menuboard-combo1-2-2022-coonline-combo2_1680280172153.jpg",
                    Price = 129000,
                    IsDeleted = false
                },
                new ProductCombo()
                {
                    Id = 3,
                    Name = "iCombo Optimus Prime 1",
                    Description = "01 OP Head + 01 ly nước ngọt size L + 01 Hộp bắp + FREE Up Vị bất kỳ",
                    ImageUrl = "https://www.galaxycine.vn/media/2023/6/8/combooptimus-co-onl1_1686238609745.jpg",
                    Price = 369000,
                    IsDeleted = false
                });


            modelBuilder.Entity<ProductInProductCombo>().HasData(
                new ProductInProductCombo()
                {
                    ProductId = 1,
                    ProductComboId = 1,
                    Quantity = 1
                },
                new ProductInProductCombo()
                {
                    ProductId = 2,
                    ProductComboId = 1,
                    Quantity = 1
                },
                new ProductInProductCombo()
                {
                    ProductId = 3,
                    ProductComboId = 1,
                    Quantity = 1
                },
                new ProductInProductCombo()
                {
                    ProductId = 1,
                    ProductComboId = 2,
                    Quantity = 2
                },
                new ProductInProductCombo()
                {
                    ProductId = 2,
                    ProductComboId = 2,
                    Quantity = 1
                },
                new ProductInProductCombo()
                {
                    ProductId = 3,
                    ProductComboId = 2,
                    Quantity = 1
                },
                new ProductInProductCombo()
                {
                    ProductId = 1,
                    ProductComboId = 3,
                    Quantity = 1
                },
                new ProductInProductCombo()
                {
                    ProductId = 2,
                    ProductComboId = 3,
                    Quantity = 1
                },
                new ProductInProductCombo()
                {
                    ProductId = 4,
                    ProductComboId = 3,
                    Quantity = 1
                }
                );

            modelBuilder.Entity<Order>().HasData(
                new Order()
                {
                    Id = 1,
                    TotalPrice = 109000,
                    IsDeleted = false
                },
                new Order()
                {
                    Id = 2,
                    TotalPrice = 129000,
                    IsDeleted = false
                },
                new Order()
                {
                    Id = 3,
                    TotalPrice = 109000,
                    IsDeleted = false
                }
                );

            modelBuilder.Entity<ProductComboInOrder>().HasData(
                new ProductComboInOrder()
                {
                    OrderId = 1,
                    ProductComboId = 1,
                    Quantity = 1,
                    Price = 109000
                },
                new ProductComboInOrder()
                {
                    OrderId = 2,
                    ProductComboId = 2,
                    Quantity = 1,
                    Price = 129000
                },
                new ProductComboInOrder()
                {
                    OrderId = 3,
                    ProductComboId = 1,
                    Quantity = 1,
                    Price = 109000
                }
                );


            modelBuilder.Entity<Invoice>().HasData(
                new Invoice()
                {
                    Id = 1,
                    UserId = 1,
                    TicketId = 1,
                    OrderId = 1,
                    Price = 80000 + 109000,
                    Discount = 0,
                    SumPrice = 80000 + 109000,
                    DateOfPurchase = DateTime.Now,
                    IsDeleted = false
                },
                new Invoice()
                {
                    Id = 2,
                    UserId = 1,
                    TicketId = 2,
                    OrderId = 2,
                    Price = 80000 + 129000,
                    Discount = 0,
                    SumPrice = 80000 + 129000,
                    DateOfPurchase = DateTime.Now,
                    IsDeleted = false
                },
                new Invoice()
                {
                    Id = 3,
                    UserId = 1,
                    TicketId = 3,
                    OrderId = 3,
                    Price = 80000 + 109000,
                    Discount = 10000,
                    SumPrice = 70000 + 109000,
                    DateOfPurchase = DateTime.Now,
                    IsDeleted = false
                });
        }
    }
}
