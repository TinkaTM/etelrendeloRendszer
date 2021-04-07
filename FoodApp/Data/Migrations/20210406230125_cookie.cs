using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodApp.Data.Migrations
{
    public partial class cookie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserCookie",
                table: "Rendeles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserCookie",
                table: "Rendeles");
        }
    }
}
