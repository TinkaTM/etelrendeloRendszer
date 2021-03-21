using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodApp.Data.Migrations
{
    public partial class idteszt1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EtteremCim_AspNetUsers_IdentityUserId",
                table: "EtteremCim");

            migrationBuilder.DropIndex(
                name: "IX_EtteremCim_IdentityUserId",
                table: "EtteremCim");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "EtteremCim");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "EtteremCim",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EtteremCim_UserId",
                table: "EtteremCim",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EtteremCim_AspNetUsers_UserId",
                table: "EtteremCim",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EtteremCim_AspNetUsers_UserId",
                table: "EtteremCim");

            migrationBuilder.DropIndex(
                name: "IX_EtteremCim_UserId",
                table: "EtteremCim");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "EtteremCim");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "EtteremCim",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EtteremCim_IdentityUserId",
                table: "EtteremCim",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EtteremCim_AspNetUsers_IdentityUserId",
                table: "EtteremCim",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
