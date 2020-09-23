using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Delos.Westworld.Infrastructure.Migrations
{
    public partial class InitialCreateFixDuplicatedProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hosts_Parks_CurrentParkAssignedId",
                table: "Hosts");

            migrationBuilder.DropIndex(
                name: "IX_Hosts_CurrentParkAssignedId",
                table: "Hosts");

            migrationBuilder.DropColumn(
                name: "CurrentParkAssignedId",
                table: "Hosts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CurrentParkAssignedId",
                table: "Hosts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hosts_CurrentParkAssignedId",
                table: "Hosts",
                column: "CurrentParkAssignedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hosts_Parks_CurrentParkAssignedId",
                table: "Hosts",
                column: "CurrentParkAssignedId",
                principalTable: "Parks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
