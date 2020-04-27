using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessCelebrity.Web.Migrations
{
    public partial class FPEnhance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessPathWorkouts",
                table: "FitnessPathWorkouts");

            migrationBuilder.AddColumn<int>(
                name: "Privacy",
                table: "Workouts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Privacy",
                table: "Movements",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "FitnessPathWorkouts",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "FitnessPathWorkouts",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "FitnessPathWorkouts",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Date",
                table: "FitnessPathWorkouts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DayOfWeek",
                table: "FitnessPathWorkouts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedById",
                table: "FitnessPathWorkouts",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDate",
                table: "FitnessPathWorkouts",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "FitnessPathWorkouts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Week",
                table: "FitnessPathWorkouts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkoutOrder",
                table: "FitnessPathWorkouts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Privacy",
                table: "FitnessPaths",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessPathWorkouts",
                table: "FitnessPathWorkouts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessPathWorkouts_CreatedById",
                table: "FitnessPathWorkouts",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessPathWorkouts_FitnessPathId",
                table: "FitnessPathWorkouts",
                column: "FitnessPathId");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessPathWorkouts_ModifiedById",
                table: "FitnessPathWorkouts",
                column: "ModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessPathWorkouts_AspNetUsers_CreatedById",
                table: "FitnessPathWorkouts",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessPathWorkouts_AspNetUsers_ModifiedById",
                table: "FitnessPathWorkouts",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FitnessPathWorkouts_AspNetUsers_CreatedById",
                table: "FitnessPathWorkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessPathWorkouts_AspNetUsers_ModifiedById",
                table: "FitnessPathWorkouts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessPathWorkouts",
                table: "FitnessPathWorkouts");

            migrationBuilder.DropIndex(
                name: "IX_FitnessPathWorkouts_CreatedById",
                table: "FitnessPathWorkouts");

            migrationBuilder.DropIndex(
                name: "IX_FitnessPathWorkouts_FitnessPathId",
                table: "FitnessPathWorkouts");

            migrationBuilder.DropIndex(
                name: "IX_FitnessPathWorkouts_ModifiedById",
                table: "FitnessPathWorkouts");

            migrationBuilder.DropColumn(
                name: "Privacy",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "Privacy",
                table: "Movements");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FitnessPathWorkouts");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "FitnessPathWorkouts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "FitnessPathWorkouts");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "FitnessPathWorkouts");

            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "FitnessPathWorkouts");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "FitnessPathWorkouts");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "FitnessPathWorkouts");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "FitnessPathWorkouts");

            migrationBuilder.DropColumn(
                name: "Week",
                table: "FitnessPathWorkouts");

            migrationBuilder.DropColumn(
                name: "WorkoutOrder",
                table: "FitnessPathWorkouts");

            migrationBuilder.DropColumn(
                name: "Privacy",
                table: "FitnessPaths");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessPathWorkouts",
                table: "FitnessPathWorkouts",
                columns: new[] { "FitnessPathId", "WorkoutId" });
        }
    }
}
