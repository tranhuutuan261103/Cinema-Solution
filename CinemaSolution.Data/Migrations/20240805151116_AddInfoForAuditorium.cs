using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaSolution.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddInfoForAuditorium : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Provinces_ProvinceId",
                table: "Cinemas");

            migrationBuilder.DropIndex(
                name: "IX_Cinemas_ProvinceId",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "Cinemas");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 5, 22, 11, 15, 837, DateTimeKind.Local).AddTicks(6081),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 5, 6, 14, 1, 930, DateTimeKind.Local).AddTicks(9362));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "MovieImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 5, 22, 11, 15, 838, DateTimeKind.Local).AddTicks(5589),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 5, 6, 14, 1, 931, DateTimeKind.Local).AddTicks(8857));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 5, 22, 11, 15, 838, DateTimeKind.Local).AddTicks(9851),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 5, 6, 14, 1, 932, DateTimeKind.Local).AddTicks(3504));

            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "Cinemas",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Auditoriums",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Auditoriums",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Auditoriums",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "Auditoriums",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Auditoriums",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Latitude", "Longitude", "Name", "ProvinceId" },
                values: new object[] { "Hà Nội", 105.0, 21.0, "CGV Long Biên", 1 });

            migrationBuilder.UpdateData(
                table: "Auditoriums",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "Latitude", "Longitude", "Name", "ProvinceId" },
                values: new object[] { "Hà Nội", 105.0, 21.0, "CGV Vincom Bà Triệu", 1 });

            migrationBuilder.UpdateData(
                table: "Auditoriums",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "CinemaId", "Latitude", "Longitude", "Name", "ProvinceId" },
                values: new object[] { "Đà Nẵng", 1, 108.0, 16.0, "CGV Vincom Đà Nẵng", 2 });

            migrationBuilder.UpdateData(
                table: "Auditoriums",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "CinemaId", "Latitude", "Longitude", "Name", "ProvinceId" },
                values: new object[] { "Đà Nẵng", 1, 108.0, 16.0, "CGV Vĩnh Trung Plaza", 2 });

            migrationBuilder.InsertData(
                table: "Auditoriums",
                columns: new[] { "Id", "Address", "CinemaId", "Latitude", "Longitude", "Name", "ProvinceId", "SeatMapVector" },
                values: new object[,]
                {
                    { 5, "Đà Nẵng", 2, 108.0, 16.0, "Lotte Đà Nẵng", 2, "111111111111111111111111222222222222222222222222222222222222111111111111111111111111111111111111111111111111111111111111111111111111111111111111" },
                    { 6, "Đà Nẵng", 2, 108.0, 16.0, "Lotte Vĩnh Trung Plaza", 2, "111111111111111111111111222222222222222222222222222222222222111111111111111111111111111111111111111111111111111111111111111111111111111111111111" }
                });

            migrationBuilder.UpdateData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LogoUrl", "Name" },
                values: new object[] { "https://firebasestorage.googleapis.com/v0/b/tune-cinema.appspot.com/o/cinema_logo%2FCGV.png?alt=media&token=b1da43c8-0877-480a-96be-a557b3347a20", "CGV" });

            migrationBuilder.UpdateData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LogoUrl", "Name" },
                values: new object[] { "https://firebasestorage.googleapis.com/v0/b/tune-cinema.appspot.com/o/cinema_logo%2FLotte.png?alt=media&token=02d3da6d-061c-47d2-9838-2e6061b101d6", "Lotte" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 5, 22, 11, 15, 847, DateTimeKind.Local).AddTicks(1633));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 5, 22, 11, 15, 847, DateTimeKind.Local).AddTicks(1638));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfPurchase",
                value: new DateTime(2024, 8, 5, 22, 11, 15, 847, DateTimeKind.Local).AddTicks(2722));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfPurchase",
                value: new DateTime(2024, 8, 5, 22, 11, 15, 847, DateTimeKind.Local).AddTicks(2726));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateOfPurchase",
                value: new DateTime(2024, 8, 5, 22, 11, 15, 847, DateTimeKind.Local).AddTicks(2728));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 8, 5, 22, 11, 15, 838, DateTimeKind.Local).AddTicks(5589));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 8, 5, 22, 11, 15, 838, DateTimeKind.Local).AddTicks(5589));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 8, 5, 22, 11, 15, 838, DateTimeKind.Local).AddTicks(5589));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 8, 5, 22, 11, 15, 838, DateTimeKind.Local).AddTicks(5589));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 8, 5, 22, 11, 15, 838, DateTimeKind.Local).AddTicks(5589));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "dgLM2bNG8k63DnOwC5hqvzACi3yTnnhQ+bOp7xL1zdU=", "HFKdDyvXdJabY3CrhHWwEA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "EpCYsOnW+SyCFqFQsO2znoDto1AMpeI1612nFWbzQf8=", "BlRZx+i4vHPLN84QL8IF+A==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "EpCYsOnW+SyCFqFQsO2znoDto1AMpeI1612nFWbzQf8=", "BlRZx+i4vHPLN84QL8IF+A==" });

            migrationBuilder.CreateIndex(
                name: "IX_Auditoriums_ProvinceId",
                table: "Auditoriums",
                column: "ProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Auditoriums_Provinces_ProvinceId",
                table: "Auditoriums",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auditoriums_Provinces_ProvinceId",
                table: "Auditoriums");

            migrationBuilder.DropIndex(
                name: "IX_Auditoriums_ProvinceId",
                table: "Auditoriums");

            migrationBuilder.DeleteData(
                table: "Auditoriums",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Auditoriums",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Auditoriums");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Auditoriums");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Auditoriums");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "Auditoriums");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 5, 6, 14, 1, 930, DateTimeKind.Local).AddTicks(9362),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 5, 22, 11, 15, 837, DateTimeKind.Local).AddTicks(6081));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "MovieImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 5, 6, 14, 1, 931, DateTimeKind.Local).AddTicks(8857),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 5, 22, 11, 15, 838, DateTimeKind.Local).AddTicks(5589));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 5, 6, 14, 1, 932, DateTimeKind.Local).AddTicks(3504),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 5, 22, 11, 15, 838, DateTimeKind.Local).AddTicks(9851));

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Cinemas",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "Cinemas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Auditoriums",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "A1");

            migrationBuilder.UpdateData(
                table: "Auditoriums",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "A2");

            migrationBuilder.UpdateData(
                table: "Auditoriums",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CinemaId", "Name" },
                values: new object[] { 2, "A3" });

            migrationBuilder.UpdateData(
                table: "Auditoriums",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CinemaId", "Name" },
                values: new object[] { 2, "A4" });

            migrationBuilder.UpdateData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Name", "ProvinceId" },
                values: new object[] { "Hà Nội", "CGV Hà Nội", 1 });

            migrationBuilder.UpdateData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "Name", "ProvinceId" },
                values: new object[] { "Đà Nẵng", "CGV Đà Nẵng", 2 });

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
                column: "DateCreated",
                value: new DateTime(2024, 8, 5, 6, 14, 1, 931, DateTimeKind.Local).AddTicks(8857));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 8, 5, 6, 14, 1, 931, DateTimeKind.Local).AddTicks(8857));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 8, 5, 6, 14, 1, 931, DateTimeKind.Local).AddTicks(8857));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 8, 5, 6, 14, 1, 931, DateTimeKind.Local).AddTicks(8857));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 8, 5, 6, 14, 1, 931, DateTimeKind.Local).AddTicks(8857));

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

            migrationBuilder.CreateIndex(
                name: "IX_Cinemas_ProvinceId",
                table: "Cinemas",
                column: "ProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Provinces_ProvinceId",
                table: "Cinemas",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
