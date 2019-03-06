using Microsoft.EntityFrameworkCore.Migrations;

namespace EKlubas.UI.Migrations
{
    public partial class AddedStudyTopicTaskName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TaskName",
                table: "StudyTopics",
                nullable: false,
                defaultValue: "-");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskName",
                table: "StudyTopics");
        }
    }
}
