using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessCelebrity.Web.Migrations
{
    public partial class histories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyLog_AspNetUsers_UserId",
                table: "DailyLog");

            migrationBuilder.DropForeignKey(
                name: "FK_DailyLog_WorkoutHistory_WorkoutHistoryId",
                table: "DailyLog");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutHistory_FitnessPaths_FitnessPathId",
                table: "WorkoutHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutHistory_AspNetUsers_UserId",
                table: "WorkoutHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutHistory_Workouts_WorkoutId",
                table: "WorkoutHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkoutHistory",
                table: "WorkoutHistory");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutHistory_FitnessPathId",
                table: "WorkoutHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DailyLog",
                table: "DailyLog");

            migrationBuilder.DropColumn(
                name: "FitnessPathId",
                table: "WorkoutHistory");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "WorkoutHistory");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "WorkoutHistory");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "WorkoutHistory");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "WorkoutHistory");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "DailyLog");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "DailyLog");

            migrationBuilder.RenameTable(
                name: "WorkoutHistory",
                newName: "WorkoutHistories");

            migrationBuilder.RenameTable(
                name: "DailyLog",
                newName: "DailyLogs");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutHistory_WorkoutId",
                table: "WorkoutHistories",
                newName: "IX_WorkoutHistories_WorkoutId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutHistory_UserId",
                table: "WorkoutHistories",
                newName: "IX_WorkoutHistories_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DailyLog_WorkoutHistoryId",
                table: "DailyLogs",
                newName: "IX_DailyLogs_WorkoutHistoryId");

            migrationBuilder.RenameIndex(
                name: "IX_DailyLog_UserId",
                table: "DailyLogs",
                newName: "IX_DailyLogs_UserId");

            migrationBuilder.AddColumn<long>(
                name: "FitnessPathHistoryId",
                table: "WorkoutHistories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Privacy",
                table: "WorkoutHistories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "WorkoutHistories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Privacy",
                table: "DailyLogs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkoutHistories",
                table: "WorkoutHistories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DailyLogs",
                table: "DailyLogs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FitnessPathHistories",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(nullable: false),
                    FitnessPathId = table.Column<long>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Privacy = table.Column<int>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    StartedDate = table.Column<DateTimeOffset>(nullable: false),
                    CompletedDate = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessPathHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FitnessPathHistories_FitnessPaths_FitnessPathId",
                        column: x => x.FitnessPathId,
                        principalTable: "FitnessPaths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FitnessPathHistories_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutHistories_FitnessPathHistoryId",
                table: "WorkoutHistories",
                column: "FitnessPathHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessPathHistories_FitnessPathId",
                table: "FitnessPathHistories",
                column: "FitnessPathId");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessPathHistories_UserId",
                table: "FitnessPathHistories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyLogs_AspNetUsers_UserId",
                table: "DailyLogs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyLogs_WorkoutHistories_WorkoutHistoryId",
                table: "DailyLogs",
                column: "WorkoutHistoryId",
                principalTable: "WorkoutHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutHistories_FitnessPathHistories_FitnessPathHistoryId",
                table: "WorkoutHistories",
                column: "FitnessPathHistoryId",
                principalTable: "FitnessPathHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutHistories_AspNetUsers_UserId",
                table: "WorkoutHistories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutHistories_Workouts_WorkoutId",
                table: "WorkoutHistories",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyLogs_AspNetUsers_UserId",
                table: "DailyLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_DailyLogs_WorkoutHistories_WorkoutHistoryId",
                table: "DailyLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutHistories_FitnessPathHistories_FitnessPathHistoryId",
                table: "WorkoutHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutHistories_AspNetUsers_UserId",
                table: "WorkoutHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutHistories_Workouts_WorkoutId",
                table: "WorkoutHistories");

            migrationBuilder.DropTable(
                name: "FitnessPathHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkoutHistories",
                table: "WorkoutHistories");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutHistories_FitnessPathHistoryId",
                table: "WorkoutHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DailyLogs",
                table: "DailyLogs");

            migrationBuilder.DropColumn(
                name: "FitnessPathHistoryId",
                table: "WorkoutHistories");

            migrationBuilder.DropColumn(
                name: "Privacy",
                table: "WorkoutHistories");

            migrationBuilder.DropColumn(
                name: "State",
                table: "WorkoutHistories");

            migrationBuilder.DropColumn(
                name: "Privacy",
                table: "DailyLogs");

            migrationBuilder.RenameTable(
                name: "WorkoutHistories",
                newName: "WorkoutHistory");

            migrationBuilder.RenameTable(
                name: "DailyLogs",
                newName: "DailyLog");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutHistories_WorkoutId",
                table: "WorkoutHistory",
                newName: "IX_WorkoutHistory_WorkoutId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutHistories_UserId",
                table: "WorkoutHistory",
                newName: "IX_WorkoutHistory_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DailyLogs_WorkoutHistoryId",
                table: "DailyLog",
                newName: "IX_DailyLog_WorkoutHistoryId");

            migrationBuilder.RenameIndex(
                name: "IX_DailyLogs_UserId",
                table: "DailyLog",
                newName: "IX_DailyLog_UserId");

            migrationBuilder.AddColumn<long>(
                name: "FitnessPathId",
                table: "WorkoutHistory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "WorkoutHistory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "WorkoutHistory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "WorkoutHistory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "WorkoutHistory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "DailyLog",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "DailyLog",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkoutHistory",
                table: "WorkoutHistory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DailyLog",
                table: "DailyLog",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutHistory_FitnessPathId",
                table: "WorkoutHistory",
                column: "FitnessPathId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyLog_AspNetUsers_UserId",
                table: "DailyLog",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyLog_WorkoutHistory_WorkoutHistoryId",
                table: "DailyLog",
                column: "WorkoutHistoryId",
                principalTable: "WorkoutHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutHistory_FitnessPaths_FitnessPathId",
                table: "WorkoutHistory",
                column: "FitnessPathId",
                principalTable: "FitnessPaths",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutHistory_AspNetUsers_UserId",
                table: "WorkoutHistory",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutHistory_Workouts_WorkoutId",
                table: "WorkoutHistory",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
