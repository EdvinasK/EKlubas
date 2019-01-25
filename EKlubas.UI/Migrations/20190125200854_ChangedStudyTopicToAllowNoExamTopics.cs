using Microsoft.EntityFrameworkCore.Migrations;

namespace EKlubas.UI.Migrations
{
    public partial class ChangedStudyTopicToAllowNoExamTopics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsTestPrepared",
                table: "StudyTopics",
                newName: "IsExamPrepared");

            migrationBuilder.AddColumn<bool>(
                name: "IsExamOnly",
                table: "StudyTopics",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsExamOnly",
                table: "StudyTopics");

            migrationBuilder.RenameColumn(
                name: "IsExamPrepared",
                table: "StudyTopics",
                newName: "IsTestPrepared");
        }
    }
}
