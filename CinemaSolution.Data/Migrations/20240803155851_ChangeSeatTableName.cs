using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaSolution.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSeatTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_PersonTypes_PersonTypeId",
                table: "Seat");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Screenings_ScreeningId",
                table: "Seat");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_SeatStatuses_SeatStatusId",
                table: "Seat");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_SeatTypes_SeatTypeId",
                table: "Seat");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Tickets_TicketId",
                table: "Seat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seat",
                table: "Seat");

            migrationBuilder.RenameTable(
                name: "Seat",
                newName: "Seats");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_TicketId",
                table: "Seats",
                newName: "IX_Seats_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_SeatTypeId",
                table: "Seats",
                newName: "IX_Seats_SeatTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_SeatStatusId",
                table: "Seats",
                newName: "IX_Seats_SeatStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_ScreeningId",
                table: "Seats",
                newName: "IX_Seats_ScreeningId");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_PersonTypeId",
                table: "Seats",
                newName: "IX_Seats_PersonTypeId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 3, 22, 58, 50, 484, DateTimeKind.Local).AddTicks(7573),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 1, 23, 0, 42, 100, DateTimeKind.Local).AddTicks(2412));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "MovieImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 3, 22, 58, 50, 485, DateTimeKind.Local).AddTicks(7303),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 1, 23, 0, 42, 101, DateTimeKind.Local).AddTicks(953));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 3, 22, 58, 50, 486, DateTimeKind.Local).AddTicks(2260),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 1, 23, 0, 42, 101, DateTimeKind.Local).AddTicks(5039));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seats",
                table: "Seats",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Auditoriums",
                keyColumn: "Id",
                keyValue: 1,
                column: "SeatMapVector",
                value: "111111111111111111111111222222222222222222222222222222222222111111111111111111111111111111111111111111111111111111111111111111111111111111111111");

            migrationBuilder.UpdateData(
                table: "Auditoriums",
                keyColumn: "Id",
                keyValue: 2,
                column: "SeatMapVector",
                value: "111111111111111111111111222222222222222222222222222222222222111111111111111111111111111111111111111111111111111111111111111111111111111111111111");

            migrationBuilder.UpdateData(
                table: "Auditoriums",
                keyColumn: "Id",
                keyValue: 3,
                column: "SeatMapVector",
                value: "111111111111111111111111222222222222222222222222222222222222111111111111111111111111111111111111111111111111111111111111111111111111111111111111");

            migrationBuilder.UpdateData(
                table: "Auditoriums",
                keyColumn: "Id",
                keyValue: 4,
                column: "SeatMapVector",
                value: "111111111111111111111111222222222222222222222222222222222222111111111111111111111111111111111111111111111111111111111111111111111111111111111111");

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
                column: "DateCreated",
                value: new DateTime(2024, 8, 3, 22, 58, 50, 485, DateTimeKind.Local).AddTicks(7303));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 8, 3, 22, 58, 50, 485, DateTimeKind.Local).AddTicks(7303));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 8, 3, 22, 58, 50, 485, DateTimeKind.Local).AddTicks(7303));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 8, 3, 22, 58, 50, 485, DateTimeKind.Local).AddTicks(7303));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_PersonTypes_PersonTypeId",
                table: "Seats",
                column: "PersonTypeId",
                principalTable: "PersonTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Screenings_ScreeningId",
                table: "Seats",
                column: "ScreeningId",
                principalTable: "Screenings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_SeatStatuses_SeatStatusId",
                table: "Seats",
                column: "SeatStatusId",
                principalTable: "SeatStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_SeatTypes_SeatTypeId",
                table: "Seats",
                column: "SeatTypeId",
                principalTable: "SeatTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Tickets_TicketId",
                table: "Seats",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_PersonTypes_PersonTypeId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Screenings_ScreeningId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_SeatStatuses_SeatStatusId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_SeatTypes_SeatTypeId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Tickets_TicketId",
                table: "Seats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seats",
                table: "Seats");

            migrationBuilder.RenameTable(
                name: "Seats",
                newName: "Seat");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_TicketId",
                table: "Seat",
                newName: "IX_Seat_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_SeatTypeId",
                table: "Seat",
                newName: "IX_Seat_SeatTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_SeatStatusId",
                table: "Seat",
                newName: "IX_Seat_SeatStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_ScreeningId",
                table: "Seat",
                newName: "IX_Seat_ScreeningId");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_PersonTypeId",
                table: "Seat",
                newName: "IX_Seat_PersonTypeId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 1, 23, 0, 42, 100, DateTimeKind.Local).AddTicks(2412),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 3, 22, 58, 50, 484, DateTimeKind.Local).AddTicks(7573));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "MovieImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 1, 23, 0, 42, 101, DateTimeKind.Local).AddTicks(953),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 3, 22, 58, 50, 485, DateTimeKind.Local).AddTicks(7303));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 1, 23, 0, 42, 101, DateTimeKind.Local).AddTicks(5039),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 3, 22, 58, 50, 486, DateTimeKind.Local).AddTicks(2260));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seat",
                table: "Seat",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_PersonTypes_PersonTypeId",
                table: "Seat",
                column: "PersonTypeId",
                principalTable: "PersonTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Screenings_ScreeningId",
                table: "Seat",
                column: "ScreeningId",
                principalTable: "Screenings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_SeatStatuses_SeatStatusId",
                table: "Seat",
                column: "SeatStatusId",
                principalTable: "SeatStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_SeatTypes_SeatTypeId",
                table: "Seat",
                column: "SeatTypeId",
                principalTable: "SeatTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Tickets_TicketId",
                table: "Seat",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id");
        }
    }
}
