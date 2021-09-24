using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekcik.Database.Migrations
{
    public partial class JobCandidate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Candidates",
                type: "nvarchar(2137)",
                maxLength: 2137,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 1024,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_JobId",
                table: "Candidates",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Jobs_JobId",
                table: "Candidates",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Jobs_JobId",
                table: "Candidates");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_JobId",
                table: "Candidates");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Candidates",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2137)",
                oldMaxLength: 2137,
                oldNullable: true);
        }
    }
}
