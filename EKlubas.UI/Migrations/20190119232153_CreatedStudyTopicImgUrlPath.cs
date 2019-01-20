using Microsoft.EntityFrameworkCore.Migrations;

namespace EKlubas.UI.Migrations
{
    public partial class CreatedStudyTopicImgUrlPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgUrlPath",
                table: "StudyTopics",
                maxLength: 128,
                nullable: true,
                defaultValue: "~/images/EquationHouse.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrlPath",
                table: "StudyTopics");
        }
    }
}
