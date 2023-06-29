using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaWorld.Migrations
{
    public partial class AddColumnsToNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "News");

            migrationBuilder.AlterColumn<string>(
                name: "PhotoUrl",
                table: "News",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "News",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReleaseDate",
                table: "News",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Films",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Genre", "ReleaseDate", "VideoUrl" },
                values: new object[] { "Drama", "November, 2023", "https://www.youtube.com/watch?v=Way9Dexny3w" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Genre", "ReleaseDate", "VideoUrl" },
                values: new object[] { "Adventure", "December, 2023", "https://www.youtube.com/watch?v=5fwVGfbKC9I" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Genre", "ReleaseDate", "VideoUrl" },
                values: new object[] { "Comedy", "November, 2023", "https://www.youtube.com/watch?v=pRH5u5lpArQ" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Genre", "ReleaseDate", "VideoUrl" },
                values: new object[] { "Adventure", "November, 2023", "https://www.youtube.com/watch?v=RDE6Uz73A7g" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "News");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "News");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "News");

            migrationBuilder.AlterColumn<string>(
                name: "PhotoUrl",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2048)",
                oldMaxLength: 2048);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "News",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Films",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2048)",
                oldMaxLength: 2048);

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 6, 24, 16, 57, 23, 879, DateTimeKind.Local).AddTicks(8662));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 6, 24, 16, 57, 23, 879, DateTimeKind.Local).AddTicks(8732));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 6, 24, 16, 57, 23, 879, DateTimeKind.Local).AddTicks(8739));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 6, 24, 16, 57, 23, 879, DateTimeKind.Local).AddTicks(8746));
        }
    }
}
