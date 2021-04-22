using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodApp.Data.Migrations
{
    public partial class rendelesallapot4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rendelesStatuse_Etlap_EtlapId",
                table: "rendelesStatuse");

            migrationBuilder.DropIndex(
                name: "IX_rendelesStatuse_EtlapId",
                table: "rendelesStatuse");

            migrationBuilder.DropColumn(
                name: "EtlapId",
                table: "rendelesStatuse");

            migrationBuilder.AddColumn<int>(
                name: "EtteremId",
                table: "rendelesStatuse",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_rendelesStatuse_EtteremId",
                table: "rendelesStatuse",
                column: "EtteremId");

            migrationBuilder.AddForeignKey(
                name: "FK_rendelesStatuse_EtteremCim_EtteremId",
                table: "rendelesStatuse",
                column: "EtteremId",
                principalTable: "EtteremCim",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rendelesStatuse_EtteremCim_EtteremId",
                table: "rendelesStatuse");

            migrationBuilder.DropIndex(
                name: "IX_rendelesStatuse_EtteremId",
                table: "rendelesStatuse");

            migrationBuilder.DropColumn(
                name: "EtteremId",
                table: "rendelesStatuse");

            migrationBuilder.AddColumn<int>(
                name: "EtlapId",
                table: "rendelesStatuse",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_rendelesStatuse_EtlapId",
                table: "rendelesStatuse",
                column: "EtlapId");

            migrationBuilder.AddForeignKey(
                name: "FK_rendelesStatuse_Etlap_EtlapId",
                table: "rendelesStatuse",
                column: "EtlapId",
                principalTable: "Etlap",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
