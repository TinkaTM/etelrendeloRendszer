using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodApp.Data.Migrations
{
    public partial class csomag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Csomags",
                columns: table => new
                {
                    CsomagID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Priority = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    RendelesID = table.Column<int>(nullable: false),
                    RendelesStatID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Csomags", x => x.CsomagID);
                    table.ForeignKey(
                        name: "FK_Csomags_Rendeles_RendelesID",
                        column: x => x.RendelesID,
                        principalTable: "Rendeles",
                        principalColumn: "RendelesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Csomags_rendelesStatuse_RendelesStatID",
                        column: x => x.RendelesStatID,
                        principalTable: "rendelesStatuse",
                        principalColumn: "RendelesStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Csomags_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Csomags_RendelesID",
                table: "Csomags",
                column: "RendelesID");

            migrationBuilder.CreateIndex(
                name: "IX_Csomags_RendelesStatID",
                table: "Csomags",
                column: "RendelesStatID");

            migrationBuilder.CreateIndex(
                name: "IX_Csomags_UserId",
                table: "Csomags",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Csomags");
        }
    }
}
