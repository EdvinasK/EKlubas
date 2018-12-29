using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EKlubas.UI.Migrations
{
    public partial class UpdatedUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserClaim<string>s_IdentityUsers_UserId",
                table: "IdentityUserClaim<string>s");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserLogin<string>s_IdentityUsers_UserId",
                table: "IdentityUserLogin<string>s");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserRole<string>s_IdentityUsers_UserId",
                table: "IdentityUserRole<string>s");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserToken<string>s_IdentityUsers_UserId",
                table: "IdentityUserToken<string>s");

            migrationBuilder.DropTable(
                name: "IdentityUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "IdentityUserToken<string>s",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "IdentityUserToken<string>s",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "IdentityUserLogin<string>s",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "IdentityUserLogin<string>s",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "IdentityRoles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EKlubasUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Nickname = table.Column<string>(nullable: true),
                    BirthYear = table.Column<DateTime>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'1900-01-01T00:00:00.000'"),
                    LastLogin = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'1900-01-01T00:00:00.000'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EKlubasUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EKlubasUsers_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Name",
                table: "Cities",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_EKlubasUsers_CityId",
                table: "EKlubasUsers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "EKlubasUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "EKlubasUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>s_EKlubasUsers_UserId",
                table: "IdentityUserClaim<string>s",
                column: "UserId",
                principalTable: "EKlubasUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>s_EKlubasUsers_UserId",
                table: "IdentityUserLogin<string>s",
                column: "UserId",
                principalTable: "EKlubasUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>s_EKlubasUsers_UserId",
                table: "IdentityUserRole<string>s",
                column: "UserId",
                principalTable: "EKlubasUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserToken<string>s_EKlubasUsers_UserId",
                table: "IdentityUserToken<string>s",
                column: "UserId",
                principalTable: "EKlubasUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserClaim<string>s_EKlubasUsers_UserId",
                table: "IdentityUserClaim<string>s");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserLogin<string>s_EKlubasUsers_UserId",
                table: "IdentityUserLogin<string>s");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserRole<string>s_EKlubasUsers_UserId",
                table: "IdentityUserRole<string>s");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserToken<string>s_EKlubasUsers_UserId",
                table: "IdentityUserToken<string>s");

            migrationBuilder.DropTable(
                name: "EKlubasUsers");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "IdentityRoles");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "IdentityUserToken<string>s",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "IdentityUserToken<string>s",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "IdentityUserLogin<string>s",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "IdentityUserLogin<string>s",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "IdentityUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUsers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "IdentityUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "IdentityUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>s_IdentityUsers_UserId",
                table: "IdentityUserClaim<string>s",
                column: "UserId",
                principalTable: "IdentityUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>s_IdentityUsers_UserId",
                table: "IdentityUserLogin<string>s",
                column: "UserId",
                principalTable: "IdentityUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>s_IdentityUsers_UserId",
                table: "IdentityUserRole<string>s",
                column: "UserId",
                principalTable: "IdentityUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserToken<string>s_IdentityUsers_UserId",
                table: "IdentityUserToken<string>s",
                column: "UserId",
                principalTable: "IdentityUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
