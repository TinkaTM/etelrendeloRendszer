using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodApp.Data.Migrations
{
    public partial class futaradat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FutarAdat",
                columns: table => new
                {
                    FutarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Keresztnev = table.Column<string>(nullable: true),
                    Vezeteknev = table.Column<string>(nullable: true),
                    Jarmu = table.Column<string>(nullable: true),
                    Telefonszam = table.Column<string>(nullable: true),
                    Varos = table.Column<string>(nullable: true),
                    Kezdes = table.Column<DateTime>(nullable: false),
                    Vegzes = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FutarAdat", x => x.FutarId);
                    table.ForeignKey(
                        name: "FK_FutarAdat_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FutarAdat_UserId",
                table: "FutarAdat",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FutarAdat");
        }
    }
}
