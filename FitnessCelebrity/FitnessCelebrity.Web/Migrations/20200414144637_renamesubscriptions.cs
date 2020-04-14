using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessCelebrity.Web.Migrations
{
    public partial class renamesubscriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubscribedFitnessPaths");

            migrationBuilder.DropTable(
                name: "SubscribedUsers");

            migrationBuilder.DropTable(
                name: "SubscribedWorkouts");

            migrationBuilder.CreateTable(
                name: "FitnessPathSubscription",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(nullable: false),
                    FitnessPathId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessPathSubscription", x => new { x.ApplicationUserId, x.FitnessPathId });
                    table.ForeignKey(
                        name: "FK_FitnessPathSubscription_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FitnessPathSubscription_FitnessPath_FitnessPathId",
                        column: x => x.FitnessPathId,
                        principalTable: "FitnessPath",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSubscription",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(nullable: false),
                    UserProfileId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSubscription", x => new { x.ApplicationUserId, x.UserProfileId });
                    table.ForeignKey(
                        name: "FK_UserSubscription_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSubscription_UserProfile_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutSubscription",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(nullable: false),
                    WorkoutId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutSubscription", x => new { x.ApplicationUserId, x.WorkoutId });
                    table.ForeignKey(
                        name: "FK_WorkoutSubscription_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutSubscription_Workout_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FitnessPathSubscription_FitnessPathId",
                table: "FitnessPathSubscription",
                column: "FitnessPathId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubscription_UserProfileId",
                table: "UserSubscription",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSubscription_WorkoutId",
                table: "WorkoutSubscription",
                column: "WorkoutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FitnessPathSubscription");

            migrationBuilder.DropTable(
                name: "UserSubscription");

            migrationBuilder.DropTable(
                name: "WorkoutSubscription");

            migrationBuilder.CreateTable(
                name: "SubscribedFitnessPaths",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FitnessPathId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscribedFitnessPaths", x => new { x.ApplicationUserId, x.FitnessPathId });
                    table.ForeignKey(
                        name: "FK_SubscribedFitnessPaths_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscribedFitnessPaths_FitnessPath_FitnessPathId",
                        column: x => x.FitnessPathId,
                        principalTable: "FitnessPath",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscribedUsers",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserProfileId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscribedUsers", x => new { x.ApplicationUserId, x.UserProfileId });
                    table.ForeignKey(
                        name: "FK_SubscribedUsers_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscribedUsers_UserProfile_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscribedWorkouts",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WorkoutId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscribedWorkouts", x => new { x.ApplicationUserId, x.WorkoutId });
                    table.ForeignKey(
                        name: "FK_SubscribedWorkouts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscribedWorkouts_Workout_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubscribedFitnessPaths_FitnessPathId",
                table: "SubscribedFitnessPaths",
                column: "FitnessPathId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscribedUsers_UserProfileId",
                table: "SubscribedUsers",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscribedWorkouts_WorkoutId",
                table: "SubscribedWorkouts",
                column: "WorkoutId");
        }
    }
}
