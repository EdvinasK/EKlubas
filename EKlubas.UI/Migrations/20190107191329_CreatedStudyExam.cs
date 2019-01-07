using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EKlubas.UI.Migrations
{
    public partial class CreatedStudyExam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudyExamAnswers_EKlubasUsers_UserId",
                table: "StudyExamAnswers");

            migrationBuilder.DropIndex(
                name: "IX_StudyExamAnswers_UserId",
                table: "StudyExamAnswers");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "StudyExamAnswers");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "StudyExamAnswers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "StudyExamAnswers");

            migrationBuilder.AddColumn<Guid>(
                name: "StudyExamId",
                table: "StudyExamAnswers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "StudyExams",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    PassMark = table.Column<int>(nullable: false, defaultValueSql: "50"),
                    Reward = table.Column<int>(nullable: false, defaultValueSql: "10"),
                    CreatedTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'1900-01-01T00:00:00.000'"),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'1900-01-01T00:00:00.000'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyExams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyExams_EKlubasUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "EKlubasUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudyExamAnswers_StudyExamId",
                table: "StudyExamAnswers",
                column: "StudyExamId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyExams_UserId",
                table: "StudyExams",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudyExamAnswers_StudyExams_StudyExamId",
                table: "StudyExamAnswers",
                column: "StudyExamId",
                principalTable: "StudyExams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudyExamAnswers_StudyExams_StudyExamId",
                table: "StudyExamAnswers");

            migrationBuilder.DropTable(
                name: "StudyExams");

            migrationBuilder.DropIndex(
                name: "IX_StudyExamAnswers_StudyExamId",
                table: "StudyExamAnswers");

            migrationBuilder.DropColumn(
                name: "StudyExamId",
                table: "StudyExamAnswers");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "StudyExamAnswers",
                type: "datetime",
                nullable: false,
                defaultValueSql: "'1900-01-01T00:00:00.000'");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "StudyExamAnswers",
                type: "datetime",
                nullable: false,
                defaultValueSql: "'1900-01-01T00:00:00.000'");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "StudyExamAnswers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudyExamAnswers_UserId",
                table: "StudyExamAnswers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudyExamAnswers_EKlubasUsers_UserId",
                table: "StudyExamAnswers",
                column: "UserId",
                principalTable: "EKlubasUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
