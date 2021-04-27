using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodApp.Data.Migrations
{
    public partial class futarstat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FutarId",
                table: "rendelesStatuse",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_rendelesStatuse_FutarId",
                table: "rendelesStatuse",
                column: "FutarId");

            migrationBuilder.AddForeignKey(
                name: "FK_rendelesStatuse_FutarAdat_FutarId",
                table: "rendelesStatuse",
                column: "FutarId",
                principalTable: "FutarAdat",
                principalColumn: "FutarId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rendelesStatuse_FutarAdat_FutarId",
                table: "rendelesStatuse");

            migrationBuilder.DropIndex(
                name: "IX_rendelesStatuse_FutarId",
                table: "rendelesStatuse");

            migrationBuilder.DropColumn(
                name: "FutarId",
                table: "rendelesStatuse");
        }
    }
}
