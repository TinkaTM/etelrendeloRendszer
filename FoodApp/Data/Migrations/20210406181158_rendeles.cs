using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodApp.Data.Migrations
{
    public partial class rendeles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rendeles",
                columns: table => new
                {
                    RendelesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VezetekNev = table.Column<string>(nullable: true),
                    KeresztNev = table.Column<string>(nullable: true),
                    Varos = table.Column<string>(nullable: true),
                    Iranyitoszam = table.Column<int>(nullable: false),
                    Cim = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefonszam = table.Column<string>(nullable: true),
                    RendelesTotal = table.Column<int>(nullable: false),
                    RendelesIdo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rendeles", x => x.RendelesId);
                });

            migrationBuilder.CreateTable(
                name: "RendelesDetail",
                columns: table => new
                {
                    RendelesDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RendelesId = table.Column<int>(nullable: false),
                    EtlapId = table.Column<int>(nullable: false),
                    Darab = table.Column<int>(nullable: false),
                    Ar = table.Column<int>(nullable: false),
                    EtteremCimId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RendelesDetail", x => x.RendelesDetailId);
                    table.ForeignKey(
                        name: "FK_RendelesDetail_Etlap_EtlapId",
                        column: x => x.EtlapId,
                        principalTable: "Etlap",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RendelesDetail_EtteremCim_EtteremCimId",
                        column: x => x.EtteremCimId,
                        principalTable: "EtteremCim",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RendelesDetail_Rendeles_RendelesId",
                        column: x => x.RendelesId,
                        principalTable: "Rendeles",
                        principalColumn: "RendelesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RendelesDetail_EtlapId",
                table: "RendelesDetail",
                column: "EtlapId");

            migrationBuilder.CreateIndex(
                name: "IX_RendelesDetail_EtteremCimId",
                table: "RendelesDetail",
                column: "EtteremCimId");

            migrationBuilder.CreateIndex(
                name: "IX_RendelesDetail_RendelesId",
                table: "RendelesDetail",
                column: "RendelesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RendelesDetail");

            migrationBuilder.DropTable(
                name: "Rendeles");
        }
    }
}
