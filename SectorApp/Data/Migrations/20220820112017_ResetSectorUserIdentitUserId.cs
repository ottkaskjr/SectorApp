using Microsoft.EntityFrameworkCore.Migrations;

namespace SectorApp.Data.Migrations
{
    public partial class ResetSectorUserIdentitUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "SectorUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SectorUsers_IdentityUserId",
                table: "SectorUsers",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SectorUsers_AspNetUsers_IdentityUserId",
                table: "SectorUsers",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SectorUsers_AspNetUsers_IdentityUserId",
                table: "SectorUsers");

            migrationBuilder.DropIndex(
                name: "IX_SectorUsers_IdentityUserId",
                table: "SectorUsers");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "SectorUsers");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserName",
                table: "SectorUsers",
                type: "nvarchar(450)",
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
    }
}
