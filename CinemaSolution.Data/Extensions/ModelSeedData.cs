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
                    Name = "Customer",
                    Description = "Customer"
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
                    Name = "Cao bồi",
                },
                new Category()
                {
                    Id = 2,
                    Name = "Chiến tranh",
                },
                new Category()
                {
                    Id = 3,
                    Name = "Gia đình",
                },
                new Category()
                {
                    Id = 4,
                    Name = "Giả tưởng",
                },
                new Category()
                {
                    Id = 5,
                    Name = "Giật Gân",
                },
                new Category()
                {
                    Id = 6,
                    Name = "Hài",
                },
                new Category()
                {
                    Id = 7,
                    Name = "Hành động",
                },
                new Category()
                {
                    Id = 8,
                    Name = "Hình sự",
                },
                new Category()
                {
                    Id = 9,
                    Name = "Hoạt hình",
                },
                new Category()
                {
                    Id = 10,
                    Name = "Kinh dị",
                },
                new Category()
                {
                    Id = 11,
                    Name = "Lãng mạn",
                },
                new Category()
                {
                    Id = 12,
                    Name = "Lịch sử",
                },
                new Category()
                {
                    Id = 13,
                    Name = "Ly kì",
                },
                new Category()
                {
                    Id = 14,
                    Name = "Nhạc kịch",
                },
                new Category()
                {
                    Id = 15,
                    Name = "Phiêu lưu",
                },
                new Category()
                {
                    Id = 16,
                    Name = "Tài liệu",
                },
                new Category()
                {
                    Id = 17,
                    Name = "Tâm lý",
                },
                new Category()
                {
                    Id = 18,
                    Name = "Thần thoại",
                },
                new Category()
                {
                    Id = 19,
                    Name = "Thể thao",
                },
                new Category()
                {
                    Id = 20,
                    Name = "Tiểu sử",
                },
                new Category()
                {
                    Id = 21,
                    Name = "Tình cảm",
                },
                new Category()
                {
                    Id = 22,
                    Name = "Tội phạm",
                }
            );

            modelBuilder.Entity<Movie>().HasData(
                new Movie()
                {
                    Id = 1,
                    Title = "Deadpool & Wolverine",
                    Description = "Sau một số tác phẩm chưa đạt thành công như kì vọng gần đây, Marvel Studios ngày càng thận trọng khi ra mắt các dự án mới. Deadpool & Wolverine chính là bộ phim Marvel duy nhất ra mắt năm 2024. Bộ phim là tác phẩm mà công chúng kì vọng sẽ cứu rỗi vũ trụ điện ảnh Marvel khỏi cơn thoái trào. Chính vì vậy, chẳng có gì ngạc nhiên khi Deadpool & Wolverine được đầu tư, chăm chút hết sức kĩ lưỡng. \r\nSau teaser và trailer đầu tiên, cốt truyện Deadpool & Wolverine dần dần hé lộ. Đặc sản “trứng phục sinh” bùng nổ ở trailer, khiến khán giả đồn đoán liên tục, gợi nhớ đến loạt tác phẩm quen thuộc như Ant-Man, X-Men United, X-Men: First Class, Loki… \r\nPhản diện phần này là Cassandra Nova – em gái song sinh độc ác của giáo sư X. Ả sở hữu khả năng ngoại cảm cùng hàng tá kĩ năng dễ dàng đo ván Wolverine và Deadpool. Vai diễn nặng kí này Emma Corrin đảm nhận. Cô được biết đến khi trở thành vương phi Diana thời trẻ trong series truyền hình nổi tiếng The Crown. \r\nSau Tim Miller (Deadpool) và David Leitch (Deadpool 2), đạo diễn Shawn Levy của Real Steel và Free Guy là cái tên tiếp theo cầm trịch tác phẩm về gã phản anh hùng nói nhiều. Ryan Reynolds tiếp tục quay lại vai diễn mang tính biểu tượng trong sự nghiệp. Anh tham gia luôn khâu biên kịch cùng Rhett Reese, Paul Wernick, Zeb Wells và Shawn Levy. Hugh Jackman cũng tái xuất vai diễn dường như chẳng ai thay thế nổi – Wolverine.",
                    Duration = 127,
                    Rating = 9,
                    Language = "Phụ đề",
                    TrailerUrl = "https://www.youtube.com/embed/lW4-A3ZQnVQ",
                    IsDeleted = false,
                    Director = "Shawn Levy",
                    Actors = "Ryan Reynolds, Hugh Jackman, Patrick Stewart",
                    ReleaseDate = new DateTime(2024, 7, 27),
                    EndDate = new DateTime(2024, 12, 20)
                },
                new Movie()
                {
                    Id = 2,
                    Title = "Thám Tử Lừng Danh Conan: Ngôi Sao 5 Cánh 1 Triệu Đô",
                    Description = "Siêu trộm Kaito Kid và thám tử miền Tây Hattori Heiji cùng đối đầu trong cuộc tranh giành thanh kiếm thuộc về Hijikata Toushizou - phó chỉ huy của Shinsengumi! Thù mới hận cũ, Heiji sẽ xử trí Kid thế nào đây?\r\nNgoài ra, một bí mật kinh khủng về Kaito Kid sắp được tiếp lộ...",
                    Duration = 111,
                    Rating = 9.8,
                    Language = "Phụ đề Lồng tiếng",
                    TrailerUrl = "https://www.youtube.com/embed/x_gGMJOppAo",
                    IsDeleted = false,
                    Director = "Nagaoka Tomoka",
                    Actors = "Takayama Minami, Yamazaki Wakana",
                    ReleaseDate = new DateTime(2024, 8, 2),
                    EndDate = new DateTime(2024, 12, 20)
                },
                new Movie()
                {
                    Id = 3,
                    Title = "Vây Hãm Trên Không",
                    Description = "Bộ phim hành động ly kỳ dựa trên sự kiện có thật với sự tham gia của Ha Jung Woo, Yeo Jin Goo và Sung Dong Il được dựa trên một sự kiện có thật năm 1971, khi một thanh niên Hàn Quốc định cướp một chiếc máy bay chở khách khởi hành từ thành phố cảnh phía đông Sokcho bay tới Seoul. Mọi người trên chuyến bay này đều đang đặt cược mạng sống của mình!",
                    Duration = 100,
                    Rating = 9.5,
                    Language = "Phụ đề",
                    TrailerUrl = "https://www.youtube.com/embed/1Umr4h5dn5I",
                    IsDeleted = false,
                    Director = "Kim Sung Han",
                    Actors = "Ha Jung Woo, Yeo Jin Goo, Sung Dong Il",
                    ReleaseDate = new DateTime(2024, 7, 19),
                    EndDate = new DateTime(2024, 12, 20)
                }
            );

            // MovieCategory
            modelBuilder.Entity<MovieInCategory>().HasData(
               new MovieInCategory()
               {
                   MovieId = 1,
                   CategoryId = 7
               },
                new MovieInCategory()
                {
                    MovieId = 1,
                    CategoryId = 6
                },
                new MovieInCategory()
                {
                    MovieId = 1,
                    CategoryId = 4
                },
                new MovieInCategory()
                {
                    MovieId = 2,
                    CategoryId = 9
                },
                new MovieInCategory()
                {
                    MovieId = 3,
                    CategoryId = 7
                },
                new MovieInCategory()
                {
                    MovieId = 3,
                    CategoryId = 5
                },
                new MovieInCategory()
                {
                    MovieId = 3,
                    CategoryId = 22
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
                    ImageUrl = "https://firebasestorage.googleapis.com/v0/b/tune-cinema.appspot.com/o/movie_thumbnail%2FDeadpool%20%26%20Wolverine.jpg?alt=media&token=ae6340d3-3b0d-4b59-b1ef-d8c56aa72c54",
                    IsPoster = true,
                },
                new MovieImage()
                {
                    Id = 2,
                    MovieId = 1,
                    MovieImageTypeId = 2,
                    ImageUrl = "https://firebasestorage.googleapis.com/v0/b/tune-cinema.appspot.com/o/movie_thumbnail%2FDeadpool%20%26%20Wolverine%20-%20Backdrop.jpg?alt=media&token=68132efe-85cc-4760-845a-12164e26453b",
                    IsPoster = false,
                },
                new MovieImage()
                {
                    Id = 3,
                    MovieId = 2,
                    MovieImageTypeId = 1,
                    ImageUrl = "https://firebasestorage.googleapis.com/v0/b/tune-cinema.appspot.com/o/movie_thumbnail%2FConan.jpg?alt=media&token=c0ffb6db-f8b1-4930-9136-54bd38ccc209",
                    IsPoster = true,
                },
                new MovieImage()
                {
                    Id = 4,
                    MovieId = 2,
                    MovieImageTypeId = 2,
                    ImageUrl = "https://firebasestorage.googleapis.com/v0/b/tune-cinema.appspot.com/o/movie_thumbnail%2FConan-Backdrop.jpg?alt=media&token=6fb5b903-397d-4fa2-9c2a-90f52007359e",
                    IsPoster = false,
                },
                new MovieImage()
                {
                    Id = 5,
                    MovieId = 3,
                    MovieImageTypeId = 1,
                    ImageUrl = "https://firebasestorage.googleapis.com/v0/b/tune-cinema.appspot.com/o/movie_thumbnail%2FVay%20Ham%20Tren%20Khong.jpg?alt=media&token=fa1c6658-db84-4bbc-9410-7c00c9f98b68",
                    IsPoster = true,
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
                    Name = "CGV",
                    LogoUrl = "https://firebasestorage.googleapis.com/v0/b/tune-cinema.appspot.com/o/cinema_logo%2FCGV.png?alt=media&token=b1da43c8-0877-480a-96be-a557b3347a20",
                },
                new Cinema()
                {
                    Id = 2,
                    Name = "Lotte",
                    LogoUrl = "https://firebasestorage.googleapis.com/v0/b/tune-cinema.appspot.com/o/cinema_logo%2FLotte.png?alt=media&token=02d3da6d-061c-47d2-9838-2e6061b101d6",
                }
            );

            modelBuilder.Entity<Auditorium>().HasData(
                new Auditorium()
                {
                    Id = 1,
                    Name = "CGV Long Biên",
                    CinemaId = 1,
                    Address = "Hà Nội",
                    ProvinceId = 1,
                    Longitude = 21,
                    Latitude = 105,
                    SeatMapVector = "111111111111111111111111222222222222222222222222222222222222111111111111111111111111111111111111111111111111111111111111111111111111111111111111"
                },
                new Auditorium()
                {
                    Id = 2,
                    Name = "CGV Vincom Bà Triệu",
                    CinemaId = 1,
                    Address = "Hà Nội",
                    ProvinceId = 1,
                    Longitude = 21,
                    Latitude = 105,
                    SeatMapVector = "111111111111111111111111222222222222222222222222222222222222111111111111111111111111111111111111111111111111111111111111111111111111111111111111"
                },
                new Auditorium()
                {
                    Id = 3,
                    Name = "CGV Vincom Đà Nẵng",
                    Address = "Đà Nẵng",
                    ProvinceId = 2,
                    Longitude = 16,
                    Latitude = 108,
                    CinemaId = 1,
                    SeatMapVector = "111111111111111111111111222222222222222222222222222222222222111111111111111111111111111111111111111111111111111111111111111111111111111111111111"
                },
                new Auditorium()
                {
                    Id = 4,
                    Name = "CGV Vĩnh Trung Plaza",
                    Address = "Đà Nẵng",
                    ProvinceId = 2,
                    Longitude = 16,
                    Latitude = 108,
                    CinemaId = 1,
                    SeatMapVector = "111111111111111111111111222222222222222222222222222222222222111111111111111111111111111111111111111111111111111111111111111111111111111111111111"
                },
                new Auditorium()
                {
                    Id = 5,
                    Name = "Lotte Đà Nẵng",
                    Address = "Đà Nẵng",
                    ProvinceId = 2,
                    Longitude = 16,
                    Latitude = 108,
                    CinemaId = 2,
                    SeatMapVector = "111111111111111111111111222222222222222222222222222222222222111111111111111111111111111111111111111111111111111111111111111111111111111111111111"
                },
                new Auditorium()
                {
                    Id = 6,
                    Name = "Lotte Vĩnh Trung Plaza",
                    Address = "Đà Nẵng",
                    ProvinceId = 2,
                    Longitude = 16,
                    Latitude = 108,
                    CinemaId = 2,
                    SeatMapVector = "111111111111111111111111222222222222222222222222222222222222111111111111111111111111111111111111111111111111111111111111111111111111111111111111"
                }
            );

            modelBuilder.Entity<Screening>().HasData(new Screening()
            {
                Id = 1,
                MovieId = 1,
                AuditoriumId = 1,
                StartDate = new DateTime(2024, 8, 15),
                StartTime = new TimeSpan(10, 0, 0),
                IsDeleted = false
            },
                new Screening()
                {
                    Id = 2,
                    MovieId = 1,
                    AuditoriumId = 1,
                    StartDate = new DateTime(2024, 8, 16),
                    StartTime = new TimeSpan(20, 0, 0),
                    IsDeleted = false
                },
                new Screening()
                {
                    Id = 3,
                    MovieId = 1,
                    AuditoriumId = 2,
                    StartDate = new DateTime(2024, 8, 18),
                    StartTime = new TimeSpan(20, 0, 0),
                    IsDeleted = false
                },
                new Screening()
                {
                    Id = 4,
                    MovieId = 2,
                    AuditoriumId = 3,
                    StartDate = new DateTime(2024, 8, 18),
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
