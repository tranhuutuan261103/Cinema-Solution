using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaSolution.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAvatarAndBackgroundImageForUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvatarUrl",
                table: "Users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BackgroundUrl",
                table: "Users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 14, 16, 4, 42, 11, DateTimeKind.Local).AddTicks(1217),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 5, 22, 11, 15, 837, DateTimeKind.Local).AddTicks(6081));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "MovieImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 14, 16, 4, 42, 12, DateTimeKind.Local).AddTicks(1480),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 5, 22, 11, 15, 838, DateTimeKind.Local).AddTicks(5589));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 14, 16, 4, 42, 12, DateTimeKind.Local).AddTicks(6283),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 5, 22, 11, 15, 838, DateTimeKind.Local).AddTicks(9851));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 14, 16, 4, 42, 19, DateTimeKind.Local).AddTicks(8236));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 14, 16, 4, 42, 19, DateTimeKind.Local).AddTicks(8237));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfPurchase",
                value: new DateTime(2024, 8, 14, 16, 4, 42, 19, DateTimeKind.Local).AddTicks(8933));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfPurchase",
                value: new DateTime(2024, 8, 14, 16, 4, 42, 19, DateTimeKind.Local).AddTicks(8935));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateOfPurchase",
                value: new DateTime(2024, 8, 14, 16, 4, 42, 19, DateTimeKind.Local).AddTicks(8937));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 8, 14, 16, 4, 42, 12, DateTimeKind.Local).AddTicks(1480));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 8, 14, 16, 4, 42, 12, DateTimeKind.Local).AddTicks(1480));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 8, 14, 16, 4, 42, 12, DateTimeKind.Local).AddTicks(1480));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 8, 14, 16, 4, 42, 12, DateTimeKind.Local).AddTicks(1480));

            migrationBuilder.UpdateData(
                table: "MovieImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 8, 14, 16, 4, 42, 12, DateTimeKind.Local).AddTicks(1480));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Customer", "Customer" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvatarUrl", "BackgroundUrl", "PasswordHash", "PasswordSalt" },
                values: new object[] { null, null, "+PI8rioQBYVS/070vZzK+ylNx0DF2UXRyEpkN8iDR6w=", "cstr0Jd+PjKFLYGXFlupsg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvatarUrl", "BackgroundUrl", "PasswordHash", "PasswordSalt" },
                values: new object[] { null, null, "DMzYM961tH1X8Qtpkd0uPH/aHJeDGcWafUQ5AoXuId0=", "2XmrsQGDhiI/bs6irNJ8lA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvatarUrl", "BackgroundUrl", "PasswordHash", "PasswordSalt" },
                values: new object[] { null, null, "DMzYM961tH1X8Qtpkd0uPH/aHJeDGcWafUQ5AoXuId0=", "2XmrsQGDhiI/bs6irNJ8lA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarUrl",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BackgroundUrl",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 5, 22, 11, 15, 837, DateTimeKind.Local).AddTicks(6081),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 14, 16, 4, 42, 11, DateTimeKind.Local).AddTicks(1217));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "MovieImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 5, 22, 11, 15, 838, DateTimeKind.Local).AddTicks(5589),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 14, 16, 4, 42, 12, DateTimeKind.Local).AddTicks(1480));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 5, 22, 11, 15, 838, DateTimeKind.Local).AddTicks(9851),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 14, 16, 4, 42, 12, DateTimeKind.Local).AddTicks(6283));

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
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "User", "User" });

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
        }
    }
}
