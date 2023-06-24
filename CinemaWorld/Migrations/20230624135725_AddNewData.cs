using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaWorld.Migrations
{
    public partial class AddNewData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Country", "Description", "Director", "GenreId", "ImageUrl", "Name", "Rating", "VideoUrl", "Year" },
                values: new object[,]
                {
                    { 6, "United States", "Jake Sully lives with his newfound family formed on the extrasolar moon Pandora. Once a familiar threat returns to finish what was previously started, Jake must work with Neytiri and the army of the Na'vi race to protect their home.", "James Cameron", 1, "https://images.thedirect.com/media/tag_thumbnail/avatar-the-way-of-water_VyIagyn.png", "Avatar: The Way of Water", 7m, "https://www.youtube.com/watch?v=d9MyW72ELq0", "2022" },
                    { 7, "United States", "Barry Allen uses his super speed to change the past, but his attempt to save his family creates a world without super heroes, forcing him to race for his life in order to save the future.", "Andy Muschietti", 1, "https://images.lesindesradios.fr/fit-in/1100x2000/filters:format(webp)/radios/voltage/importrk/news/original/5bd72d70386b79.39893365.jpg", "The Flash", 7m, "https://www.youtube.com/watch?v=hebWYacbdvc", "2023" },
                    { 8, "United States", "A young mermaid makes a deal with a sea witch to trade her beautiful voice for human legs so she can discover the world above water and impress a prince.", "Rob Marshall", 5, "https://staticc.sportskeeda.com/editor/2023/05/564f7-16838889721714-1920.jpg", "The Little Mermaid", 6m, "https://www.youtube.com/watch?v=kpGo2_d3oYE", "2023" },
                    { 9, "United States", "Follows Ember and Wade, in a city where fire-, water-, land- and air-residents live together.", "Peter Sohn", 4, "https://www.hindustantimes.com/ht-img/img/2023/06/15/1600x900/Screenshot_2023-06-15_185111_1686835310989_1686835321066.png", "Elemental", 8m, "https://www.youtube.com/watch?v=hXzcyx9V0xw", "2023" },
                    { 10, "United States", "Follows Ember and Wade, in a city where fire-, water-, land- and air-residents live together.", "Marc Forster", 3, "https://images.hive.blog/p/7b4bio5hobgsatHMcQi2An2xspUC9U8FN8S3zY2E1vASRo1iFqpQAq3pNovHQRTLdqZrNuUDLNzyVCLBqeQ1yW3A2PCWdjsJbN2vcfXkFWqk5TV7At3kyErc74YWka29A1Y7DTVu8QGMC4gfdx8VJKmfvK4A?format=match&mode=fit", "A Man Called Otto", 9m, "https://www.youtube.com/watch?v=eFYUX9l-m5I", "2022" }
                });

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

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Date", "Description", "PhotoUrl", "Title" },
                values: new object[,]
                {
                    { 3, new DateTime(2023, 6, 24, 16, 57, 23, 879, DateTimeKind.Local).AddTicks(8739), "The story of the infamously terrible American Samoa soccer team, known for a brutal 2001 FIFA match they lost 31-0.", "https://syn.org.au/app/uploads/Next-Goal-Wins-Movie-Poster-Large.jpg", "Next Goal Wins" },
                    { 4, new DateTime(2023, 6, 24, 16, 57, 23, 879, DateTimeKind.Local).AddTicks(8746), "Coriolanus Snow mentors and develops feelings for the female District 12 tribute during the 10th Hunger Games.", "https://static.titlovi.com/img/0313/313021-tt10545296.jpg", "The Hunger Games: The Ballad of Songbirds and Snakes" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 6, 22, 10, 25, 41, 852, DateTimeKind.Local).AddTicks(3920));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 6, 22, 10, 25, 41, 852, DateTimeKind.Local).AddTicks(4001));
        }
    }
}
