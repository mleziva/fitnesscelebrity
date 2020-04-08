using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessCelebrity.Web.Migrations
{
    public partial class UpdateFitnessDBUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ModifiedById",
                table: "Workouts",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "Workouts",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedById",
                table: "Movements",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "Movements",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedById",
                table: "FitnessPaths",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "FitnessPaths",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_ModifiedById",
                table: "Workouts",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Movements_ModifiedById",
                table: "Movements",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessPaths_ModifiedById",
                table: "FitnessPaths",
                column: "ModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessPaths_ApplicationUser_ModifiedById",
                table: "FitnessPaths",
                column: "ModifiedById",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_ApplicationUser_ModifiedById",
                table: "Movements",
                column: "ModifiedById",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_ApplicationUser_ModifiedById",
                table: "Workouts",
                column: "ModifiedById",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FitnessPaths_ApplicationUser_ModifiedById",
                table: "FitnessPaths");

            migrationBuilder.DropForeignKey(
                name: "FK_Movements_ApplicationUser_ModifiedById",
                table: "Movements");

            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_ApplicationUser_ModifiedById",
                table: "Workouts");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_ModifiedById",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Movements_ModifiedById",
                table: "Movements");

            migrationBuilder.DropIndex(
                name: "IX_FitnessPaths_ModifiedById",
                table: "FitnessPaths");

            migrationBuilder.AlterColumn<long>(
                name: "ModifiedById",
                table: "Workouts",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "Workouts",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ModifiedById",
                table: "Movements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "Movements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ModifiedById",
                table: "FitnessPaths",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "FitnessPaths",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
