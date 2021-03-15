using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodApp.Data.Migrations
{
    public partial class etlapId1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Etlap",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Etlap_IdentityUserId",
                table: "Etlap",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Etlap_AspNetUsers_IdentityUserId",
                table: "Etlap",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Etlap_AspNetUsers_IdentityUserId",
                table: "Etlap");

            migrationBuilder.DropIndex(
                name: "IX_Etlap_IdentityUserId",
                table: "Etlap");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Etlap");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Etlap",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
    }
}
