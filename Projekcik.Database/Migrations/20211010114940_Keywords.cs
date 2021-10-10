using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekcik.Database.Migrations
{
    public partial class Keywords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KeywordId",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Keywords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    CandidateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keywords", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Keywords_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_KeywordId",
                table: "Jobs",
                column: "KeywordId");

            migrationBuilder.CreateIndex(
                name: "IX_Keywords_CandidateId",
                table: "Keywords",
                column: "CandidateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Keywords_KeywordId",
                table: "Jobs",
                column: "KeywordId",
                principalTable: "Keywords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Keywords_KeywordId",
                table: "Jobs");

            migrationBuilder.DropTable(
                name: "Keywords");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_KeywordId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "KeywordId",
                table: "Jobs");
        }
    }
}
