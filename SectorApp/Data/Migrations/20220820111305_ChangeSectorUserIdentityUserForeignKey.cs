using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SectorApp.Data.Migrations
{
    public partial class ChangeSectorUserIdentityUserForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SectorUsers_AspNetUsers_IdentityUserId1",
                table: "SectorUsers");

            migrationBuilder.DropIndex(
                name: "IX_SectorUsers_IdentityUserId1",
                table: "SectorUsers");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "SectorUsers");

            migrationBuilder.DropColumn(
                name: "IdentityUserId1",
                table: "SectorUsers");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserName",
                table: "SectorUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SectorUsers_IdentityUserName",
                table: "SectorUsers",
                column: "IdentityUserName");

            migrationBuilder.AddForeignKey(
                name: "FK_SectorUsers_AspNetUsers_IdentityUserName",
                table: "SectorUsers",
                column: "IdentityUserName",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SectorUsers_AspNetUsers_IdentityUserName",
                table: "SectorUsers");

            migrationBuilder.DropIndex(
                name: "IX_SectorUsers_IdentityUserName",
                table: "SectorUsers");

            migrationBuilder.DropColumn(
                name: "IdentityUserName",
                table: "SectorUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "IdentityUserId",
                table: "SectorUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId1",
                table: "SectorUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SectorUsers_IdentityUserId1",
                table: "SectorUsers",
                column: "IdentityUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SectorUsers_AspNetUsers_IdentityUserId1",
                table: "SectorUsers",
                column: "IdentityUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
