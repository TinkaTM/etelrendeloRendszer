using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodApp.Data.Migrations
{
    public partial class rendeles2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Rendeles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rendeles_UserId",
                table: "Rendeles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rendeles_AspNetUsers_UserId",
                table: "Rendeles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rendeles_AspNetUsers_UserId",
                table: "Rendeles");

            migrationBuilder.DropIndex(
                name: "IX_Rendeles_UserId",
                table: "Rendeles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Rendeles");
        }
    }
}
