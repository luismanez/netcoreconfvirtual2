using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Delos.Westworld.Infrastructure.Migrations
{
    public partial class InitialDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("306db597-a981-4072-b84a-646747387f5d"), "Experience the first vacation destination where you can live without limits. Westworld is a meticulously crafted and artfully designed park offering an unparalleled, immersive world where you have the freedom to become who you’ve always wanted to be — or who you never knew you were.", "Westworld" },
                    { new Guid("b6daf08d-8f42-42a6-ab95-23c7066bd7cf"), "\"Shōgunworld\" is park two at Delos Destinations, intended for those who find Westworld too tame. Based on the Edo period in Japanese history, Shōgunworld is an artfully-curated vacation destination, where guests can experience the full complexity of nature - beauty and danger, good and evil - in a place nestled from the passage of time.", "Shogunworld " },
                    { new Guid("9ebd3c29-f228-4af0-af1b-2688cc8e387c"), "\"Warworld\" is a simulated world and could possibly be park three at Delos Destinations. This park is based on Italian history during World War II, more specifically when Italy was occupied by Nazi Germany between 1943 and 1945 and made into the Italian Social Republic - popularly and historically known as the Republic of Salò.", "Warworld" },
                    { new Guid("5cda564c-7f41-429d-b151-ca0aa941a99d"), "\"The Raj\" is park six at Delos Destinations and the first park revealed that doesn't use the \"-world\" suffix in its name. The park is named after and inspired by the \"British Raj\", the period between 1858 and 1947 in which the British Crown ruled over the Indian subcontinent.", "The Raj" }
                });

            migrationBuilder.InsertData(
                table: "Hosts",
                columns: new[] { "Id", "Biography", "CurrentParkId", "DateOfCreation", "LastSystemReview", "Name" },
                values: new object[,]
                {
                    { new Guid("53205ba8-c39a-4fc9-ab19-79cfe43a5de9"), "Dolores had a long history of being known as the oldest active host in Westworld[2]. Later, she revealed that she was the first host, and from her, all other hosts are based.[3]", new Guid("306db597-a981-4072-b84a-646747387f5d"), new DateTime(2020, 8, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 9, 11, 0, 0, 0, 0, DateTimeKind.Local), "Dolores Abernathy" },
                    { new Guid("20f75515-cd6b-4635-88c4-03abe4a4ebf8"), "Some years after Arnold died, Bernard was created by Dr. Robert Ford. Ford programmed Bernard to think of himself as a human.", new Guid("306db597-a981-4072-b84a-646747387f5d"), new DateTime(2020, 4, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 9, 4, 0, 0, 0, 0, DateTimeKind.Local), "Bernard Lowe" },
                    { new Guid("ba2608b9-23c8-4d71-a51c-6c3c9b07dfc6"), "Clementine was one of the earliest hosts designed by Robert Ford's and Arnold Weber's startup called the Argos Initiative. She was though preceded by at least Dolores Abernathy.", new Guid("306db597-a981-4072-b84a-646747387f5d"), new DateTime(2020, 8, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 9, 14, 0, 0, 0, 0, DateTimeKind.Local), "Clementine Pennyfeather" },
                    { new Guid("6868b126-84ff-4d92-9220-fd05a76c140a"), "Akane was created by Lee Sizemore as a Shōgunworld's counterpart to Maeve Millay. Sizemore claims he felt justified to do so, as he was under stress to create 300 new narratives in 3 weeks.", new Guid("b6daf08d-8f42-42a6-ab95-23c7066bd7cf"), new DateTime(2020, 9, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Local), "Akane" },
                    { new Guid("e734bab8-c0aa-41c7-b01c-a77b3fc20acf"), "Musashi was created by Lee Sizemore as Shōgunworld's counterpart to Hector Escaton. Sizemore claims he felt justified in copying large parts of Hector's code, as he was under stress to create 300 new narratives in 3 weeks.", new Guid("b6daf08d-8f42-42a6-ab95-23c7066bd7cf"), new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 9, 14, 0, 0, 0, 0, DateTimeKind.Local), "Musashi" },
                    { new Guid("a77d4f82-8045-4b03-9e89-ec595fbfe8c0"), " Maeve Millay is a main character and a host in Westworld. She is a brothel madam in the local Mariposa Saloon. She is one of the first hosts who appears to question her reality, after a series of flashback events - and an apparently chance encounter with Dolores Abernathy in the street outside the Saloon.", new Guid("9ebd3c29-f228-4af0-af1b-2688cc8e387c"), new DateTime(2020, 5, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 9, 3, 0, 0, 0, 0, DateTimeKind.Local), "Maeve Millay" },
                    { new Guid("2f71f976-db4d-4cc4-8bc5-2726d299ef9e"), " Hector Escaton is a host and Westworld's permanent “Most Wanted” bandit. He is a terrifying and brutal criminal, and has a dark sense of humor to match. He subscribes to the theory that the world is a mad place, and the only way to survive is to embrace the role of predator. He is portrayed by Rodrigo Santoro.", new Guid("9ebd3c29-f228-4af0-af1b-2688cc8e387c"), new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 6, 25, 0, 0, 0, 0, DateTimeKind.Local), "Hector Escaton" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hosts",
                keyColumn: "Id",
                keyValue: new Guid("20f75515-cd6b-4635-88c4-03abe4a4ebf8"));

            migrationBuilder.DeleteData(
                table: "Hosts",
                keyColumn: "Id",
                keyValue: new Guid("2f71f976-db4d-4cc4-8bc5-2726d299ef9e"));

            migrationBuilder.DeleteData(
                table: "Hosts",
                keyColumn: "Id",
                keyValue: new Guid("53205ba8-c39a-4fc9-ab19-79cfe43a5de9"));

            migrationBuilder.DeleteData(
                table: "Hosts",
                keyColumn: "Id",
                keyValue: new Guid("6868b126-84ff-4d92-9220-fd05a76c140a"));

            migrationBuilder.DeleteData(
                table: "Hosts",
                keyColumn: "Id",
                keyValue: new Guid("a77d4f82-8045-4b03-9e89-ec595fbfe8c0"));

            migrationBuilder.DeleteData(
                table: "Hosts",
                keyColumn: "Id",
                keyValue: new Guid("ba2608b9-23c8-4d71-a51c-6c3c9b07dfc6"));

            migrationBuilder.DeleteData(
                table: "Hosts",
                keyColumn: "Id",
                keyValue: new Guid("e734bab8-c0aa-41c7-b01c-a77b3fc20acf"));

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "Id",
                keyValue: new Guid("5cda564c-7f41-429d-b151-ca0aa941a99d"));

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "Id",
                keyValue: new Guid("306db597-a981-4072-b84a-646747387f5d"));

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "Id",
                keyValue: new Guid("9ebd3c29-f228-4af0-af1b-2688cc8e387c"));

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "Id",
                keyValue: new Guid("b6daf08d-8f42-42a6-ab95-23c7066bd7cf"));
        }
    }
}
