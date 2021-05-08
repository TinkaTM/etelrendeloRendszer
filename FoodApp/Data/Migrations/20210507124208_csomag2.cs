using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodApp.Data.Migrations
{
    public partial class csomag2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CsomagID",
                table: "RendelesDetail",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EtteremID",
                table: "Csomags",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RendelesDetail_CsomagID",
                table: "RendelesDetail",
                column: "CsomagID");

            migrationBuilder.CreateIndex(
                name: "IX_Csomags_EtteremID",
                table: "Csomags",
                column: "EtteremID");

            migrationBuilder.AddForeignKey(
                name: "FK_Csomags_EtteremCim_EtteremID",
                table: "Csomags",
                column: "EtteremID",
                principalTable: "EtteremCim",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RendelesDetail_Csomags_CsomagID",
                table: "RendelesDetail",
                column: "CsomagID",
                principalTable: "Csomags",
                principalColumn: "CsomagID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Csomags_EtteremCim_EtteremID",
                table: "Csomags");

            migrationBuilder.DropForeignKey(
                name: "FK_RendelesDetail_Csomags_CsomagID",
                table: "RendelesDetail");

            migrationBuilder.DropIndex(
                name: "IX_RendelesDetail_CsomagID",
                table: "RendelesDetail");

            migrationBuilder.DropIndex(
                name: "IX_Csomags_EtteremID",
                table: "Csomags");

            migrationBuilder.DropColumn(
                name: "CsomagID",
                table: "RendelesDetail");

            migrationBuilder.DropColumn(
                name: "EtteremID",
                table: "Csomags");
        }
    }
}
