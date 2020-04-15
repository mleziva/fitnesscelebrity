using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessCelebrity.Web.Migrations
{
    public partial class dailylog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Workout",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Movement",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "FitnessPath",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "WorkoutHistory",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(nullable: false),
                    WorkoutId = table.Column<long>(nullable: false),
                    FitnessPathId = table.Column<long>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false),
                    IsPublic = table.Column<bool>(nullable: false),
                    IsPrivate = table.Column<bool>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    StartedDate = table.Column<DateTimeOffset>(nullable: false),
                    CompletedDate = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutHistory_FitnessPath_FitnessPathId",
                        column: x => x.FitnessPathId,
                        principalTable: "FitnessPath",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutHistory_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkoutHistory_Workout_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyLog",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(nullable: false),
                    WorkoutHistoryId = table.Column<long>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    TimeSpent = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    IsPublic = table.Column<bool>(nullable: false),
                    IsPrivate = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyLog_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyLog_WorkoutHistory_WorkoutHistoryId",
                        column: x => x.WorkoutHistoryId,
                        principalTable: "WorkoutHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyLog_UserId",
                table: "DailyLog",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyLog_WorkoutHistoryId",
                table: "DailyLog",
                column: "WorkoutHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutHistory_FitnessPathId",
                table: "WorkoutHistory",
                column: "FitnessPathId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutHistory_UserId",
                table: "WorkoutHistory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutHistory_WorkoutId",
                table: "WorkoutHistory",
                column: "WorkoutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyLog");

            migrationBuilder.DropTable(
                name: "WorkoutHistory");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Workout");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Movement");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "FitnessPath");
        }
    }
}
