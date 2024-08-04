using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaSolution.Data.Migrations
{
    /// <inheritdoc />
    public partial class CrawlNewData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MovieInCategories",
                keyColumns: new[] { "CategoryId", "MovieId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "MovieInCategories",
                keyColumns: new[] { "CategoryId", "MovieId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "MovieInCategories",
                keyColumns: new[] { "CategoryId", "MovieId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "MovieInCategories",
                keyColumns: new[] { "CategoryId", "MovieId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "MovieInCategories",
                keyColumns: new[] { "CategoryId", "MovieId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "MovieInCategories",
                keyColumns: new[] { "CategoryId", "MovieId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 5, 6, 14, 1, 930, DateTimeKind.Local).AddTicks(9362),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 3, 22, 58, 50, 484, DateTimeKind.Local).AddTicks(7573));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Movies",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1028)",
                oldMaxLength: 1028);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "MovieImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 5, 6, 14, 1, 931, DateTimeKind.Local).AddTicks(8857),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 3, 22, 58, 50, 485, DateTimeKind.Local).AddTicks(7303));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 5, 6, 14, 1, 932, DateTimeKind.Local).AddTicks(3504),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 3, 22, 58, 50, 486, DateTimeKind.Local).AddTicks(2260));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Cao bồi");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Chiến tranh");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Gia đình");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Giả tưởng");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Giật Gân");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Hài");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Hành động");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 8, "Hình sự" },
                    { 9, "Hoạt hình" },
                    { 10, "Kinh dị" },
                    { 11, "Lãng mạn" },
                    { 12, "Lịch sử" },
                    { 13, "Ly kì" },
                    { 14, "Nhạc kịch" },
                    { 15, "Phiêu lưu" },
                    { 16, "Tài liệu" },
                    { 17, "Tâm lý" },
                    { 18, "Thần thoại" },
                    { 19, "Thể thao" },
                    { 20, "Tiểu sử" },
                    { 21, "Tình cảm" },
                    { 22, "Tội phạm" }
                });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 5, 6, 14, 1, 938, DateTimeKind.Local).AddTicks(8676));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 5, 6, 14, 1, 938, DateTimeKind.Local).AddTicks(8678));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfPurchase",
                value: new DateTime(2024, 8, 5, 6, 14, 1, 938, DateTimeKind.Local).AddTicks(9370));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfPurchase",
                value: new DateTime(2024, 8, 5, 6, 14, 1, 938, DateTimeKind.Local).AddTicks(9374));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateOfPurchase",
                value: new DateTime(2024, 8, 5, 6, 14, 1, 938, DateTimeKind.Local).AddTicks(9376));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "ImageUrl" },
                values: new object[] { new DateTime(2024, 8, 5, 6, 14, 1, 931, DateTimeKind.Local).AddTicks(8857), "https://firebasestorage.googleapis.com/v0/b/tune-cinema.appspot.com/o/movie_thumbnail%2FDeadpool%20%26%20Wolverine.jpg?alt=media&token=ae6340d3-3b0d-4b59-b1ef-d8c56aa72c54" });

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "ImageUrl" },
                values: new object[] { new DateTime(2024, 8, 5, 6, 14, 1, 931, DateTimeKind.Local).AddTicks(8857), "https://firebasestorage.googleapis.com/v0/b/tune-cinema.appspot.com/o/movie_thumbnail%2FDeadpool%20%26%20Wolverine%20-%20Backdrop.jpg?alt=media&token=68132efe-85cc-4760-845a-12164e26453b" });

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "ImageUrl" },
                values: new object[] { new DateTime(2024, 8, 5, 6, 14, 1, 931, DateTimeKind.Local).AddTicks(8857), "https://firebasestorage.googleapis.com/v0/b/tune-cinema.appspot.com/o/movie_thumbnail%2FConan.jpg?alt=media&token=c0ffb6db-f8b1-4930-9136-54bd38ccc209" });

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "ImageUrl" },
                values: new object[] { new DateTime(2024, 8, 5, 6, 14, 1, 931, DateTimeKind.Local).AddTicks(8857), "https://firebasestorage.googleapis.com/v0/b/tune-cinema.appspot.com/o/movie_thumbnail%2FConan-Backdrop.jpg?alt=media&token=6fb5b903-397d-4fa2-9c2a-90f52007359e" });

            migrationBuilder.InsertData(
                table: "MovieInCategories",
                columns: new[] { "CategoryId", "MovieId" },
                values: new object[,]
                {
                    { 4, 1 },
                    { 6, 1 },
                    { 7, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Actors", "Description", "Director", "Duration", "Language", "ReleaseDate", "Title", "TrailerUrl" },
                values: new object[] { "Ryan Reynolds, Hugh Jackman, Patrick Stewart", "Sau một số tác phẩm chưa đạt thành công như kì vọng gần đây, Marvel Studios ngày càng thận trọng khi ra mắt các dự án mới. Deadpool & Wolverine chính là bộ phim Marvel duy nhất ra mắt năm 2024. Bộ phim là tác phẩm mà công chúng kì vọng sẽ cứu rỗi vũ trụ điện ảnh Marvel khỏi cơn thoái trào. Chính vì vậy, chẳng có gì ngạc nhiên khi Deadpool & Wolverine được đầu tư, chăm chút hết sức kĩ lưỡng. \r\nSau teaser và trailer đầu tiên, cốt truyện Deadpool & Wolverine dần dần hé lộ. Đặc sản “trứng phục sinh” bùng nổ ở trailer, khiến khán giả đồn đoán liên tục, gợi nhớ đến loạt tác phẩm quen thuộc như Ant-Man, X-Men United, X-Men: First Class, Loki… \r\nPhản diện phần này là Cassandra Nova – em gái song sinh độc ác của giáo sư X. Ả sở hữu khả năng ngoại cảm cùng hàng tá kĩ năng dễ dàng đo ván Wolverine và Deadpool. Vai diễn nặng kí này Emma Corrin đảm nhận. Cô được biết đến khi trở thành vương phi Diana thời trẻ trong series truyền hình nổi tiếng The Crown. \r\nSau Tim Miller (Deadpool) và David Leitch (Deadpool 2), đạo diễn Shawn Levy của Real Steel và Free Guy là cái tên tiếp theo cầm trịch tác phẩm về gã phản anh hùng nói nhiều. Ryan Reynolds tiếp tục quay lại vai diễn mang tính biểu tượng trong sự nghiệp. Anh tham gia luôn khâu biên kịch cùng Rhett Reese, Paul Wernick, Zeb Wells và Shawn Levy. Hugh Jackman cũng tái xuất vai diễn dường như chẳng ai thay thế nổi – Wolverine.", "Shawn Levy", 127, "Phụ đề", new DateTime(2024, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deadpool & Wolverine", "https://www.youtube.com/embed/lW4-A3ZQnVQ" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Actors", "Description", "Director", "Duration", "Language", "Rating", "ReleaseDate", "Title", "TrailerUrl" },
                values: new object[] { "Takayama Minami, Yamazaki Wakana", "Siêu trộm Kaito Kid và thám tử miền Tây Hattori Heiji cùng đối đầu trong cuộc tranh giành thanh kiếm thuộc về Hijikata Toushizou - phó chỉ huy của Shinsengumi! Thù mới hận cũ, Heiji sẽ xử trí Kid thế nào đây?\r\nNgoài ra, một bí mật kinh khủng về Kaito Kid sắp được tiếp lộ...", "Nagaoka Tomoka", 111, "Phụ đề Lồng tiếng", 9.8000000000000007, new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thám Tử Lừng Danh Conan: Ngôi Sao 5 Cánh 1 Triệu Đô", "https://www.youtube.com/embed/x_gGMJOppAo" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Actors", "Description", "Director", "Duration", "EndDate", "Language", "Rating", "ReleaseDate", "Title", "TrailerUrl" },
                values: new object[] { 3, "Ha Jung Woo, Yeo Jin Goo, Sung Dong Il", "Bộ phim hành động ly kỳ dựa trên sự kiện có thật với sự tham gia của Ha Jung Woo, Yeo Jin Goo và Sung Dong Il được dựa trên một sự kiện có thật năm 1971, khi một thanh niên Hàn Quốc định cướp một chiếc máy bay chở khách khởi hành từ thành phố cảnh phía đông Sokcho bay tới Seoul. Mọi người trên chuyến bay này đều đang đặt cược mạng sống của mình!", "Kim Sung Han", 100, new DateTime(2024, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phụ đề", 9.5, new DateTime(2024, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vây Hãm Trên Không", "https://www.youtube.com/embed/1Umr4h5dn5I" });

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2024, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2024, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "i2Z/oNdfXlZpK8ylECOlTZbsn66wftJ4vKsz8GArCiE=", "FVB6bQhVap2IWa7cI41EoA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "HhsIf1aezQtxr/wEU82iWagfHTIUgbLwk/vrjClddbo=", "b1/RBHULz0hgzHB0gkXiqQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "HhsIf1aezQtxr/wEU82iWagfHTIUgbLwk/vrjClddbo=", "b1/RBHULz0hgzHB0gkXiqQ==" });

            migrationBuilder.InsertData(
                table: "MovieImages",
                columns: new[] { "Id", "Caption", "ImageUrl", "IsPoster", "MovieId", "MovieImageTypeId" },
                values: new object[] { 5, null, "https://firebasestorage.googleapis.com/v0/b/tune-cinema.appspot.com/o/movie_thumbnail%2FVay%20Ham%20Tren%20Khong.jpg?alt=media&token=fa1c6658-db84-4bbc-9410-7c00c9f98b68", true, 3, 1 });

            migrationBuilder.InsertData(
                table: "MovieInCategories",
                columns: new[] { "CategoryId", "MovieId" },
                values: new object[,]
                {
                    { 9, 2 },
                    { 5, 3 },
                    { 7, 3 },
                    { 22, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MovieInCategories",
                keyColumns: new[] { "CategoryId", "MovieId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "MovieInCategories",
                keyColumns: new[] { "CategoryId", "MovieId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "MovieInCategories",
                keyColumns: new[] { "CategoryId", "MovieId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "MovieInCategories",
                keyColumns: new[] { "CategoryId", "MovieId" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "MovieInCategories",
                keyColumns: new[] { "CategoryId", "MovieId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "MovieInCategories",
                keyColumns: new[] { "CategoryId", "MovieId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "MovieInCategories",
                keyColumns: new[] { "CategoryId", "MovieId" },
                keyValues: new object[] { 22, 3 });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 3, 22, 58, 50, 484, DateTimeKind.Local).AddTicks(7573),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 5, 6, 14, 1, 930, DateTimeKind.Local).AddTicks(9362));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Movies",
                type: "nvarchar(1028)",
                maxLength: 1028,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2048)",
                oldMaxLength: 2048);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "MovieImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 3, 22, 58, 50, 485, DateTimeKind.Local).AddTicks(7303),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 5, 6, 14, 1, 931, DateTimeKind.Local).AddTicks(8857));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 3, 22, 58, 50, 486, DateTimeKind.Local).AddTicks(2260),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 5, 6, 14, 1, 932, DateTimeKind.Local).AddTicks(3504));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Action");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Adventure");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Animation");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Comedy");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Crime");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Documentary");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Drama");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 3, 22, 58, 50, 492, DateTimeKind.Local).AddTicks(7923));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 3, 22, 58, 50, 492, DateTimeKind.Local).AddTicks(7926));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfPurchase",
                value: new DateTime(2024, 8, 3, 22, 58, 50, 492, DateTimeKind.Local).AddTicks(8645));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfPurchase",
                value: new DateTime(2024, 8, 3, 22, 58, 50, 492, DateTimeKind.Local).AddTicks(8647));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateOfPurchase",
                value: new DateTime(2024, 8, 3, 22, 58, 50, 492, DateTimeKind.Local).AddTicks(8649));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "ImageUrl" },
                values: new object[] { new DateTime(2024, 8, 3, 22, 58, 50, 485, DateTimeKind.Local).AddTicks(7303), "https://image.tmdb.org/t/p/w500/7D430eqZj8y3oVkLFfsWXGRcpEG.jpg" });

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "ImageUrl" },
                values: new object[] { new DateTime(2024, 8, 3, 22, 58, 50, 485, DateTimeKind.Local).AddTicks(7303), "https://image.tmdb.org/t/p/w500/5aXp2s4l6g5PcMMesIj63mx8hmJ.jpg" });

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "ImageUrl" },
                values: new object[] { new DateTime(2024, 8, 3, 22, 58, 50, 485, DateTimeKind.Local).AddTicks(7303), "https://image.tmdb.org/t/p/w500/7D430eqZj8y3oVkLFfsWXGRcpEG.jpg" });

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "ImageUrl" },
                values: new object[] { new DateTime(2024, 8, 3, 22, 58, 50, 485, DateTimeKind.Local).AddTicks(7303), "https://image.tmdb.org/t/p/w500/5aXp2s4l6g5PcMMesIj63mx8hmJ.jpg" });

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

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Actors", "Description", "Director", "Duration", "Language", "ReleaseDate", "Title", "TrailerUrl" },
                values: new object[] { "Charlize Theron, KiKi Layne, Marwan Kenzari, Luca Marinelli, Harry Melling", "Four undying warriors who've secretly protected humanity for centuries become targeted for their mysterious powers just as they discover a new immortal.", "Gina Prince-Bythewood", 125, "English", new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Old Guard", "https://www.youtube.com/embed/aK-X2d0lJ_s" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Actors", "Description", "Director", "Duration", "Language", "Rating", "ReleaseDate", "Title", "TrailerUrl" },
                values: new object[] { "Joey King, Joel Courtney, Jacob Elordi", "In the sequel to 2018's THE KISSING BOOTH, high school senior Elle juggles a long-distance relationship with her dreamy boyfriend Noah, college applications, and a new friendship with a handsome classmate that could change everything.", "Vince Marcello", 130, "English", 7.0, new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Kissing Booth 2", "https://www.youtube.com/embed/ZR2JlDnT2l8" });

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "5IkPXeBEmZchZDBOp11MiCFgTyz48mYURggwZvUMkEA=", "Ztr57hXMJclqd5E4JMpoYg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "0kUPYd54Ok10XRfnpezyjjXijWm1gjGjfBXSzNWVv1M=", "MII4OTQlyHa9SnbzkJpzfQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "0kUPYd54Ok10XRfnpezyjjXijWm1gjGjfBXSzNWVv1M=", "MII4OTQlyHa9SnbzkJpzfQ==" });
        }
    }
}
