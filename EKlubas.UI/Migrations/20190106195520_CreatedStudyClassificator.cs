using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EKlubas.UI.Migrations
{
    public partial class CreatedStudyClassificator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudyId",
                table: "StudyTopics",
                nullable: false,
                defaultValueSql: "1");

            migrationBuilder.CreateTable(
                name: "Studies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Studies",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "-Nepriskirta-" });

            migrationBuilder.InsertData(
                table: "Studies",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Matematika" });

            migrationBuilder.CreateIndex(
                name: "IX_StudyTopics_StudyId",
                table: "StudyTopics",
                column: "StudyId");

            migrationBuilder.CreateIndex(
                name: "IX_Studies_Name",
                table: "Studies",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_StudyTopics_Studies_StudyId",
                table: "StudyTopics",
                column: "StudyId",
                principalTable: "Studies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudyTopics_Studies_StudyId",
                table: "StudyTopics");

            migrationBuilder.DropTable(
                name: "Studies");

            migrationBuilder.DropIndex(
                name: "IX_StudyTopics_StudyId",
                table: "StudyTopics");

            migrationBuilder.DropColumn(
                name: "StudyId",
                table: "StudyTopics");
        }
    }
}
