using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SectorApp.Data.Migrations
{
    public partial class AddParentSectorCodeToSector : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentSectorCode",
                table: "Sectors",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ParentSectorId",
                table: "Sectors",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sectors_ParentSectorId",
                table: "Sectors",
                column: "ParentSectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sectors_Sectors_ParentSectorId",
                table: "Sectors",
                column: "ParentSectorId",
                principalTable: "Sectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sectors_Sectors_ParentSectorId",
                table: "Sectors");

            migrationBuilder.DropIndex(
                name: "IX_Sectors_ParentSectorId",
                table: "Sectors");

            migrationBuilder.DropColumn(
                name: "ParentSectorCode",
                table: "Sectors");

            migrationBuilder.DropColumn(
                name: "ParentSectorId",
                table: "Sectors");
        }
    }
}
