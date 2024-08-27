using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaSolution.Data.Migrations
{
    /// <inheritdoc />
    public partial class NullableTicketIdAndOrderIdInInvoiceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Orders_OrderId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Tickets_TicketId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_OrderId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_TicketId",
                table: "Invoices");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 27, 10, 46, 44, 733, DateTimeKind.Local).AddTicks(9787),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 25, 22, 49, 24, 706, DateTimeKind.Local).AddTicks(333));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "MovieImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 27, 10, 46, 44, 735, DateTimeKind.Local).AddTicks(3015),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 25, 22, 49, 24, 707, DateTimeKind.Local).AddTicks(1903));

            migrationBuilder.AlterColumn<int>(
                name: "TicketId",
                table: "Invoices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Invoices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 27, 10, 46, 44, 735, DateTimeKind.Local).AddTicks(7170),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 25, 22, 49, 24, 707, DateTimeKind.Local).AddTicks(6684));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "CommentLikes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 27, 10, 46, 44, 736, DateTimeKind.Local).AddTicks(902),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 25, 22, 49, 24, 708, DateTimeKind.Local).AddTicks(500));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumns: new[] { "CommentId", "UserId" },
                keyValues: new object[] { 1, 2 },
                column: "CreatedAt",
                value: new DateTime(2024, 8, 27, 10, 46, 44, 736, DateTimeKind.Local).AddTicks(902));

            migrationBuilder.UpdateData(
                table: "CommentLikes",
                keyColumns: new[] { "CommentId", "UserId" },
                keyValues: new object[] { 1, 3 },
                column: "CreatedAt",
                value: new DateTime(2024, 8, 27, 10, 46, 44, 736, DateTimeKind.Local).AddTicks(902));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 10, 46, 44, 742, DateTimeKind.Local).AddTicks(6547));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 10, 46, 44, 742, DateTimeKind.Local).AddTicks(6550));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 10, 46, 44, 742, DateTimeKind.Local).AddTicks(6551));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfPurchase", "UserId" },
                values: new object[] { new DateTime(2024, 8, 27, 10, 46, 44, 742, DateTimeKind.Local).AddTicks(7677), 2 });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfPurchase", "UserId" },
                values: new object[] { new DateTime(2024, 8, 28, 10, 46, 44, 742, DateTimeKind.Local).AddTicks(7679), 2 });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateOfPurchase", "UserId" },
                values: new object[] { new DateTime(2024, 8, 27, 10, 46, 44, 742, DateTimeKind.Local).AddTicks(7700), 3 });

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 8, 27, 10, 46, 44, 735, DateTimeKind.Local).AddTicks(3015));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 8, 27, 10, 46, 44, 735, DateTimeKind.Local).AddTicks(3015));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 8, 27, 10, 46, 44, 735, DateTimeKind.Local).AddTicks(3015));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 8, 27, 10, 46, 44, 735, DateTimeKind.Local).AddTicks(3015));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 8, 27, 10, 46, 44, 735, DateTimeKind.Local).AddTicks(3015));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "p4MII8Kb8OKncUIk6g6yjfrbzv8+vF3XjI+/Fj0U+jg=", "4PU7R9+jBoUjtXv6KAEt6g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "139kuQDdDRtTjXdkiB6wRQBKKTMjQb0UFLmFKkO6EFY=", "FCesL4dUX5BK+6grJLsgFA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "139kuQDdDRtTjXdkiB6wRQBKKTMjQb0UFLmFKkO6EFY=", "FCesL4dUX5BK+6grJLsgFA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_OrderId",
                table: "Invoices",
                column: "OrderId",
                unique: true,
                filter: "[OrderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_TicketId",
                table: "Invoices",
                column: "TicketId",
                unique: true,
                filter: "[TicketId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Orders_OrderId",
                table: "Invoices",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Tickets_TicketId",
                table: "Invoices",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Orders_OrderId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Tickets_TicketId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_OrderId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_TicketId",
                table: "Invoices");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 25, 22, 49, 24, 706, DateTimeKind.Local).AddTicks(333),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 27, 10, 46, 44, 733, DateTimeKind.Local).AddTicks(9787));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "MovieImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 25, 22, 49, 24, 707, DateTimeKind.Local).AddTicks(1903),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 27, 10, 46, 44, 735, DateTimeKind.Local).AddTicks(3015));

            migrationBuilder.AlterColumn<int>(
                name: "TicketId",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 25, 22, 49, 24, 707, DateTimeKind.Local).AddTicks(6684),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 27, 10, 46, 44, 735, DateTimeKind.Local).AddTicks(7170));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "CommentLikes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 25, 22, 49, 24, 708, DateTimeKind.Local).AddTicks(500),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 27, 10, 46, 44, 736, DateTimeKind.Local).AddTicks(902));

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
                columns: new[] { "DateOfPurchase", "UserId" },
                values: new object[] { new DateTime(2024, 8, 25, 22, 49, 24, 715, DateTimeKind.Local).AddTicks(6299), 1 });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfPurchase", "UserId" },
                values: new object[] { new DateTime(2024, 8, 25, 22, 49, 24, 715, DateTimeKind.Local).AddTicks(6302), 1 });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateOfPurchase", "UserId" },
                values: new object[] { new DateTime(2024, 8, 25, 22, 49, 24, 715, DateTimeKind.Local).AddTicks(6304), 1 });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Orders_OrderId",
                table: "Invoices",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Tickets_TicketId",
                table: "Invoices",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
