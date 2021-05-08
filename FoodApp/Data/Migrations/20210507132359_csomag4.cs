using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodApp.Data.Migrations
{
    public partial class csomag4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Csomags_AspNetUsers_UserId",
                table: "Csomags");

            migrationBuilder.DropIndex(
                name: "IX_Csomags_UserId",
                table: "Csomags");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Csomags");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Csomags",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Csomags_UserId",
                table: "Csomags",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Csomags_AspNetUsers_UserId",
                table: "Csomags",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
