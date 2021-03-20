using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodApp.Data.Migrations
{
    public partial class cimcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EtteremCim",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EtteremNev = table.Column<string>(nullable: true),
                    Iranyitoszam = table.Column<int>(nullable: false),
                    Varos = table.Column<string>(nullable: true),
                    Cim = table.Column<string>(nullable: true),
                    Nyitas = table.Column<DateTime>(nullable: false),
                    Zaras = table.Column<DateTime>(nullable: false),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtteremCim", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EtteremCim_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EtteremCim_IdentityUserId",
                table: "EtteremCim",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EtteremCim");
        }
    }
}
