using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekcik.Database.Migrations
{
    public partial class Keyword_blind_boar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Keywords_Id",
                table: "Keywords");

            migrationBuilder.CreateIndex(
                name: "IX_Keywords_Name",
                table: "Keywords",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Keywords_Name",
                table: "Keywords");

            migrationBuilder.CreateIndex(
                name: "IX_Keywords_Id",
                table: "Keywords",
                column: "Id",
                unique: true);
        }
    }
}
