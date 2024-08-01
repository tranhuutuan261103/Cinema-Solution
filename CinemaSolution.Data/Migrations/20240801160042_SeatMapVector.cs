using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaSolution.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeatMapVector : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 1, 23, 0, 42, 100, DateTimeKind.Local).AddTicks(2412),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 9, 20, 51, 43, 261, DateTimeKind.Local).AddTicks(6131));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "MovieImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 1, 23, 0, 42, 101, DateTimeKind.Local).AddTicks(953),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 9, 20, 51, 43, 263, DateTimeKind.Local).AddTicks(5942));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 1, 23, 0, 42, 101, DateTimeKind.Local).AddTicks(5039),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 9, 20, 51, 43, 264, DateTimeKind.Local).AddTicks(3318));

            migrationBuilder.AddColumn<string>(
                name: "SeatMapVector",
                table: "Auditoriums",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Auditoriums",
                keyColumn: "Id",
                keyValue: 1,
                column: "SeatMapVector",
                value: "111111111111|111111111111|222222222222|222222222222|222222222222|111111111111|111111111111|111111111111|111111111111|111111111111|111111111111|111111111111");

            migrationBuilder.UpdateData(
                table: "Auditoriums",
                keyColumn: "Id",
                keyValue: 2,
                column: "SeatMapVector",
                value: "111111111111|111111111111|222222222222|222222222222|222222222222|111111111111|111111111111|111111111111|111111111111|111111111111|111111111111|111111111111");

            migrationBuilder.UpdateData(
                table: "Auditoriums",
                keyColumn: "Id",
                keyValue: 3,
                column: "SeatMapVector",
                value: "111111111111|111111111111|222222222222|222222222222|222222222222|111111111111|111111111111|111111111111|111111111111|111111111111|111111111111|111111111111");

            migrationBuilder.UpdateData(
                table: "Auditoriums",
                keyColumn: "Id",
                keyValue: 4,
                column: "SeatMapVector",
                value: "111111111111|111111111111|222222222222|222222222222|222222222222|111111111111|111111111111|111111111111|111111111111|111111111111|111111111111|111111111111");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 23, 0, 42, 109, DateTimeKind.Local).AddTicks(3140));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 23, 0, 42, 109, DateTimeKind.Local).AddTicks(3142));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfPurchase",
                value: new DateTime(2024, 8, 1, 23, 0, 42, 109, DateTimeKind.Local).AddTicks(3848));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfPurchase",
                value: new DateTime(2024, 8, 1, 23, 0, 42, 109, DateTimeKind.Local).AddTicks(3851));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateOfPurchase",
                value: new DateTime(2024, 8, 1, 23, 0, 42, 109, DateTimeKind.Local).AddTicks(3853));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 8, 1, 23, 0, 42, 101, DateTimeKind.Local).AddTicks(953));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 8, 1, 23, 0, 42, 101, DateTimeKind.Local).AddTicks(953));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 8, 1, 23, 0, 42, 101, DateTimeKind.Local).AddTicks(953));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 8, 1, 23, 0, 42, 101, DateTimeKind.Local).AddTicks(953));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "HN/4vC7yVeTy2caOZ+2B9FMO25LE9Dgn5st4xFFE0b8=", "MGudW4BK66THa9+6H8/trQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "fzrk1+qnXkTRlCwksDc+oI3vmLerYDIWdRym4W/sOeI=", "b8SPr8JlHqlEAYhnxYzYlw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "fzrk1+qnXkTRlCwksDc+oI3vmLerYDIWdRym4W/sOeI=", "b8SPr8JlHqlEAYhnxYzYlw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeatMapVector",
                table: "Auditoriums");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 9, 20, 51, 43, 261, DateTimeKind.Local).AddTicks(6131),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 1, 23, 0, 42, 100, DateTimeKind.Local).AddTicks(2412));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "MovieImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 9, 20, 51, 43, 263, DateTimeKind.Local).AddTicks(5942),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 1, 23, 0, 42, 101, DateTimeKind.Local).AddTicks(953));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 9, 20, 51, 43, 264, DateTimeKind.Local).AddTicks(3318),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 1, 23, 0, 42, 101, DateTimeKind.Local).AddTicks(5039));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 9, 20, 51, 43, 274, DateTimeKind.Local).AddTicks(1260));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 9, 20, 51, 43, 274, DateTimeKind.Local).AddTicks(1262));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfPurchase",
                value: new DateTime(2024, 7, 9, 20, 51, 43, 274, DateTimeKind.Local).AddTicks(1992));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfPurchase",
                value: new DateTime(2024, 7, 9, 20, 51, 43, 274, DateTimeKind.Local).AddTicks(1995));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateOfPurchase",
                value: new DateTime(2024, 7, 9, 20, 51, 43, 274, DateTimeKind.Local).AddTicks(1997));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 7, 9, 20, 51, 43, 263, DateTimeKind.Local).AddTicks(5942));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 7, 9, 20, 51, 43, 263, DateTimeKind.Local).AddTicks(5942));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 7, 9, 20, 51, 43, 263, DateTimeKind.Local).AddTicks(5942));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 7, 9, 20, 51, 43, 263, DateTimeKind.Local).AddTicks(5942));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "wm3S0Z61/isgEwGHZoiGDDXpIVLEsBMKvouapX12OnA=", "7K79ePE4NLb2rPOnWokBkg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "iMHisUy3QbsgQ2fKvh1DvjOQJax1D9K0zVb1uHKJSwg=", "0WAOE+EmrN6VvhOpc1iL7g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "iMHisUy3QbsgQ2fKvh1DvjOQJax1D9K0zVb1uHKJSwg=", "0WAOE+EmrN6VvhOpc1iL7g==" });
        }
    }
}
