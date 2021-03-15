using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodApp.Data.Migrations
{
    public partial class etlapId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Etlap",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Etlap",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Etlap_ApplicationUserId",
                table: "Etlap",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Etlap_AspNetUsers_ApplicationUserId",
                table: "Etlap",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Etlap_AspNetUsers_ApplicationUserId",
                table: "Etlap");

            migrationBuilder.DropIndex(
                name: "IX_Etlap_ApplicationUserId",
                table: "Etlap");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Etlap");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Etlap");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
