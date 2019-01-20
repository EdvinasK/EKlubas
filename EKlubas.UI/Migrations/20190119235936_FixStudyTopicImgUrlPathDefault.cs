using Microsoft.EntityFrameworkCore.Migrations;

namespace EKlubas.UI.Migrations
{
    public partial class FixStudyTopicImgUrlPathDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImgUrlPath",
                table: "StudyTopics",
                maxLength: 128,
                nullable: true,
                defaultValue: "/images/EquationHouse.png",
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true,
                oldDefaultValue: "~/images/EquationHouse.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImgUrlPath",
                table: "StudyTopics",
                maxLength: 128,
                nullable: true,
                defaultValue: "~/images/EquationHouse.png",
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true,
                oldDefaultValue: "/images/EquationHouse.png");
        }
    }
}
