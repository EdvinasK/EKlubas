using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EKlubas.UI.Migrations
{
    public partial class AddedStudyTopicCreationTimestamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTimestamp",
                table: "StudyTopics",
                type: "datetime",
                nullable: false,
                defaultValueSql: "'1900-01-01T00:00:00.000'");

            migrationBuilder.AddColumn<bool>(
                name: "IsNew",
                table: "StudyTopics",
                nullable: false,
                defaultValue: true);

            migrationBuilder.UpdateData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsNew",
                value: true);

            migrationBuilder.UpdateData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsNew",
                value: true);

            migrationBuilder.UpdateData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsNew",
                value: true);

            migrationBuilder.UpdateData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsNew",
                value: true);

            migrationBuilder.UpdateData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsNew",
                value: true);

            migrationBuilder.UpdateData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsNew",
                value: true);

            migrationBuilder.UpdateData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 7,
                column: "IsNew",
                value: true);

            migrationBuilder.UpdateData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 8,
                column: "IsNew",
                value: true);

            migrationBuilder.UpdateData(
                table: "StudyTopics",
                keyColumn: "Id",
                keyValue: 9,
                column: "IsNew",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedTimestamp",
                table: "StudyTopics");

            migrationBuilder.DropColumn(
                name: "IsNew",
                table: "StudyTopics");
        }
    }
}
