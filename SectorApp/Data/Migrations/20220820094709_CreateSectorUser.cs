using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SectorApp.Data.Migrations
{
    public partial class CreateSectorUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SectorUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdentityUserId = table.Column<Guid>(nullable: false),
                    SectorId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IdentityUserId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectorUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectorUsers_AspNetUsers_IdentityUserId1",
                        column: x => x.IdentityUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SectorUsers_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SectorUsers_IdentityUserId1",
                table: "SectorUsers",
                column: "IdentityUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_SectorUsers_SectorId",
                table: "SectorUsers",
                column: "SectorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SectorUsers");
        }
    }
}
