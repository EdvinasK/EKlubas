using Microsoft.EntityFrameworkCore.Migrations;

namespace EKlubas.UI.Migrations
{
    public partial class ExtendedStudyTopicWithExamDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExamDescription",
                table: "StudyTopics",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExamDescription",
                value: "Lengvas testas sudarytas iš mažų temos uždavinių");

            migrationBuilder.UpdateData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExamDescription",
                value: "Lengvas testas sudarytas iš mažų temos uždavinių");

            migrationBuilder.UpdateData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExamDescription",
                value: "Lengvas testas sudarytas iš mažų temos uždavinių");

            migrationBuilder.UpdateData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExamDescription",
                value: "Lengvas testas sudarytas iš mažų temos uždavinių");

            migrationBuilder.UpdateData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 5,
                column: "ExamDescription",
                value: "Lengvas testas sudarytas iš mažų temos uždavinių");

            migrationBuilder.UpdateData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 6,
                column: "ExamDescription",
                value: "Lengvas testas sudarytas iš mažų temos uždavinių");

            migrationBuilder.UpdateData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 7,
                column: "ExamDescription",
                value: "Lengvas testas sudarytas iš mažų temos uždavinių");

            migrationBuilder.UpdateData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 8,
                column: "ExamDescription",
                value: "Lengvas testas sudarytas iš mažų temos uždavinių");

            migrationBuilder.UpdateData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 9,
                column: "ExamDescription",
                value: "Lengvas testas sudarytas iš mažų temos uždavinių");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExamDescription",
                table: "StudyTopics");
        }
    }
}
