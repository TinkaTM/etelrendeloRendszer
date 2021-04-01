using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodApp.Data.Migrations
{
    public partial class cartitem1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KocsiItem",
                columns: table => new
                {
                    KocsiItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EtelID = table.Column<int>(nullable: true),
                    Darab = table.Column<int>(nullable: false),
                    KocsiId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KocsiItem", x => x.KocsiItemId);
                    table.ForeignKey(
                        name: "FK_KocsiItem_Etlap_EtelID",
                        column: x => x.EtelID,
                        principalTable: "Etlap",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KocsiItem_EtelID",
                table: "KocsiItem",
                column: "EtelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KocsiItem");
        }
    }
}
