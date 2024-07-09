using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaSolution.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieImageTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieImageTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Language = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Director = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Actors = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1028)", maxLength: 1028, nullable: false),
                    TrailerUrl = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 7, 9, 20, 51, 43, 261, DateTimeKind.Local).AddTicks(6131)),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPrice = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCombos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCombos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeatStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    StatusDescription = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeatTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 7, 9, 20, 51, 43, 263, DateTimeKind.Local).AddTicks(5942)),
                    FileSize = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    IsPoster = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    MovieImageTypeId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieImages_MovieImageTypes_MovieImageTypeId",
                        column: x => x.MovieImageTypeId,
                        principalTable: "MovieImageTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieImages_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieInCategories",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieInCategories", x => new { x.MovieId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_MovieInCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieInCategories_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductComboInOrders",
                columns: table => new
                {
                    ProductComboId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductComboInOrders", x => new { x.OrderId, x.ProductComboId });
                    table.ForeignKey(
                        name: "FK_ProductComboInOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductComboInOrders_ProductCombos_ProductComboId",
                        column: x => x.ProductComboId,
                        principalTable: "ProductCombos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductInProductCombos",
                columns: table => new
                {
                    ProductComboId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInProductCombos", x => new { x.ProductId, x.ProductComboId });
                    table.ForeignKey(
                        name: "FK_ProductInProductCombos_ProductCombos_ProductComboId",
                        column: x => x.ProductComboId,
                        principalTable: "ProductCombos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInProductCombos_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cinemas_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DefaultPriceTables",
                columns: table => new
                {
                    SeatTypeId = table.Column<int>(type: "int", nullable: false),
                    PersonTypeId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false, defaultValue: 50000)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultPriceTables", x => new { x.SeatTypeId, x.PersonTypeId });
                    table.ForeignKey(
                        name: "FK_DefaultPriceTables_PersonTypes_PersonTypeId",
                        column: x => x.PersonTypeId,
                        principalTable: "PersonTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DefaultPriceTables_SeatTypes_SeatTypeId",
                        column: x => x.SeatTypeId,
                        principalTable: "SeatTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 7, 9, 20, 51, 43, 264, DateTimeKind.Local).AddTicks(3318)),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => new { x.MovieId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Ratings_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserInRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Auditoriums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinemaId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    NumberOfRowSeats = table.Column<int>(type: "int", nullable: false, defaultValue: 12),
                    NumberOfColumnSeats = table.Column<int>(type: "int", nullable: false, defaultValue: 12)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditoriums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auditoriums_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Screenings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    AuditoriumId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screenings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Screenings_Auditoriums_AuditoriumId",
                        column: x => x.AuditoriumId,
                        principalTable: "Auditoriums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Screenings_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScreeningId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Screenings_ScreeningId",
                        column: x => x.ScreeningId,
                        principalTable: "Screenings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100000, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SumPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateOfPurchase = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Row = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    ScreeningId = table.Column<int>(type: "int", nullable: false),
                    SeatTypeId = table.Column<int>(type: "int", nullable: false),
                    SeatStatusId = table.Column<int>(type: "int", nullable: false),
                    PersonTypeId = table.Column<int>(type: "int", nullable: true),
                    TicketId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seat_PersonTypes_PersonTypeId",
                        column: x => x.PersonTypeId,
                        principalTable: "PersonTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Seat_Screenings_ScreeningId",
                        column: x => x.ScreeningId,
                        principalTable: "Screenings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seat_SeatStatuses_SeatStatusId",
                        column: x => x.SeatStatusId,
                        principalTable: "SeatStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seat_SeatTypes_SeatTypeId",
                        column: x => x.SeatTypeId,
                        principalTable: "SeatTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seat_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Adventure" },
                    { 3, "Animation" },
                    { 4, "Comedy" },
                    { 5, "Crime" },
                    { 6, "Documentary" },
                    { 7, "Drama" }
                });

            migrationBuilder.InsertData(
                table: "MovieImageTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Poster", "Poster" },
                    { 2, "Backdrop", "Backdrop" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Actors", "Description", "Director", "Duration", "EndDate", "Language", "Rating", "ReleaseDate", "Title", "TrailerUrl" },
                values: new object[,]
                {
                    { 1, "Charlize Theron, KiKi Layne, Marwan Kenzari, Luca Marinelli, Harry Melling", "Four undying warriors who've secretly protected humanity for centuries become targeted for their mysterious powers just as they discover a new immortal.", "Gina Prince-Bythewood", 125, new DateTime(2024, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "English", 9.0, new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Old Guard", "https://www.youtube.com/embed/aK-X2d0lJ_s" },
                    { 2, "Joey King, Joel Courtney, Jacob Elordi", "In the sequel to 2018's THE KISSING BOOTH, high school senior Elle juggles a long-distance relationship with her dreamy boyfriend Noah, college applications, and a new friendship with a handsome classmate that could change everything.", "Vince Marcello", 130, new DateTime(2024, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "English", 7.0, new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Kissing Booth 2", "https://www.youtube.com/embed/ZR2JlDnT2l8" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "IsDeleted", "TotalPrice" },
                values: new object[,]
                {
                    { 1, false, 109000 },
                    { 2, false, 129000 },
                    { 3, false, 109000 }
                });

            migrationBuilder.InsertData(
                table: "PersonTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Người lớn từ 12 đến 60 tuổi", "Người lớn" },
                    { 2, "Trẻ em từ 0 đến 12 tuổi và người lớn từ 60 tuổi trở lên", "Trẻ em và người lớn tuổi" },
                    { 3, "Sinh viên có thẻ", "Sinh viên" }
                });

            migrationBuilder.InsertData(
                table: "ProductCombos",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "1 Ly nước ngọt size L + 01 Hộp bắp + 1 Snack", "https://www.galaxycine.vn/media/2023/3/31/menuboard-combo1-2-2022-coonline-combo1_1680280126585.jpg", "iCombo 1 Big Extra STD", 109000 },
                    { 2, "Combo 2", "https://www.galaxycine.vn/media/2023/3/31/menuboard-combo1-2-2022-coonline-combo2_1680280172153.jpg", "Combo 2", 129000 },
                    { 3, "01 OP Head + 01 ly nước ngọt size L + 01 Hộp bắp + FREE Up Vị bất kỳ", "https://www.galaxycine.vn/media/2023/6/8/combooptimus-co-onl1_1686238609745.jpg", "iCombo Optimus Prime 1", 369000 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, "Bắp rang", false, "Bắp rang" },
                    { 2, "Nước ngọt size L", false, "Nước ngọt size L" },
                    { 3, "Snack", false, "Snack" },
                    { 4, "OP Head", false, "OP Head" }
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Hà Nội" },
                    { 2, "Đà Nẵng" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Administrator", "Administrator" },
                    { 2, "User", "User" }
                });

            migrationBuilder.InsertData(
                table: "SeatStatuses",
                columns: new[] { "Id", "IsAvailable", "StatusDescription", "StatusName" },
                values: new object[,]
                {
                    { 1, false, "Có thể đặt", "Có thể đặt" },
                    { 2, false, "Không thể đặt", "Không thể đặt" }
                });

            migrationBuilder.InsertData(
                table: "SeatTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Normal", "Normal" },
                    { 2, "VIP", "VIP" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FirstName", "IsDeleted", "LastName", "PasswordHash", "PasswordSalt", "PhoneNumber", "Username" },
                values: new object[,]
                {
                    { 1, "Address", "admin@gmail.com", "Admin", false, "Admin", "wm3S0Z61/isgEwGHZoiGDDXpIVLEsBMKvouapX12OnA=", "7K79ePE4NLb2rPOnWokBkg==", "0482648163", "admin" },
                    { 2, "Address", "user@email.com", "User", false, "User", "iMHisUy3QbsgQ2fKvh1DvjOQJax1D9K0zVb1uHKJSwg=", "0WAOE+EmrN6VvhOpc1iL7g==", "0481726361", "user" },
                    { 3, "Address", "user2@email.com", "User2", false, "User2", "iMHisUy3QbsgQ2fKvh1DvjOQJax1D9K0zVb1uHKJSwg=", "0WAOE+EmrN6VvhOpc1iL7g==", "0382736162", "user2" }
                });

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Address", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { 1, "Hà Nội", "CGV Hà Nội", 1 },
                    { 2, "Đà Nẵng", "CGV Đà Nẵng", 2 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedDate", "MovieId", "UserId" },
                values: new object[,]
                {
                    { 1, "This is a comment", new DateTime(2024, 7, 9, 20, 51, 43, 274, DateTimeKind.Local).AddTicks(1260), 1, 2 },
                    { 2, "This is a comment", new DateTime(2024, 7, 9, 20, 51, 43, 274, DateTimeKind.Local).AddTicks(1262), 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "DefaultPriceTables",
                columns: new[] { "PersonTypeId", "SeatTypeId", "Price" },
                values: new object[,]
                {
                    { 1, 1, 80000 },
                    { 2, 1, 60000 },
                    { 3, 1, 50000 },
                    { 1, 2, 100000 },
                    { 2, 2, 80000 },
                    { 3, 2, 70000 }
                });

            migrationBuilder.InsertData(
                table: "MovieImages",
                columns: new[] { "Id", "Caption", "ImageUrl", "IsPoster", "MovieId", "MovieImageTypeId" },
                values: new object[] { 1, null, "https://image.tmdb.org/t/p/w500/7D430eqZj8y3oVkLFfsWXGRcpEG.jpg", true, 1, 1 });

            migrationBuilder.InsertData(
                table: "MovieImages",
                columns: new[] { "Id", "Caption", "ImageUrl", "MovieId", "MovieImageTypeId" },
                values: new object[] { 2, null, "https://image.tmdb.org/t/p/w500/5aXp2s4l6g5PcMMesIj63mx8hmJ.jpg", 1, 2 });

            migrationBuilder.InsertData(
                table: "MovieImages",
                columns: new[] { "Id", "Caption", "ImageUrl", "IsPoster", "MovieId", "MovieImageTypeId" },
                values: new object[] { 3, null, "https://image.tmdb.org/t/p/w500/7D430eqZj8y3oVkLFfsWXGRcpEG.jpg", true, 2, 1 });

            migrationBuilder.InsertData(
                table: "MovieImages",
                columns: new[] { "Id", "Caption", "ImageUrl", "MovieId", "MovieImageTypeId" },
                values: new object[] { 4, null, "https://image.tmdb.org/t/p/w500/5aXp2s4l6g5PcMMesIj63mx8hmJ.jpg", 2, 2 });

            migrationBuilder.InsertData(
                table: "MovieInCategories",
                columns: new[] { "CategoryId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 2 },
                    { 5, 2 },
                    { 6, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductComboInOrders",
                columns: new[] { "OrderId", "ProductComboId", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 109000, 1 },
                    { 2, 2, 129000, 1 },
                    { 3, 1, 109000, 1 }
                });

            migrationBuilder.InsertData(
                table: "ProductInProductCombos",
                columns: new[] { "ProductComboId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 1 },
                    { 1, 2, 1 },
                    { 2, 2, 1 },
                    { 3, 2, 1 },
                    { 1, 3, 1 },
                    { 2, 3, 1 },
                    { 3, 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "MovieId", "UserId", "Value" },
                values: new object[,]
                {
                    { 1, 2, 10 },
                    { 1, 3, 8 },
                    { 2, 2, 6 },
                    { 2, 3, 8 }
                });

            migrationBuilder.InsertData(
                table: "UserInRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Auditoriums",
                columns: new[] { "Id", "CinemaId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "A1" },
                    { 2, 1, "A2" },
                    { 3, 2, "A3" },
                    { 4, 2, "A4" }
                });

            migrationBuilder.InsertData(
                table: "Screenings",
                columns: new[] { "Id", "AuditoriumId", "MovieId", "StartDate", "StartTime" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 10, 0, 0, 0) },
                    { 2, 1, 1, new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 20, 0, 0, 0) },
                    { 3, 2, 1, new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 20, 0, 0, 0) },
                    { 4, 3, 2, new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 20, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Seat",
                columns: new[] { "Id", "Number", "PersonTypeId", "Row", "ScreeningId", "SeatStatusId", "SeatTypeId", "TicketId" },
                values: new object[,]
                {
                    { 4, 4, null, 1, 1, 1, 2, null },
                    { 5, 5, null, 1, 1, 1, 2, null },
                    { 6, 6, null, 1, 1, 1, 2, null },
                    { 7, 7, null, 1, 1, 1, 2, null },
                    { 8, 8, null, 1, 1, 1, 2, null },
                    { 9, 9, null, 1, 1, 1, 2, null },
                    { 10, 10, null, 1, 1, 1, 2, null },
                    { 11, 11, null, 1, 1, 1, 2, null },
                    { 12, 12, null, 1, 1, 1, 2, null },
                    { 13, 1, null, 2, 1, 1, 2, null },
                    { 14, 2, null, 2, 1, 1, 2, null },
                    { 15, 3, null, 2, 1, 1, 2, null },
                    { 16, 4, null, 2, 1, 1, 2, null },
                    { 17, 5, null, 2, 1, 1, 2, null },
                    { 18, 6, null, 2, 1, 1, 2, null },
                    { 19, 7, null, 2, 1, 1, 2, null },
                    { 20, 8, null, 2, 1, 1, 2, null },
                    { 21, 9, null, 2, 1, 1, 2, null },
                    { 22, 10, null, 2, 1, 1, 2, null },
                    { 23, 11, null, 2, 1, 1, 2, null },
                    { 24, 12, null, 2, 1, 1, 2, null },
                    { 25, 1, null, 3, 1, 1, 2, null },
                    { 26, 2, null, 3, 1, 1, 2, null },
                    { 27, 3, null, 3, 1, 1, 2, null },
                    { 28, 4, null, 3, 1, 1, 2, null },
                    { 29, 5, null, 3, 1, 1, 2, null },
                    { 30, 6, null, 3, 1, 1, 2, null },
                    { 31, 7, null, 3, 1, 1, 2, null },
                    { 32, 8, null, 3, 1, 1, 2, null },
                    { 33, 9, null, 3, 1, 1, 2, null },
                    { 34, 10, null, 3, 1, 1, 2, null },
                    { 35, 11, null, 3, 1, 1, 2, null },
                    { 36, 12, null, 3, 1, 1, 2, null },
                    { 37, 1, null, 4, 1, 1, 2, null },
                    { 38, 2, null, 4, 1, 1, 2, null },
                    { 39, 3, null, 4, 1, 1, 2, null },
                    { 40, 4, null, 4, 1, 1, 2, null },
                    { 41, 5, null, 4, 1, 1, 2, null },
                    { 42, 6, null, 4, 1, 1, 2, null },
                    { 43, 7, null, 4, 1, 1, 2, null },
                    { 44, 8, null, 4, 1, 1, 2, null },
                    { 45, 9, null, 4, 1, 1, 2, null },
                    { 46, 10, null, 4, 1, 1, 2, null },
                    { 47, 11, null, 4, 1, 1, 2, null },
                    { 48, 12, null, 4, 1, 1, 2, null },
                    { 49, 1, null, 5, 1, 1, 2, null },
                    { 50, 2, null, 5, 1, 1, 2, null },
                    { 51, 3, null, 5, 1, 1, 2, null },
                    { 52, 4, null, 5, 1, 1, 2, null },
                    { 53, 5, null, 5, 1, 1, 2, null },
                    { 54, 6, null, 5, 1, 1, 2, null },
                    { 55, 7, null, 5, 1, 1, 2, null },
                    { 56, 8, null, 5, 1, 1, 2, null },
                    { 57, 9, null, 5, 1, 1, 2, null },
                    { 58, 10, null, 5, 1, 1, 2, null },
                    { 59, 11, null, 5, 1, 1, 2, null },
                    { 60, 12, null, 5, 1, 1, 2, null },
                    { 61, 1, null, 6, 1, 1, 2, null },
                    { 62, 2, null, 6, 1, 1, 2, null },
                    { 63, 3, null, 6, 1, 1, 2, null },
                    { 64, 4, null, 6, 1, 1, 2, null },
                    { 65, 5, null, 6, 1, 1, 2, null },
                    { 66, 6, null, 6, 1, 1, 2, null },
                    { 67, 7, null, 6, 1, 1, 2, null },
                    { 68, 8, null, 6, 1, 1, 2, null },
                    { 69, 9, null, 6, 1, 1, 2, null },
                    { 70, 10, null, 6, 1, 1, 2, null },
                    { 71, 11, null, 6, 1, 1, 2, null },
                    { 72, 12, null, 6, 1, 1, 2, null },
                    { 73, 1, null, 7, 1, 1, 2, null },
                    { 74, 2, null, 7, 1, 1, 2, null },
                    { 75, 3, null, 7, 1, 1, 2, null },
                    { 76, 4, null, 7, 1, 1, 2, null },
                    { 77, 5, null, 7, 1, 1, 2, null },
                    { 78, 6, null, 7, 1, 1, 2, null },
                    { 79, 7, null, 7, 1, 1, 2, null },
                    { 80, 8, null, 7, 1, 1, 2, null },
                    { 81, 9, null, 7, 1, 1, 2, null },
                    { 82, 10, null, 7, 1, 1, 2, null },
                    { 83, 11, null, 7, 1, 1, 2, null },
                    { 84, 12, null, 7, 1, 1, 2, null },
                    { 85, 1, null, 8, 1, 1, 2, null },
                    { 86, 2, null, 8, 1, 1, 2, null },
                    { 87, 3, null, 8, 1, 1, 2, null },
                    { 88, 4, null, 8, 1, 1, 2, null },
                    { 89, 5, null, 8, 1, 1, 2, null },
                    { 90, 6, null, 8, 1, 1, 2, null },
                    { 91, 7, null, 8, 1, 1, 2, null },
                    { 92, 8, null, 8, 1, 1, 2, null },
                    { 93, 9, null, 8, 1, 1, 2, null },
                    { 94, 10, null, 8, 1, 1, 2, null },
                    { 95, 11, null, 8, 1, 1, 2, null },
                    { 96, 12, null, 8, 1, 1, 2, null },
                    { 97, 1, null, 9, 1, 1, 2, null },
                    { 98, 2, null, 9, 1, 1, 2, null },
                    { 99, 3, null, 9, 1, 1, 2, null },
                    { 100, 4, null, 9, 1, 1, 2, null },
                    { 101, 5, null, 9, 1, 1, 2, null },
                    { 102, 6, null, 9, 1, 1, 2, null },
                    { 103, 7, null, 9, 1, 1, 2, null },
                    { 104, 8, null, 9, 1, 1, 2, null },
                    { 105, 9, null, 9, 1, 1, 2, null },
                    { 106, 10, null, 9, 1, 1, 2, null },
                    { 107, 11, null, 9, 1, 1, 2, null },
                    { 108, 12, null, 9, 1, 1, 2, null },
                    { 109, 1, null, 10, 1, 1, 2, null },
                    { 110, 2, null, 10, 1, 1, 2, null },
                    { 111, 3, null, 10, 1, 1, 2, null },
                    { 112, 4, null, 10, 1, 1, 2, null },
                    { 113, 5, null, 10, 1, 1, 2, null },
                    { 114, 6, null, 10, 1, 1, 2, null },
                    { 115, 7, null, 10, 1, 1, 2, null },
                    { 116, 8, null, 10, 1, 1, 2, null },
                    { 117, 9, null, 10, 1, 1, 2, null },
                    { 118, 10, null, 10, 1, 1, 2, null },
                    { 119, 11, null, 10, 1, 1, 2, null },
                    { 120, 12, null, 10, 1, 1, 2, null },
                    { 121, 1, null, 11, 1, 1, 2, null },
                    { 122, 2, null, 11, 1, 1, 2, null },
                    { 123, 3, null, 11, 1, 1, 2, null },
                    { 124, 4, null, 11, 1, 1, 2, null },
                    { 125, 5, null, 11, 1, 1, 2, null },
                    { 126, 6, null, 11, 1, 1, 2, null },
                    { 127, 7, null, 11, 1, 1, 2, null },
                    { 128, 8, null, 11, 1, 1, 2, null },
                    { 129, 9, null, 11, 1, 1, 2, null },
                    { 130, 10, null, 11, 1, 1, 2, null },
                    { 131, 11, null, 11, 1, 1, 2, null },
                    { 132, 12, null, 11, 1, 1, 2, null },
                    { 133, 1, null, 12, 1, 1, 2, null },
                    { 134, 2, null, 12, 1, 1, 2, null },
                    { 135, 3, null, 12, 1, 1, 2, null },
                    { 136, 4, null, 12, 1, 1, 2, null },
                    { 137, 5, null, 12, 1, 1, 2, null },
                    { 138, 6, null, 12, 1, 1, 2, null },
                    { 139, 7, null, 12, 1, 1, 2, null },
                    { 140, 8, null, 12, 1, 1, 2, null },
                    { 141, 9, null, 12, 1, 1, 2, null },
                    { 142, 10, null, 12, 1, 1, 2, null },
                    { 143, 11, null, 12, 1, 1, 2, null },
                    { 144, 12, null, 12, 1, 1, 2, null },
                    { 145, 1, null, 1, 2, 1, 2, null },
                    { 146, 2, null, 1, 2, 1, 2, null },
                    { 147, 3, null, 1, 2, 1, 2, null },
                    { 148, 4, null, 1, 2, 1, 2, null },
                    { 149, 5, null, 1, 2, 1, 2, null },
                    { 150, 6, null, 1, 2, 1, 2, null },
                    { 151, 7, null, 1, 2, 1, 2, null },
                    { 152, 8, null, 1, 2, 1, 2, null },
                    { 153, 9, null, 1, 2, 1, 2, null },
                    { 154, 10, null, 1, 2, 1, 2, null },
                    { 155, 11, null, 1, 2, 1, 2, null },
                    { 156, 12, null, 1, 2, 1, 2, null },
                    { 157, 1, null, 2, 2, 1, 2, null },
                    { 158, 2, null, 2, 2, 1, 2, null },
                    { 159, 3, null, 2, 2, 1, 2, null },
                    { 160, 4, null, 2, 2, 1, 2, null },
                    { 161, 5, null, 2, 2, 1, 2, null },
                    { 162, 6, null, 2, 2, 1, 2, null },
                    { 163, 7, null, 2, 2, 1, 2, null },
                    { 164, 8, null, 2, 2, 1, 2, null },
                    { 165, 9, null, 2, 2, 1, 2, null },
                    { 166, 10, null, 2, 2, 1, 2, null },
                    { 167, 11, null, 2, 2, 1, 2, null },
                    { 168, 12, null, 2, 2, 1, 2, null },
                    { 169, 1, null, 3, 2, 1, 2, null },
                    { 170, 2, null, 3, 2, 1, 2, null },
                    { 171, 3, null, 3, 2, 1, 2, null },
                    { 172, 4, null, 3, 2, 1, 2, null },
                    { 173, 5, null, 3, 2, 1, 2, null },
                    { 174, 6, null, 3, 2, 1, 2, null },
                    { 175, 7, null, 3, 2, 1, 2, null },
                    { 176, 8, null, 3, 2, 1, 2, null },
                    { 177, 9, null, 3, 2, 1, 2, null },
                    { 178, 10, null, 3, 2, 1, 2, null },
                    { 179, 11, null, 3, 2, 1, 2, null },
                    { 180, 12, null, 3, 2, 1, 2, null },
                    { 181, 1, null, 4, 2, 1, 2, null },
                    { 182, 2, null, 4, 2, 1, 2, null },
                    { 183, 3, null, 4, 2, 1, 2, null },
                    { 184, 4, null, 4, 2, 1, 2, null },
                    { 185, 5, null, 4, 2, 1, 2, null },
                    { 186, 6, null, 4, 2, 1, 2, null },
                    { 187, 7, null, 4, 2, 1, 2, null },
                    { 188, 8, null, 4, 2, 1, 2, null },
                    { 189, 9, null, 4, 2, 1, 2, null },
                    { 190, 10, null, 4, 2, 1, 2, null },
                    { 191, 11, null, 4, 2, 1, 2, null },
                    { 192, 12, null, 4, 2, 1, 2, null },
                    { 193, 1, null, 5, 2, 1, 2, null },
                    { 194, 2, null, 5, 2, 1, 2, null },
                    { 195, 3, null, 5, 2, 1, 2, null },
                    { 196, 4, null, 5, 2, 1, 2, null },
                    { 197, 5, null, 5, 2, 1, 2, null },
                    { 198, 6, null, 5, 2, 1, 2, null },
                    { 199, 7, null, 5, 2, 1, 2, null },
                    { 200, 8, null, 5, 2, 1, 2, null },
                    { 201, 9, null, 5, 2, 1, 2, null },
                    { 202, 10, null, 5, 2, 1, 2, null },
                    { 203, 11, null, 5, 2, 1, 2, null },
                    { 204, 12, null, 5, 2, 1, 2, null },
                    { 205, 1, null, 6, 2, 1, 2, null },
                    { 206, 2, null, 6, 2, 1, 2, null },
                    { 207, 3, null, 6, 2, 1, 2, null },
                    { 208, 4, null, 6, 2, 1, 2, null },
                    { 209, 5, null, 6, 2, 1, 2, null },
                    { 210, 6, null, 6, 2, 1, 2, null },
                    { 211, 7, null, 6, 2, 1, 2, null },
                    { 212, 8, null, 6, 2, 1, 2, null },
                    { 213, 9, null, 6, 2, 1, 2, null },
                    { 214, 10, null, 6, 2, 1, 2, null },
                    { 215, 11, null, 6, 2, 1, 2, null },
                    { 216, 12, null, 6, 2, 1, 2, null },
                    { 217, 1, null, 7, 2, 1, 2, null },
                    { 218, 2, null, 7, 2, 1, 2, null },
                    { 219, 3, null, 7, 2, 1, 2, null },
                    { 220, 4, null, 7, 2, 1, 2, null },
                    { 221, 5, null, 7, 2, 1, 2, null },
                    { 222, 6, null, 7, 2, 1, 2, null },
                    { 223, 7, null, 7, 2, 1, 2, null },
                    { 224, 8, null, 7, 2, 1, 2, null },
                    { 225, 9, null, 7, 2, 1, 2, null },
                    { 226, 10, null, 7, 2, 1, 2, null },
                    { 227, 11, null, 7, 2, 1, 2, null },
                    { 228, 12, null, 7, 2, 1, 2, null },
                    { 229, 1, null, 8, 2, 1, 2, null },
                    { 230, 2, null, 8, 2, 1, 2, null },
                    { 231, 3, null, 8, 2, 1, 2, null },
                    { 232, 4, null, 8, 2, 1, 2, null },
                    { 233, 5, null, 8, 2, 1, 2, null },
                    { 234, 6, null, 8, 2, 1, 2, null },
                    { 235, 7, null, 8, 2, 1, 2, null },
                    { 236, 8, null, 8, 2, 1, 2, null },
                    { 237, 9, null, 8, 2, 1, 2, null },
                    { 238, 10, null, 8, 2, 1, 2, null },
                    { 239, 11, null, 8, 2, 1, 2, null },
                    { 240, 12, null, 8, 2, 1, 2, null },
                    { 241, 1, null, 9, 2, 1, 2, null },
                    { 242, 2, null, 9, 2, 1, 2, null },
                    { 243, 3, null, 9, 2, 1, 2, null },
                    { 244, 4, null, 9, 2, 1, 2, null },
                    { 245, 5, null, 9, 2, 1, 2, null },
                    { 246, 6, null, 9, 2, 1, 2, null },
                    { 247, 7, null, 9, 2, 1, 2, null },
                    { 248, 8, null, 9, 2, 1, 2, null },
                    { 249, 9, null, 9, 2, 1, 2, null },
                    { 250, 10, null, 9, 2, 1, 2, null },
                    { 251, 11, null, 9, 2, 1, 2, null },
                    { 252, 12, null, 9, 2, 1, 2, null },
                    { 253, 1, null, 10, 2, 1, 2, null },
                    { 254, 2, null, 10, 2, 1, 2, null },
                    { 255, 3, null, 10, 2, 1, 2, null },
                    { 256, 4, null, 10, 2, 1, 2, null },
                    { 257, 5, null, 10, 2, 1, 2, null },
                    { 258, 6, null, 10, 2, 1, 2, null },
                    { 259, 7, null, 10, 2, 1, 2, null },
                    { 260, 8, null, 10, 2, 1, 2, null },
                    { 261, 9, null, 10, 2, 1, 2, null },
                    { 262, 10, null, 10, 2, 1, 2, null },
                    { 263, 11, null, 10, 2, 1, 2, null },
                    { 264, 12, null, 10, 2, 1, 2, null },
                    { 265, 1, null, 11, 2, 1, 2, null },
                    { 266, 2, null, 11, 2, 1, 2, null },
                    { 267, 3, null, 11, 2, 1, 2, null },
                    { 268, 4, null, 11, 2, 1, 2, null },
                    { 269, 5, null, 11, 2, 1, 2, null },
                    { 270, 6, null, 11, 2, 1, 2, null },
                    { 271, 7, null, 11, 2, 1, 2, null },
                    { 272, 8, null, 11, 2, 1, 2, null },
                    { 273, 9, null, 11, 2, 1, 2, null },
                    { 274, 10, null, 11, 2, 1, 2, null },
                    { 275, 11, null, 11, 2, 1, 2, null },
                    { 276, 12, null, 11, 2, 1, 2, null },
                    { 277, 1, null, 12, 2, 1, 2, null },
                    { 278, 2, null, 12, 2, 1, 2, null },
                    { 279, 3, null, 12, 2, 1, 2, null },
                    { 280, 4, null, 12, 2, 1, 2, null },
                    { 281, 5, null, 12, 2, 1, 2, null },
                    { 282, 6, null, 12, 2, 1, 2, null },
                    { 283, 7, null, 12, 2, 1, 2, null },
                    { 284, 8, null, 12, 2, 1, 2, null },
                    { 285, 9, null, 12, 2, 1, 2, null },
                    { 286, 10, null, 12, 2, 1, 2, null },
                    { 287, 11, null, 12, 2, 1, 2, null },
                    { 288, 12, null, 12, 2, 1, 2, null },
                    { 289, 1, null, 1, 3, 1, 2, null },
                    { 290, 2, null, 1, 3, 1, 2, null },
                    { 291, 3, null, 1, 3, 1, 2, null },
                    { 292, 4, null, 1, 3, 1, 2, null },
                    { 293, 5, null, 1, 3, 1, 2, null },
                    { 294, 6, null, 1, 3, 1, 2, null },
                    { 295, 7, null, 1, 3, 1, 2, null },
                    { 296, 8, null, 1, 3, 1, 2, null },
                    { 297, 9, null, 1, 3, 1, 2, null },
                    { 298, 10, null, 1, 3, 1, 2, null },
                    { 299, 11, null, 1, 3, 1, 2, null },
                    { 300, 12, null, 1, 3, 1, 2, null },
                    { 301, 1, null, 2, 3, 1, 2, null },
                    { 302, 2, null, 2, 3, 1, 2, null },
                    { 303, 3, null, 2, 3, 1, 2, null },
                    { 304, 4, null, 2, 3, 1, 2, null },
                    { 305, 5, null, 2, 3, 1, 2, null },
                    { 306, 6, null, 2, 3, 1, 2, null },
                    { 307, 7, null, 2, 3, 1, 2, null },
                    { 308, 8, null, 2, 3, 1, 2, null },
                    { 309, 9, null, 2, 3, 1, 2, null },
                    { 310, 10, null, 2, 3, 1, 2, null },
                    { 311, 11, null, 2, 3, 1, 2, null },
                    { 312, 12, null, 2, 3, 1, 2, null },
                    { 313, 1, null, 3, 3, 1, 2, null },
                    { 314, 2, null, 3, 3, 1, 2, null },
                    { 315, 3, null, 3, 3, 1, 2, null },
                    { 316, 4, null, 3, 3, 1, 2, null },
                    { 317, 5, null, 3, 3, 1, 2, null },
                    { 318, 6, null, 3, 3, 1, 2, null },
                    { 319, 7, null, 3, 3, 1, 2, null },
                    { 320, 8, null, 3, 3, 1, 2, null },
                    { 321, 9, null, 3, 3, 1, 2, null },
                    { 322, 10, null, 3, 3, 1, 2, null },
                    { 323, 11, null, 3, 3, 1, 2, null },
                    { 324, 12, null, 3, 3, 1, 2, null },
                    { 325, 1, null, 4, 3, 1, 2, null },
                    { 326, 2, null, 4, 3, 1, 2, null },
                    { 327, 3, null, 4, 3, 1, 2, null },
                    { 328, 4, null, 4, 3, 1, 2, null },
                    { 329, 5, null, 4, 3, 1, 2, null },
                    { 330, 6, null, 4, 3, 1, 2, null },
                    { 331, 7, null, 4, 3, 1, 2, null },
                    { 332, 8, null, 4, 3, 1, 2, null },
                    { 333, 9, null, 4, 3, 1, 2, null },
                    { 334, 10, null, 4, 3, 1, 2, null },
                    { 335, 11, null, 4, 3, 1, 2, null },
                    { 336, 12, null, 4, 3, 1, 2, null },
                    { 337, 1, null, 5, 3, 1, 2, null },
                    { 338, 2, null, 5, 3, 1, 2, null },
                    { 339, 3, null, 5, 3, 1, 2, null },
                    { 340, 4, null, 5, 3, 1, 2, null },
                    { 341, 5, null, 5, 3, 1, 2, null },
                    { 342, 6, null, 5, 3, 1, 2, null },
                    { 343, 7, null, 5, 3, 1, 2, null },
                    { 344, 8, null, 5, 3, 1, 2, null },
                    { 345, 9, null, 5, 3, 1, 2, null },
                    { 346, 10, null, 5, 3, 1, 2, null },
                    { 347, 11, null, 5, 3, 1, 2, null },
                    { 348, 12, null, 5, 3, 1, 2, null },
                    { 349, 1, null, 6, 3, 1, 2, null },
                    { 350, 2, null, 6, 3, 1, 2, null },
                    { 351, 3, null, 6, 3, 1, 2, null },
                    { 352, 4, null, 6, 3, 1, 2, null },
                    { 353, 5, null, 6, 3, 1, 2, null },
                    { 354, 6, null, 6, 3, 1, 2, null },
                    { 355, 7, null, 6, 3, 1, 2, null },
                    { 356, 8, null, 6, 3, 1, 2, null },
                    { 357, 9, null, 6, 3, 1, 2, null },
                    { 358, 10, null, 6, 3, 1, 2, null },
                    { 359, 11, null, 6, 3, 1, 2, null },
                    { 360, 12, null, 6, 3, 1, 2, null },
                    { 361, 1, null, 7, 3, 1, 2, null },
                    { 362, 2, null, 7, 3, 1, 2, null },
                    { 363, 3, null, 7, 3, 1, 2, null },
                    { 364, 4, null, 7, 3, 1, 2, null },
                    { 365, 5, null, 7, 3, 1, 2, null },
                    { 366, 6, null, 7, 3, 1, 2, null },
                    { 367, 7, null, 7, 3, 1, 2, null },
                    { 368, 8, null, 7, 3, 1, 2, null },
                    { 369, 9, null, 7, 3, 1, 2, null },
                    { 370, 10, null, 7, 3, 1, 2, null },
                    { 371, 11, null, 7, 3, 1, 2, null },
                    { 372, 12, null, 7, 3, 1, 2, null },
                    { 373, 1, null, 8, 3, 1, 2, null },
                    { 374, 2, null, 8, 3, 1, 2, null },
                    { 375, 3, null, 8, 3, 1, 2, null },
                    { 376, 4, null, 8, 3, 1, 2, null },
                    { 377, 5, null, 8, 3, 1, 2, null },
                    { 378, 6, null, 8, 3, 1, 2, null },
                    { 379, 7, null, 8, 3, 1, 2, null },
                    { 380, 8, null, 8, 3, 1, 2, null },
                    { 381, 9, null, 8, 3, 1, 2, null },
                    { 382, 10, null, 8, 3, 1, 2, null },
                    { 383, 11, null, 8, 3, 1, 2, null },
                    { 384, 12, null, 8, 3, 1, 2, null },
                    { 385, 1, null, 9, 3, 1, 2, null },
                    { 386, 2, null, 9, 3, 1, 2, null },
                    { 387, 3, null, 9, 3, 1, 2, null },
                    { 388, 4, null, 9, 3, 1, 2, null },
                    { 389, 5, null, 9, 3, 1, 2, null },
                    { 390, 6, null, 9, 3, 1, 2, null },
                    { 391, 7, null, 9, 3, 1, 2, null },
                    { 392, 8, null, 9, 3, 1, 2, null },
                    { 393, 9, null, 9, 3, 1, 2, null },
                    { 394, 10, null, 9, 3, 1, 2, null },
                    { 395, 11, null, 9, 3, 1, 2, null },
                    { 396, 12, null, 9, 3, 1, 2, null },
                    { 397, 1, null, 10, 3, 1, 2, null },
                    { 398, 2, null, 10, 3, 1, 2, null },
                    { 399, 3, null, 10, 3, 1, 2, null },
                    { 400, 4, null, 10, 3, 1, 2, null },
                    { 401, 5, null, 10, 3, 1, 2, null },
                    { 402, 6, null, 10, 3, 1, 2, null },
                    { 403, 7, null, 10, 3, 1, 2, null },
                    { 404, 8, null, 10, 3, 1, 2, null },
                    { 405, 9, null, 10, 3, 1, 2, null },
                    { 406, 10, null, 10, 3, 1, 2, null },
                    { 407, 11, null, 10, 3, 1, 2, null },
                    { 408, 12, null, 10, 3, 1, 2, null },
                    { 409, 1, null, 11, 3, 1, 2, null },
                    { 410, 2, null, 11, 3, 1, 2, null },
                    { 411, 3, null, 11, 3, 1, 2, null },
                    { 412, 4, null, 11, 3, 1, 2, null },
                    { 413, 5, null, 11, 3, 1, 2, null },
                    { 414, 6, null, 11, 3, 1, 2, null },
                    { 415, 7, null, 11, 3, 1, 2, null },
                    { 416, 8, null, 11, 3, 1, 2, null },
                    { 417, 9, null, 11, 3, 1, 2, null },
                    { 418, 10, null, 11, 3, 1, 2, null },
                    { 419, 11, null, 11, 3, 1, 2, null },
                    { 420, 12, null, 11, 3, 1, 2, null },
                    { 421, 1, null, 12, 3, 1, 2, null },
                    { 422, 2, null, 12, 3, 1, 2, null },
                    { 423, 3, null, 12, 3, 1, 2, null },
                    { 424, 4, null, 12, 3, 1, 2, null },
                    { 425, 5, null, 12, 3, 1, 2, null },
                    { 426, 6, null, 12, 3, 1, 2, null },
                    { 427, 7, null, 12, 3, 1, 2, null },
                    { 428, 8, null, 12, 3, 1, 2, null },
                    { 429, 9, null, 12, 3, 1, 2, null },
                    { 430, 10, null, 12, 3, 1, 2, null },
                    { 431, 11, null, 12, 3, 1, 2, null },
                    { 432, 12, null, 12, 3, 1, 2, null },
                    { 433, 1, null, 1, 4, 1, 2, null },
                    { 434, 2, null, 1, 4, 1, 2, null },
                    { 435, 3, null, 1, 4, 1, 2, null },
                    { 436, 4, null, 1, 4, 1, 2, null },
                    { 437, 5, null, 1, 4, 1, 2, null },
                    { 438, 6, null, 1, 4, 1, 2, null },
                    { 439, 7, null, 1, 4, 1, 2, null },
                    { 440, 8, null, 1, 4, 1, 2, null },
                    { 441, 9, null, 1, 4, 1, 2, null },
                    { 442, 10, null, 1, 4, 1, 2, null },
                    { 443, 11, null, 1, 4, 1, 2, null },
                    { 444, 12, null, 1, 4, 1, 2, null },
                    { 445, 1, null, 2, 4, 1, 2, null },
                    { 446, 2, null, 2, 4, 1, 2, null },
                    { 447, 3, null, 2, 4, 1, 2, null },
                    { 448, 4, null, 2, 4, 1, 2, null },
                    { 449, 5, null, 2, 4, 1, 2, null },
                    { 450, 6, null, 2, 4, 1, 2, null },
                    { 451, 7, null, 2, 4, 1, 2, null },
                    { 452, 8, null, 2, 4, 1, 2, null },
                    { 453, 9, null, 2, 4, 1, 2, null },
                    { 454, 10, null, 2, 4, 1, 2, null },
                    { 455, 11, null, 2, 4, 1, 2, null },
                    { 456, 12, null, 2, 4, 1, 2, null },
                    { 457, 1, null, 3, 4, 1, 2, null },
                    { 458, 2, null, 3, 4, 1, 2, null },
                    { 459, 3, null, 3, 4, 1, 2, null },
                    { 460, 4, null, 3, 4, 1, 2, null },
                    { 461, 5, null, 3, 4, 1, 2, null },
                    { 462, 6, null, 3, 4, 1, 2, null },
                    { 463, 7, null, 3, 4, 1, 2, null },
                    { 464, 8, null, 3, 4, 1, 2, null },
                    { 465, 9, null, 3, 4, 1, 2, null },
                    { 466, 10, null, 3, 4, 1, 2, null },
                    { 467, 11, null, 3, 4, 1, 2, null },
                    { 468, 12, null, 3, 4, 1, 2, null },
                    { 469, 1, null, 4, 4, 1, 2, null },
                    { 470, 2, null, 4, 4, 1, 2, null },
                    { 471, 3, null, 4, 4, 1, 2, null },
                    { 472, 4, null, 4, 4, 1, 2, null },
                    { 473, 5, null, 4, 4, 1, 2, null },
                    { 474, 6, null, 4, 4, 1, 2, null },
                    { 475, 7, null, 4, 4, 1, 2, null },
                    { 476, 8, null, 4, 4, 1, 2, null },
                    { 477, 9, null, 4, 4, 1, 2, null },
                    { 478, 10, null, 4, 4, 1, 2, null },
                    { 479, 11, null, 4, 4, 1, 2, null },
                    { 480, 12, null, 4, 4, 1, 2, null },
                    { 481, 1, null, 5, 4, 1, 2, null },
                    { 482, 2, null, 5, 4, 1, 2, null },
                    { 483, 3, null, 5, 4, 1, 2, null },
                    { 484, 4, null, 5, 4, 1, 2, null },
                    { 485, 5, null, 5, 4, 1, 2, null },
                    { 486, 6, null, 5, 4, 1, 2, null },
                    { 487, 7, null, 5, 4, 1, 2, null },
                    { 488, 8, null, 5, 4, 1, 2, null },
                    { 489, 9, null, 5, 4, 1, 2, null },
                    { 490, 10, null, 5, 4, 1, 2, null },
                    { 491, 11, null, 5, 4, 1, 2, null },
                    { 492, 12, null, 5, 4, 1, 2, null },
                    { 493, 1, null, 6, 4, 1, 2, null },
                    { 494, 2, null, 6, 4, 1, 2, null },
                    { 495, 3, null, 6, 4, 1, 2, null },
                    { 496, 4, null, 6, 4, 1, 2, null },
                    { 497, 5, null, 6, 4, 1, 2, null },
                    { 498, 6, null, 6, 4, 1, 2, null },
                    { 499, 7, null, 6, 4, 1, 2, null },
                    { 500, 8, null, 6, 4, 1, 2, null },
                    { 501, 9, null, 6, 4, 1, 2, null },
                    { 502, 10, null, 6, 4, 1, 2, null },
                    { 503, 11, null, 6, 4, 1, 2, null },
                    { 504, 12, null, 6, 4, 1, 2, null },
                    { 505, 1, null, 7, 4, 1, 2, null },
                    { 506, 2, null, 7, 4, 1, 2, null },
                    { 507, 3, null, 7, 4, 1, 2, null },
                    { 508, 4, null, 7, 4, 1, 2, null },
                    { 509, 5, null, 7, 4, 1, 2, null },
                    { 510, 6, null, 7, 4, 1, 2, null },
                    { 511, 7, null, 7, 4, 1, 2, null },
                    { 512, 8, null, 7, 4, 1, 2, null },
                    { 513, 9, null, 7, 4, 1, 2, null },
                    { 514, 10, null, 7, 4, 1, 2, null },
                    { 515, 11, null, 7, 4, 1, 2, null },
                    { 516, 12, null, 7, 4, 1, 2, null },
                    { 517, 1, null, 8, 4, 1, 2, null },
                    { 518, 2, null, 8, 4, 1, 2, null },
                    { 519, 3, null, 8, 4, 1, 2, null },
                    { 520, 4, null, 8, 4, 1, 2, null },
                    { 521, 5, null, 8, 4, 1, 2, null },
                    { 522, 6, null, 8, 4, 1, 2, null },
                    { 523, 7, null, 8, 4, 1, 2, null },
                    { 524, 8, null, 8, 4, 1, 2, null },
                    { 525, 9, null, 8, 4, 1, 2, null },
                    { 526, 10, null, 8, 4, 1, 2, null },
                    { 527, 11, null, 8, 4, 1, 2, null },
                    { 528, 12, null, 8, 4, 1, 2, null },
                    { 529, 1, null, 9, 4, 1, 2, null },
                    { 530, 2, null, 9, 4, 1, 2, null },
                    { 531, 3, null, 9, 4, 1, 2, null },
                    { 532, 4, null, 9, 4, 1, 2, null },
                    { 533, 5, null, 9, 4, 1, 2, null },
                    { 534, 6, null, 9, 4, 1, 2, null },
                    { 535, 7, null, 9, 4, 1, 2, null },
                    { 536, 8, null, 9, 4, 1, 2, null },
                    { 537, 9, null, 9, 4, 1, 2, null },
                    { 538, 10, null, 9, 4, 1, 2, null },
                    { 539, 11, null, 9, 4, 1, 2, null },
                    { 540, 12, null, 9, 4, 1, 2, null },
                    { 541, 1, null, 10, 4, 1, 2, null },
                    { 542, 2, null, 10, 4, 1, 2, null },
                    { 543, 3, null, 10, 4, 1, 2, null },
                    { 544, 4, null, 10, 4, 1, 2, null },
                    { 545, 5, null, 10, 4, 1, 2, null },
                    { 546, 6, null, 10, 4, 1, 2, null },
                    { 547, 7, null, 10, 4, 1, 2, null },
                    { 548, 8, null, 10, 4, 1, 2, null },
                    { 549, 9, null, 10, 4, 1, 2, null },
                    { 550, 10, null, 10, 4, 1, 2, null },
                    { 551, 11, null, 10, 4, 1, 2, null },
                    { 552, 12, null, 10, 4, 1, 2, null },
                    { 553, 1, null, 11, 4, 1, 2, null },
                    { 554, 2, null, 11, 4, 1, 2, null },
                    { 555, 3, null, 11, 4, 1, 2, null },
                    { 556, 4, null, 11, 4, 1, 2, null },
                    { 557, 5, null, 11, 4, 1, 2, null },
                    { 558, 6, null, 11, 4, 1, 2, null },
                    { 559, 7, null, 11, 4, 1, 2, null },
                    { 560, 8, null, 11, 4, 1, 2, null },
                    { 561, 9, null, 11, 4, 1, 2, null },
                    { 562, 10, null, 11, 4, 1, 2, null },
                    { 563, 11, null, 11, 4, 1, 2, null },
                    { 564, 12, null, 11, 4, 1, 2, null },
                    { 565, 1, null, 12, 4, 1, 2, null },
                    { 566, 2, null, 12, 4, 1, 2, null },
                    { 567, 3, null, 12, 4, 1, 2, null },
                    { 568, 4, null, 12, 4, 1, 2, null },
                    { 569, 5, null, 12, 4, 1, 2, null },
                    { 570, 6, null, 12, 4, 1, 2, null },
                    { 571, 7, null, 12, 4, 1, 2, null },
                    { 572, 8, null, 12, 4, 1, 2, null },
                    { 573, 9, null, 12, 4, 1, 2, null },
                    { 574, 10, null, 12, 4, 1, 2, null },
                    { 575, 11, null, 12, 4, 1, 2, null },
                    { 576, 12, null, 12, 4, 1, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "Price", "ScreeningId" },
                values: new object[,]
                {
                    { 1, 80000, 1 },
                    { 2, 80000, 1 },
                    { 3, 80000, 1 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "DateOfPurchase", "Discount", "OrderId", "Price", "SumPrice", "TicketId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 9, 20, 51, 43, 274, DateTimeKind.Local).AddTicks(1992), 0m, 1, 189000m, 189000m, 1, 1 },
                    { 2, new DateTime(2024, 7, 9, 20, 51, 43, 274, DateTimeKind.Local).AddTicks(1995), 0m, 2, 209000m, 209000m, 2, 1 },
                    { 3, new DateTime(2024, 7, 9, 20, 51, 43, 274, DateTimeKind.Local).AddTicks(1997), 10000m, 3, 189000m, 179000m, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Seat",
                columns: new[] { "Id", "Number", "PersonTypeId", "Row", "ScreeningId", "SeatStatusId", "SeatTypeId", "TicketId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 1, 2, 1, 1 },
                    { 2, 2, 1, 1, 1, 2, 1, 2 },
                    { 3, 3, 1, 1, 1, 2, 1, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auditoriums_CinemaId",
                table: "Auditoriums",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cinemas_ProvinceId",
                table: "Cinemas",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_MovieId",
                table: "Comments",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultPriceTables_PersonTypeId",
                table: "DefaultPriceTables",
                column: "PersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_OrderId",
                table: "Invoices",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_TicketId",
                table: "Invoices",
                column: "TicketId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_UserId",
                table: "Invoices",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieImages_MovieId",
                table: "MovieImages",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieImages_MovieImageTypeId",
                table: "MovieImages",
                column: "MovieImageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieInCategories_CategoryId",
                table: "MovieInCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductComboInOrders_ProductComboId",
                table: "ProductComboInOrders",
                column: "ProductComboId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInProductCombos_ProductComboId",
                table: "ProductInProductCombos",
                column: "ProductComboId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Screenings_AuditoriumId",
                table: "Screenings",
                column: "AuditoriumId");

            migrationBuilder.CreateIndex(
                name: "IX_Screenings_MovieId",
                table: "Screenings",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_PersonTypeId",
                table: "Seat",
                column: "PersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_ScreeningId",
                table: "Seat",
                column: "ScreeningId");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_SeatStatusId",
                table: "Seat",
                column: "SeatStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_SeatTypeId",
                table: "Seat",
                column: "SeatTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_TicketId",
                table: "Seat",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ScreeningId",
                table: "Tickets",
                column: "ScreeningId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInRoles_RoleId",
                table: "UserInRoles",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "DefaultPriceTables");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "MovieImages");

            migrationBuilder.DropTable(
                name: "MovieInCategories");

            migrationBuilder.DropTable(
                name: "ProductComboInOrders");

            migrationBuilder.DropTable(
                name: "ProductInProductCombos");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "UserInRoles");

            migrationBuilder.DropTable(
                name: "MovieImageTypes");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductCombos");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "PersonTypes");

            migrationBuilder.DropTable(
                name: "SeatStatuses");

            migrationBuilder.DropTable(
                name: "SeatTypes");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Screenings");

            migrationBuilder.DropTable(
                name: "Auditoriums");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Cinemas");

            migrationBuilder.DropTable(
                name: "Provinces");
        }
    }
}
