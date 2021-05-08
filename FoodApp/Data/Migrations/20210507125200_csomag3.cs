using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodApp.Data.Migrations
{
    public partial class csomag3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FutarId",
                table: "Csomags",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Csomags_FutarId",
                table: "Csomags",
                column: "FutarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Csomags_FutarAdat_FutarId",
                table: "Csomags",
                column: "FutarId",
                principalTable: "FutarAdat",
                principalColumn: "FutarId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Csomags_FutarAdat_FutarId",
                table: "Csomags");

            migrationBuilder.DropIndex(
                name: "IX_Csomags_FutarId",
                table: "Csomags");

            migrationBuilder.DropColumn(
                name: "FutarId",
                table: "Csomags");
        }
    }
}
