using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Delos.Westworld.Infrastructure.Migrations
{
    public partial class HostPictureFieldAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "Hosts",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Hosts",
                keyColumn: "Id",
                keyValue: new Guid("20f75515-cd6b-4635-88c4-03abe4a4ebf8"),
                column: "PictureUrl",
                value: "https://vignette.wikia.nocookie.net/westworld/images/4/43/Bernard_Lowe_Season_3.jpg/revision/latest?cb=20200307120558");

            migrationBuilder.UpdateData(
                table: "Hosts",
                keyColumn: "Id",
                keyValue: new Guid("2f71f976-db4d-4cc4-8bc5-2726d299ef9e"),
                column: "PictureUrl",
                value: "https://vignette.wikia.nocookie.net/westworld/images/b/b3/Hector_Escaton_infobox_new.jpg/revision/latest?cb=20161024002853");

            migrationBuilder.UpdateData(
                table: "Hosts",
                keyColumn: "Id",
                keyValue: new Guid("53205ba8-c39a-4fc9-ab19-79cfe43a5de9"),
                column: "PictureUrl",
                value: "https://vignette.wikia.nocookie.net/westworld/images/b/bc/Westworld-episode-5_Dolores_infobox.jpg/revision/latest/top-crop/width/200/height/150?cb=20161031210817");

            migrationBuilder.UpdateData(
                table: "Hosts",
                keyColumn: "Id",
                keyValue: new Guid("6868b126-84ff-4d92-9220-fd05a76c140a"),
                column: "PictureUrl",
                value: "https://vignette.wikia.nocookie.net/westworld/images/f/f3/Akane.jpg/revision/latest/scale-to-width-down/620?cb=20180520132523");

            migrationBuilder.UpdateData(
                table: "Hosts",
                keyColumn: "Id",
                keyValue: new Guid("a77d4f82-8045-4b03-9e89-ec595fbfe8c0"),
                column: "PictureUrl",
                value: "https://vignette.wikia.nocookie.net/westworld/images/7/78/Maeves1.jpeg/revision/latest/top-crop/width/200/height/150?cb=20200506155237");

            migrationBuilder.UpdateData(
                table: "Hosts",
                keyColumn: "Id",
                keyValue: new Guid("ba2608b9-23c8-4d71-a51c-6c3c9b07dfc6"),
                column: "PictureUrl",
                value: "https://vignette.wikia.nocookie.net/westworld/images/8/8b/Clementine_Pennyfeather.jpg/revision/latest?cb=20161104230847");

            migrationBuilder.UpdateData(
                table: "Hosts",
                keyColumn: "Id",
                keyValue: new Guid("e734bab8-c0aa-41c7-b01c-a77b3fc20acf"),
                column: "PictureUrl",
                value: "https://vignette.wikia.nocookie.net/westworld/images/6/6b/Musashi_Akane_No_Mai.jpg/revision/latest?cb=20180520131337");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "Hosts");
        }
    }
}
