using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodApp.Data.Migrations
{
    public partial class vendegcim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VendegCim",
                columns: table => new
                {
                    VendegCimId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VezetekNev = table.Column<string>(nullable: true),
                    KeresztNev = table.Column<string>(nullable: true),
                    Varos = table.Column<string>(nullable: true),
                    Iranyitoszam = table.Column<int>(nullable: false),
                    Cim = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefonszam = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendegCim", x => x.VendegCimId);
                    table.ForeignKey(
                        name: "FK_VendegCim_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VendegCim_UserId",
                table: "VendegCim",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VendegCim");
        }
    }
}
