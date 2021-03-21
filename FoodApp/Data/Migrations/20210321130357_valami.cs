using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodApp.Data.Migrations
{
    public partial class valami : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Etlap",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Etlap_UserId",
                table: "Etlap",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Etlap_AspNetUsers_UserId",
                table: "Etlap",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Etlap_AspNetUsers_UserId",
                table: "Etlap");

            migrationBuilder.DropIndex(
                name: "IX_Etlap_UserId",
                table: "Etlap");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Etlap",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Etlap",
                type: "nvarchar(450)",
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
    }
}
