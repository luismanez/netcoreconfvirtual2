using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Delos.Westworld.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CurrentParkId = table.Column<Guid>(nullable: false),
                    Biography = table.Column<string>(nullable: true),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    LastSystemReview = table.Column<DateTime>(nullable: false),
                    CurrentParkAssignedId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hosts_Parks_CurrentParkAssignedId",
                        column: x => x.CurrentParkAssignedId,
                        principalTable: "Parks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hosts_Parks_CurrentParkId",
                        column: x => x.CurrentParkId,
                        principalTable: "Parks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hosts_CurrentParkAssignedId",
                table: "Hosts",
                column: "CurrentParkAssignedId");

            migrationBuilder.CreateIndex(
                name: "IX_Hosts_CurrentParkId",
                table: "Hosts",
                column: "CurrentParkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hosts");

            migrationBuilder.DropTable(
                name: "Parks");
        }
    }
}
