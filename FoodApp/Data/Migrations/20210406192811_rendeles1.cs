using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodApp.Data.Migrations
{
    public partial class rendeles1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ar",
                table: "RendelesDetail");

            migrationBuilder.DropColumn(
                name: "RendelesTotal",
                table: "Rendeles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ar",
                table: "RendelesDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RendelesTotal",
                table: "Rendeles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
