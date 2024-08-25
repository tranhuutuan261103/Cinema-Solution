using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaSolution.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateScreeningData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 25, 22, 49, 24, 706, DateTimeKind.Local).AddTicks(333),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 17, 21, 57, 50, 623, DateTimeKind.Local).AddTicks(8845));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "MovieImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 25, 22, 49, 24, 707, DateTimeKind.Local).AddTicks(1903),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 17, 21, 57, 50, 624, DateTimeKind.Local).AddTicks(7564));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 25, 22, 49, 24, 707, DateTimeKind.Local).AddTicks(6684),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 17, 21, 57, 50, 625, DateTimeKind.Local).AddTicks(1545));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "CommentLikes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 25, 22, 49, 24, 708, DateTimeKind.Local).AddTicks(500),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 17, 21, 57, 50, 625, DateTimeKind.Local).AddTicks(4884));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumns: new[] { "CommentId", "UserId" },
                keyValues: new object[] { 1, 2 },
                column: "CreatedAt",
                value: new DateTime(2024, 8, 25, 22, 49, 24, 708, DateTimeKind.Local).AddTicks(500));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumns: new[] { "CommentId", "UserId" },
                keyValues: new object[] { 1, 3 },
                column: "CreatedAt",
                value: new DateTime(2024, 8, 25, 22, 49, 24, 708, DateTimeKind.Local).AddTicks(500));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 25, 22, 49, 24, 715, DateTimeKind.Local).AddTicks(5404));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 25, 22, 49, 24, 715, DateTimeKind.Local).AddTicks(5407));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 25, 22, 49, 24, 715, DateTimeKind.Local).AddTicks(5409));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfPurchase",
                value: new DateTime(2024, 8, 25, 22, 49, 24, 715, DateTimeKind.Local).AddTicks(6299));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfPurchase",
                value: new DateTime(2024, 8, 25, 22, 49, 24, 715, DateTimeKind.Local).AddTicks(6302));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateOfPurchase",
                value: new DateTime(2024, 8, 25, 22, 49, 24, 715, DateTimeKind.Local).AddTicks(6304));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 8, 25, 22, 49, 24, 707, DateTimeKind.Local).AddTicks(1903));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 8, 25, 22, 49, 24, 707, DateTimeKind.Local).AddTicks(1903));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 8, 25, 22, 49, 24, 707, DateTimeKind.Local).AddTicks(1903));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 8, 25, 22, 49, 24, 707, DateTimeKind.Local).AddTicks(1903));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 8, 25, 22, 49, 24, 707, DateTimeKind.Local).AddTicks(1903));

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2024, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2024, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 4,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 5,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 6,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 7,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 8,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 9,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 10,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 11,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 12,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 13,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 14,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 15,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 16,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 17,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 18,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 19,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 20,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 21,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 22,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 23,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 24,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 61,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 62,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 63,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 64,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 65,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 66,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 67,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 68,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 69,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 70,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 71,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 72,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 73,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 74,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 75,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 76,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 77,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 78,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 79,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 80,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 81,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 82,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 83,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 84,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 85,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 86,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 87,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 88,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 89,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 90,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 91,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 92,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 93,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 94,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 95,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 96,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 97,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 98,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 99,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 100,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 101,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 102,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 103,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 104,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 105,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 106,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 107,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 108,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 109,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 110,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 111,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 112,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 113,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 114,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 115,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 116,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 117,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 118,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 119,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 120,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 121,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 122,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 123,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 124,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 125,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 126,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 127,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 128,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 129,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 130,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 131,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 132,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 133,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 134,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 135,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 136,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 137,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 138,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 139,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 140,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 141,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 142,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 143,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 144,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 145,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 146,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 147,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 148,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 149,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 150,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 151,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 152,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 153,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 154,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 155,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 156,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 157,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 158,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 159,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 160,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 161,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 162,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 163,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 164,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 165,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 166,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 167,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 168,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 205,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 206,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 207,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 208,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 209,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 210,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 211,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 212,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 213,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 214,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 215,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 216,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 217,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 218,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 219,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 220,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 221,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 222,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 223,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 224,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 225,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 226,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 227,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 228,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 229,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 230,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 231,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 232,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 233,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 234,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 235,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 236,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 237,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 238,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 239,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 240,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 241,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 242,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 243,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 244,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 245,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 246,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 247,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 248,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 249,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 250,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 251,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 252,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 253,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 254,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 255,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 256,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 257,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 258,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 259,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 260,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 261,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 262,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 263,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 264,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 265,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 266,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 267,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 268,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 269,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 270,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 271,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 272,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 273,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 274,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 275,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 276,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 277,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 278,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 279,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 280,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 281,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 282,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 283,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 284,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 285,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 286,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 287,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 288,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 289,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 290,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 291,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 292,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 293,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 294,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 295,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 296,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 297,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 298,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 299,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 300,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 301,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 302,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 303,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 304,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 305,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 306,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 307,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 308,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 309,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 310,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 311,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 312,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 349,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 350,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 351,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 352,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 353,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 354,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 355,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 356,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 357,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 358,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 359,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 360,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 361,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 362,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 363,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 364,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 365,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 366,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 367,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 368,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 369,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 370,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 371,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 372,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 373,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 374,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 375,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 376,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 377,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 378,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 379,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 380,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 381,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 382,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 383,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 384,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 385,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 386,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 387,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 388,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 389,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 390,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 391,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 392,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 393,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 394,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 395,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 396,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 397,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 398,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 399,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 400,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 401,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 402,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 403,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 404,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 405,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 406,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 407,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 408,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 409,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 410,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 411,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 412,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 413,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 414,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 415,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 416,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 417,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 418,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 419,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 420,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 421,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 422,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 423,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 424,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 425,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 426,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 427,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 428,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 429,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 430,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 431,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 432,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 433,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 434,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 435,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 436,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 437,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 438,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 439,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 440,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 441,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 442,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 443,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 444,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 445,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 446,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 447,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 448,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 449,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 450,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 451,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 452,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 453,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 454,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 455,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 456,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 493,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 494,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 495,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 496,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 497,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 498,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 499,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 500,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 501,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 502,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 503,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 504,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 505,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 506,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 507,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 508,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 509,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 510,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 511,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 512,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 513,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 514,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 515,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 516,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 517,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 518,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 519,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 520,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 521,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 522,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 523,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 524,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 525,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 526,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 527,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 528,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 529,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 530,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 531,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 532,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 533,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 534,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 535,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 536,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 537,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 538,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 539,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 540,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 541,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 542,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 543,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 544,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 545,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 546,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 547,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 548,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 549,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 550,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 551,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 552,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 553,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 554,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 555,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 556,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 557,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 558,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 559,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 560,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 561,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 562,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 563,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 564,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 565,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 566,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 567,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 568,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 569,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 570,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 571,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 572,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 573,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 574,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 575,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 576,
                column: "SeatTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "+/YDWDSauYXNgyaRABsWVFBWcrWOwEn2f688aAXOsDs=", "jbuUyOhshnv7a8xu7wZZQw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "BhDjzFcIQNCoL2rZqgp+aqvbBf+7NdiS4Kdv+uOL+ig=", "U279683O31neJSZx1KSBQQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "BhDjzFcIQNCoL2rZqgp+aqvbBf+7NdiS4Kdv+uOL+ig=", "U279683O31neJSZx1KSBQQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 17, 21, 57, 50, 623, DateTimeKind.Local).AddTicks(8845),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 25, 22, 49, 24, 706, DateTimeKind.Local).AddTicks(333));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "MovieImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 17, 21, 57, 50, 624, DateTimeKind.Local).AddTicks(7564),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 25, 22, 49, 24, 707, DateTimeKind.Local).AddTicks(1903));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 17, 21, 57, 50, 625, DateTimeKind.Local).AddTicks(1545),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 25, 22, 49, 24, 707, DateTimeKind.Local).AddTicks(6684));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "CommentLikes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 17, 21, 57, 50, 625, DateTimeKind.Local).AddTicks(4884),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 25, 22, 49, 24, 708, DateTimeKind.Local).AddTicks(500));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumns: new[] { "CommentId", "UserId" },
                keyValues: new object[] { 1, 2 },
                column: "CreatedAt",
                value: new DateTime(2024, 8, 17, 21, 57, 50, 625, DateTimeKind.Local).AddTicks(4884));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumns: new[] { "CommentId", "UserId" },
                keyValues: new object[] { 1, 3 },
                column: "CreatedAt",
                value: new DateTime(2024, 8, 17, 21, 57, 50, 625, DateTimeKind.Local).AddTicks(4884));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 21, 57, 50, 632, DateTimeKind.Local).AddTicks(5426));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 21, 57, 50, 632, DateTimeKind.Local).AddTicks(5428));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 21, 57, 50, 632, DateTimeKind.Local).AddTicks(5430));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfPurchase",
                value: new DateTime(2024, 8, 17, 21, 57, 50, 632, DateTimeKind.Local).AddTicks(6786));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfPurchase",
                value: new DateTime(2024, 8, 17, 21, 57, 50, 632, DateTimeKind.Local).AddTicks(6792));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateOfPurchase",
                value: new DateTime(2024, 8, 17, 21, 57, 50, 632, DateTimeKind.Local).AddTicks(6795));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 8, 17, 21, 57, 50, 624, DateTimeKind.Local).AddTicks(7564));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 8, 17, 21, 57, 50, 624, DateTimeKind.Local).AddTicks(7564));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 8, 17, 21, 57, 50, 624, DateTimeKind.Local).AddTicks(7564));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 8, 17, 21, 57, 50, 624, DateTimeKind.Local).AddTicks(7564));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 8, 17, 21, 57, 50, 624, DateTimeKind.Local).AddTicks(7564));

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
                table: "Seats",
                keyColumn: "Id",
                keyValue: 4,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 5,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 6,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 7,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 8,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 9,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 10,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 11,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 12,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 13,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 14,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 15,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 16,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 17,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 18,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 19,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 20,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 21,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 22,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 23,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 24,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 61,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 62,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 63,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 64,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 65,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 66,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 67,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 68,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 69,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 70,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 71,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 72,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 73,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 74,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 75,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 76,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 77,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 78,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 79,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 80,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 81,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 82,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 83,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 84,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 85,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 86,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 87,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 88,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 89,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 90,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 91,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 92,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 93,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 94,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 95,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 96,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 97,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 98,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 99,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 100,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 101,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 102,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 103,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 104,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 105,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 106,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 107,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 108,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 109,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 110,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 111,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 112,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 113,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 114,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 115,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 116,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 117,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 118,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 119,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 120,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 121,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 122,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 123,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 124,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 125,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 126,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 127,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 128,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 129,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 130,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 131,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 132,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 133,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 134,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 135,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 136,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 137,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 138,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 139,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 140,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 141,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 142,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 143,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 144,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 145,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 146,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 147,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 148,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 149,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 150,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 151,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 152,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 153,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 154,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 155,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 156,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 157,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 158,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 159,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 160,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 161,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 162,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 163,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 164,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 165,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 166,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 167,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 168,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 205,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 206,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 207,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 208,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 209,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 210,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 211,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 212,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 213,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 214,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 215,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 216,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 217,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 218,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 219,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 220,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 221,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 222,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 223,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 224,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 225,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 226,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 227,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 228,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 229,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 230,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 231,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 232,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 233,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 234,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 235,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 236,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 237,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 238,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 239,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 240,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 241,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 242,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 243,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 244,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 245,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 246,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 247,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 248,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 249,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 250,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 251,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 252,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 253,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 254,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 255,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 256,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 257,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 258,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 259,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 260,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 261,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 262,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 263,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 264,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 265,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 266,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 267,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 268,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 269,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 270,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 271,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 272,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 273,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 274,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 275,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 276,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 277,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 278,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 279,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 280,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 281,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 282,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 283,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 284,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 285,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 286,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 287,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 288,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 289,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 290,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 291,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 292,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 293,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 294,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 295,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 296,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 297,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 298,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 299,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 300,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 301,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 302,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 303,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 304,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 305,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 306,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 307,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 308,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 309,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 310,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 311,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 312,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 349,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 350,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 351,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 352,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 353,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 354,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 355,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 356,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 357,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 358,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 359,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 360,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 361,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 362,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 363,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 364,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 365,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 366,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 367,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 368,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 369,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 370,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 371,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 372,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 373,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 374,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 375,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 376,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 377,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 378,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 379,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 380,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 381,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 382,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 383,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 384,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 385,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 386,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 387,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 388,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 389,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 390,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 391,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 392,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 393,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 394,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 395,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 396,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 397,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 398,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 399,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 400,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 401,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 402,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 403,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 404,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 405,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 406,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 407,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 408,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 409,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 410,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 411,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 412,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 413,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 414,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 415,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 416,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 417,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 418,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 419,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 420,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 421,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 422,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 423,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 424,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 425,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 426,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 427,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 428,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 429,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 430,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 431,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 432,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 433,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 434,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 435,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 436,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 437,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 438,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 439,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 440,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 441,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 442,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 443,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 444,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 445,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 446,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 447,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 448,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 449,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 450,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 451,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 452,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 453,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 454,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 455,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 456,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 493,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 494,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 495,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 496,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 497,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 498,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 499,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 500,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 501,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 502,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 503,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 504,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 505,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 506,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 507,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 508,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 509,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 510,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 511,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 512,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 513,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 514,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 515,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 516,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 517,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 518,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 519,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 520,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 521,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 522,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 523,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 524,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 525,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 526,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 527,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 528,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 529,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 530,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 531,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 532,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 533,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 534,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 535,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 536,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 537,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 538,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 539,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 540,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 541,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 542,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 543,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 544,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 545,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 546,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 547,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 548,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 549,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 550,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 551,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 552,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 553,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 554,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 555,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 556,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 557,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 558,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 559,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 560,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 561,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 562,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 563,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 564,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 565,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 566,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 567,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 568,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 569,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 570,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 571,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 572,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 573,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 574,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 575,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 576,
                column: "SeatTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "k/lxZHN3cnIDuK4Pfz84bY+Vs5wgBVwMG/el+dsKLsM=", "EabPBwHz/plf/aP697Q5Ag==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "xt7VegKi7je7Vbz+UkdyCSRh520jcBue/ev3yrJvpgo=", "nR3xHxxUN9fWV64mC3YCYQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "xt7VegKi7je7Vbz+UkdyCSRh520jcBue/ev3yrJvpgo=", "nR3xHxxUN9fWV64mC3YCYQ==" });
        }
    }
}
