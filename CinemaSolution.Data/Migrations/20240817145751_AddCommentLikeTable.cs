using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaSolution.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCommentLikeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 17, 21, 57, 50, 623, DateTimeKind.Local).AddTicks(8845),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 14, 16, 4, 42, 11, DateTimeKind.Local).AddTicks(1217));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "MovieImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 17, 21, 57, 50, 624, DateTimeKind.Local).AddTicks(7564),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 14, 16, 4, 42, 12, DateTimeKind.Local).AddTicks(1480));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 17, 21, 57, 50, 625, DateTimeKind.Local).AddTicks(1545),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 14, 16, 4, 42, 12, DateTimeKind.Local).AddTicks(6283));

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CommentLikes",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 8, 17, 21, 57, 50, 625, DateTimeKind.Local).AddTicks(4884))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentLikes", x => new { x.CommentId, x.UserId });
                    table.ForeignKey(
                        name: "FK_CommentLikes_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommentLikes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CommentLikes",
                columns: new[] { "CommentId", "UserId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 3 }
                });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ParentId" },
                values: new object[] { new DateTime(2024, 8, 17, 21, 57, 50, 632, DateTimeKind.Local).AddTicks(5426), null });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ParentId" },
                values: new object[] { new DateTime(2024, 8, 17, 21, 57, 50, 632, DateTimeKind.Local).AddTicks(5428), null });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedDate", "MovieId", "ParentId", "UserId" },
                values: new object[] { 3, "This is a reply comment", new DateTime(2024, 8, 17, 21, 57, 50, 632, DateTimeKind.Local).AddTicks(5430), 1, 2, 2 });

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
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rating",
                value: 9.5);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                column: "Rating",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumns: new[] { "MovieId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "Value",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumns: new[] { "MovieId", "UserId" },
                keyValues: new object[] { 2, 3 },
                column: "Value",
                value: 10);

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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentId",
                table: "Comments",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentLikes_UserId",
                table: "CommentLikes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_ParentId",
                table: "Comments",
                column: "ParentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_ParentId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "CommentLikes");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ParentId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Comments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 14, 16, 4, 42, 11, DateTimeKind.Local).AddTicks(1217),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 17, 21, 57, 50, 623, DateTimeKind.Local).AddTicks(8845));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "MovieImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 14, 16, 4, 42, 12, DateTimeKind.Local).AddTicks(1480),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 17, 21, 57, 50, 624, DateTimeKind.Local).AddTicks(7564));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 14, 16, 4, 42, 12, DateTimeKind.Local).AddTicks(6283),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 17, 21, 57, 50, 625, DateTimeKind.Local).AddTicks(1545));

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
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rating",
                value: 9.8000000000000007);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                column: "Rating",
                value: 9.5);

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumns: new[] { "MovieId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "Value",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumns: new[] { "MovieId", "UserId" },
                keyValues: new object[] { 2, 3 },
                column: "Value",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "+PI8rioQBYVS/070vZzK+ylNx0DF2UXRyEpkN8iDR6w=", "cstr0Jd+PjKFLYGXFlupsg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "DMzYM961tH1X8Qtpkd0uPH/aHJeDGcWafUQ5AoXuId0=", "2XmrsQGDhiI/bs6irNJ8lA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "DMzYM961tH1X8Qtpkd0uPH/aHJeDGcWafUQ5AoXuId0=", "2XmrsQGDhiI/bs6irNJ8lA==" });
        }
    }
}
