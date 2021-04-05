using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodApp.Data.Migrations
{
    public partial class id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EtteremCimId",
                table: "KocsiItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_KocsiItem_EtteremCimId",
                table: "KocsiItem",
                column: "EtteremCimId");

            migrationBuilder.AddForeignKey(
                name: "FK_KocsiItem_EtteremCim_EtteremCimId",
                table: "KocsiItem",
                column: "EtteremCimId",
                principalTable: "EtteremCim",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KocsiItem_EtteremCim_EtteremCimId",
                table: "KocsiItem");

            migrationBuilder.DropIndex(
                name: "IX_KocsiItem_EtteremCimId",
                table: "KocsiItem");

            migrationBuilder.DropColumn(
                name: "EtteremCimId",
                table: "KocsiItem");
        }
    }
}
