using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessCelebrity.Web.Migrations
{
    public partial class colorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "WorkoutSubscription",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDate",
                table: "WorkoutSubscription",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "UserSubscription",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDate",
                table: "UserSubscription",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "FitnessPathSubscription",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDate",
                table: "FitnessPathSubscription",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "WorkoutSubscription");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "WorkoutSubscription");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "UserSubscription");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "UserSubscription");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "FitnessPathSubscription");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "FitnessPathSubscription");
        }
    }
}
