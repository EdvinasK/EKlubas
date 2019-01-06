using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EKlubas.UI.Migrations
{
    public partial class AnswersAndTopicsCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudyExamAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Answer = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'1900-01-01T00:00:00.000'"),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'1900-01-01T00:00:00.000'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyExamAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyExamAnswers_EKlubasUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "EKlubasUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudyTopics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Topic = table.Column<string>(nullable: true),
                    DifficultyLevel = table.Column<int>(nullable: false),
                    DurationInMinutes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyTopics", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudyExamAnswers_UserId",
                table: "StudyExamAnswers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyTopics_Topic",
                table: "StudyTopics",
                column: "Topic");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudyExamAnswers");

            migrationBuilder.DropTable(
                name: "StudyTopics");
        }
    }
}
