using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodApp.Data.Migrations
{
    public partial class rendelesallapot2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "rendelesStatuse");

            migrationBuilder.AddColumn<int>(
                name: "RenStatus",
                table: "rendelesStatuse",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RenStatus",
                table: "rendelesStatuse");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "rendelesStatuse",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
