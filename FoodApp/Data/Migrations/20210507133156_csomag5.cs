using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodApp.Data.Migrations
{
    public partial class csomag5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RendelesDetail_Csomags_CsomagID",
                table: "RendelesDetail");

            migrationBuilder.DropTable(
                name: "Csomags");

            migrationBuilder.DropIndex(
                name: "IX_RendelesDetail_CsomagID",
                table: "RendelesDetail");

            migrationBuilder.DropColumn(
                name: "CsomagID",
                table: "RendelesDetail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CsomagID",
                table: "RendelesDetail",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Csomags",
                columns: table => new
                {
                    CsomagID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EtteremID = table.Column<int>(type: "int", nullable: false),
                    FutarId = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    RendelesID = table.Column<int>(type: "int", nullable: false),
                    RendelesStatID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Csomags", x => x.CsomagID);
                    table.ForeignKey(
                        name: "FK_Csomags_EtteremCim_EtteremID",
                        column: x => x.EtteremID,
                        principalTable: "EtteremCim",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Csomags_FutarAdat_FutarId",
                        column: x => x.FutarId,
                        principalTable: "FutarAdat",
                        principalColumn: "FutarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Csomags_Rendeles_RendelesID",
                        column: x => x.RendelesID,
                        principalTable: "Rendeles",
                        principalColumn: "RendelesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Csomags_rendelesStatuse_RendelesStatID",
                        column: x => x.RendelesStatID,
                        principalTable: "rendelesStatuse",
                        principalColumn: "RendelesStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RendelesDetail_CsomagID",
                table: "RendelesDetail",
                column: "CsomagID");

            migrationBuilder.CreateIndex(
                name: "IX_Csomags_EtteremID",
                table: "Csomags",
                column: "EtteremID");

            migrationBuilder.CreateIndex(
                name: "IX_Csomags_FutarId",
                table: "Csomags",
                column: "FutarId");

            migrationBuilder.CreateIndex(
                name: "IX_Csomags_RendelesID",
                table: "Csomags",
                column: "RendelesID");

            migrationBuilder.CreateIndex(
                name: "IX_Csomags_RendelesStatID",
                table: "Csomags",
                column: "RendelesStatID");

            migrationBuilder.AddForeignKey(
                name: "FK_RendelesDetail_Csomags_CsomagID",
                table: "RendelesDetail",
                column: "CsomagID",
                principalTable: "Csomags",
                principalColumn: "CsomagID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
