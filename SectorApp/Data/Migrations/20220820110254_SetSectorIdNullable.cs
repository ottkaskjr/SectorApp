using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SectorApp.Data.Migrations
{
    public partial class SetSectorIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SectorUsers_Sectors_SectorId",
                table: "SectorUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "SectorId",
                table: "SectorUsers",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_SectorUsers_Sectors_SectorId",
                table: "SectorUsers",
                column: "SectorId",
                principalTable: "Sectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SectorUsers_Sectors_SectorId",
                table: "SectorUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "SectorId",
                table: "SectorUsers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SectorUsers_Sectors_SectorId",
                table: "SectorUsers",
                column: "SectorId",
                principalTable: "Sectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
