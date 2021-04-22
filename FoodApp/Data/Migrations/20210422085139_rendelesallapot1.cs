using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodApp.Data.Migrations
{
    public partial class rendelesallapot1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "rendelesStatuse",
                columns: table => new
                {
                    RendelesStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RendelesId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CompletionTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rendelesStatuse", x => x.RendelesStatusId);
                    table.ForeignKey(
                        name: "FK_rendelesStatuse_Rendeles_RendelesId",
                        column: x => x.RendelesId,
                        principalTable: "Rendeles",
                        principalColumn: "RendelesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_rendelesStatuse_RendelesId",
                table: "rendelesStatuse",
                column: "RendelesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rendelesStatuse");
        }
    }
}
