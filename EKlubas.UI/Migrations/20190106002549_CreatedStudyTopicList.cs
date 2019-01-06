using Microsoft.EntityFrameworkCore.Migrations;

namespace EKlubas.UI.Migrations
{
    public partial class CreatedStudyTopicList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StudyTopics",
                columns: new[] { "Id", "Description", "DifficultyLevel", "DurationInMinutes", "Link", "Name", "Topic" },
                values: new object[,]
                {
                    { 1, "Įvairaus sudėtingumo lygybių uždaviniai be kintamųjų", 1, 5, "Equality", "Lygu, daugiau arba mažiau", "Math" },
                    { 2, "Įvairaus sudėtingumo lygybių uždaviniai be kintamųjų", 2, 10, "Equality", "Lygu, daugiau arba mažiau", "Math" },
                    { 3, "Įvairaus sudėtingumo lygybių uždaviniai be kintamųjų", 3, 15, "Equality", "Lygu, daugiau arba mažiau", "Math" },
                    { 4, "Įvairaus sudėtingumo lygčių uždaviniai su vienu kintamuoju x", 1, 5, "Equation", "Lygtys su vienu kintamuoju", "Math" },
                    { 5, "Įvairaus sudėtingumo lygčių uždaviniai su vienu kintamuoju x", 2, 10, "Equation", "Lygtys su vienu kintamuoju", "Math" },
                    { 6, "Įvairaus sudėtingumo lygčių uždaviniai su vienu kintamuoju x", 3, 15, "Equation", "Lygtys su vienu kintamuoju", "Math" },
                    { 7, "Įvairaus sudėtingumo lygybių uždaviniai su vienu kintamuoju x", 1, 5, "EqualityWithVariable", "Lygybės su vienu kintamuoju", "Math" },
                    { 8, "Įvairaus sudėtingumo lygybių uždaviniai su vienu kintamuoju x", 2, 10, "EqualityWithVariable", "Lygybės su vienu kintamuoju", "Math" },
                    { 9, "Įvairaus sudėtingumo lygybių uždaviniai su vienu kintamuoju x", 3, 15, "EqualityWithVariable", "Lygybės su vienu kintamuoju", "Math" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
