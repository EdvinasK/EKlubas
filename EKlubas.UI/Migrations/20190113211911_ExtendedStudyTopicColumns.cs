using Microsoft.EntityFrameworkCore.Migrations;

namespace EKlubas.UI.Migrations
{
    public partial class ExtendedStudyTopicColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PassMark",
                table: "StudyTopics",
                nullable: false,
                defaultValue: 50);

            migrationBuilder.AddColumn<int>(
                name: "Reward",
                table: "StudyTopics",
                nullable: false,
                defaultValue: 7);

            migrationBuilder.UpdateData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsTestPrepared", "PassMark", "Reward" },
                values: new object[] { true, 50, 7 });

            migrationBuilder.UpdateData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PassMark", "Reward" },
                values: new object[] { 50, 7 });

            migrationBuilder.UpdateData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PassMark", "Reward" },
                values: new object[] { 50, 7 });

            migrationBuilder.UpdateData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PassMark", "Reward" },
                values: new object[] { 50, 7 });

            migrationBuilder.UpdateData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PassMark", "Reward" },
                values: new object[] { 50, 7 });

            migrationBuilder.UpdateData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PassMark", "Reward" },
                values: new object[] { 50, 7 });

            migrationBuilder.UpdateData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "PassMark", "Reward" },
                values: new object[] { 50, 7 });

            migrationBuilder.UpdateData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PassMark", "Reward" },
                values: new object[] { 50, 7 });

            migrationBuilder.UpdateData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PassMark", "Reward" },
                values: new object[] { 50, 7 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassMark",
                table: "StudyTopics");

            migrationBuilder.DropColumn(
                name: "Reward",
                table: "StudyTopics");

            migrationBuilder.UpdateData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsTestPrepared",
                value: false);
        }
    }
}
