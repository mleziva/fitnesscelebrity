using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessCelebrity.Web.Migrations
{
    public partial class dbsets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FitnessPath_AspNetUsers_CreatedById",
                table: "FitnessPath");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessPath_AspNetUsers_ModifiedById",
                table: "FitnessPath");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessPathSubscription_FitnessPath_FitnessPathId",
                table: "FitnessPathSubscription");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessPathWorkout_FitnessPath_FitnessPathId",
                table: "FitnessPathWorkout");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessPathWorkout_Workout_WorkoutId",
                table: "FitnessPathWorkout");

            migrationBuilder.DropForeignKey(
                name: "FK_Movement_AspNetUsers_CreatedById",
                table: "Movement");

            migrationBuilder.DropForeignKey(
                name: "FK_Movement_AspNetUsers_ModifiedById",
                table: "Movement");

            migrationBuilder.DropForeignKey(
                name: "FK_Workout_AspNetUsers_CreatedById",
                table: "Workout");

            migrationBuilder.DropForeignKey(
                name: "FK_Workout_AspNetUsers_ModifiedById",
                table: "Workout");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutHistory_FitnessPath_FitnessPathId",
                table: "WorkoutHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutHistory_Workout_WorkoutId",
                table: "WorkoutHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutMovement_Movement_MovementId",
                table: "WorkoutMovement");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutMovement_Workout_WorkoutId",
                table: "WorkoutMovement");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutSubscription_Workout_WorkoutId",
                table: "WorkoutSubscription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkoutMovement",
                table: "WorkoutMovement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workout",
                table: "Workout");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movement",
                table: "Movement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessPathWorkout",
                table: "FitnessPathWorkout");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessPath",
                table: "FitnessPath");

            migrationBuilder.RenameTable(
                name: "WorkoutMovement",
                newName: "WorkoutMovements");

            migrationBuilder.RenameTable(
                name: "Workout",
                newName: "Workouts");

            migrationBuilder.RenameTable(
                name: "Movement",
                newName: "Movements");

            migrationBuilder.RenameTable(
                name: "FitnessPathWorkout",
                newName: "FitnessPathWorkouts");

            migrationBuilder.RenameTable(
                name: "FitnessPath",
                newName: "FitnessPaths");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutMovement_MovementId",
                table: "WorkoutMovements",
                newName: "IX_WorkoutMovements_MovementId");

            migrationBuilder.RenameIndex(
                name: "IX_Workout_ModifiedById",
                table: "Workouts",
                newName: "IX_Workouts_ModifiedById");

            migrationBuilder.RenameIndex(
                name: "IX_Workout_CreatedById",
                table: "Workouts",
                newName: "IX_Workouts_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Movement_ModifiedById",
                table: "Movements",
                newName: "IX_Movements_ModifiedById");

            migrationBuilder.RenameIndex(
                name: "IX_Movement_CreatedById",
                table: "Movements",
                newName: "IX_Movements_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessPathWorkout_WorkoutId",
                table: "FitnessPathWorkouts",
                newName: "IX_FitnessPathWorkouts_WorkoutId");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessPath_ModifiedById",
                table: "FitnessPaths",
                newName: "IX_FitnessPaths_ModifiedById");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessPath_CreatedById",
                table: "FitnessPaths",
                newName: "IX_FitnessPaths_CreatedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkoutMovements",
                table: "WorkoutMovements",
                columns: new[] { "WorkoutId", "MovementId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workouts",
                table: "Workouts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movements",
                table: "Movements",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessPathWorkouts",
                table: "FitnessPathWorkouts",
                columns: new[] { "FitnessPathId", "WorkoutId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessPaths",
                table: "FitnessPaths",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessPaths_AspNetUsers_CreatedById",
                table: "FitnessPaths",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessPaths_AspNetUsers_ModifiedById",
                table: "FitnessPaths",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessPathSubscription_FitnessPaths_FitnessPathId",
                table: "FitnessPathSubscription",
                column: "FitnessPathId",
                principalTable: "FitnessPaths",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessPathWorkouts_FitnessPaths_FitnessPathId",
                table: "FitnessPathWorkouts",
                column: "FitnessPathId",
                principalTable: "FitnessPaths",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessPathWorkouts_Workouts_WorkoutId",
                table: "FitnessPathWorkouts",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_AspNetUsers_CreatedById",
                table: "Movements",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_AspNetUsers_ModifiedById",
                table: "Movements",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutHistory_FitnessPaths_FitnessPathId",
                table: "WorkoutHistory",
                column: "FitnessPathId",
                principalTable: "FitnessPaths",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutHistory_Workouts_WorkoutId",
                table: "WorkoutHistory",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutMovements_Movements_MovementId",
                table: "WorkoutMovements",
                column: "MovementId",
                principalTable: "Movements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutMovements_Workouts_WorkoutId",
                table: "WorkoutMovements",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_AspNetUsers_CreatedById",
                table: "Workouts",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_AspNetUsers_ModifiedById",
                table: "Workouts",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutSubscription_Workouts_WorkoutId",
                table: "WorkoutSubscription",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FitnessPaths_AspNetUsers_CreatedById",
                table: "FitnessPaths");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessPaths_AspNetUsers_ModifiedById",
                table: "FitnessPaths");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessPathSubscription_FitnessPaths_FitnessPathId",
                table: "FitnessPathSubscription");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessPathWorkouts_FitnessPaths_FitnessPathId",
                table: "FitnessPathWorkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessPathWorkouts_Workouts_WorkoutId",
                table: "FitnessPathWorkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_Movements_AspNetUsers_CreatedById",
                table: "Movements");

            migrationBuilder.DropForeignKey(
                name: "FK_Movements_AspNetUsers_ModifiedById",
                table: "Movements");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutHistory_FitnessPaths_FitnessPathId",
                table: "WorkoutHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutHistory_Workouts_WorkoutId",
                table: "WorkoutHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutMovements_Movements_MovementId",
                table: "WorkoutMovements");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutMovements_Workouts_WorkoutId",
                table: "WorkoutMovements");

            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_AspNetUsers_CreatedById",
                table: "Workouts");

            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_AspNetUsers_ModifiedById",
                table: "Workouts");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutSubscription_Workouts_WorkoutId",
                table: "WorkoutSubscription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workouts",
                table: "Workouts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkoutMovements",
                table: "WorkoutMovements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movements",
                table: "Movements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessPathWorkouts",
                table: "FitnessPathWorkouts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessPaths",
                table: "FitnessPaths");

            migrationBuilder.RenameTable(
                name: "Workouts",
                newName: "Workout");

            migrationBuilder.RenameTable(
                name: "WorkoutMovements",
                newName: "WorkoutMovement");

            migrationBuilder.RenameTable(
                name: "Movements",
                newName: "Movement");

            migrationBuilder.RenameTable(
                name: "FitnessPathWorkouts",
                newName: "FitnessPathWorkout");

            migrationBuilder.RenameTable(
                name: "FitnessPaths",
                newName: "FitnessPath");

            migrationBuilder.RenameIndex(
                name: "IX_Workouts_ModifiedById",
                table: "Workout",
                newName: "IX_Workout_ModifiedById");

            migrationBuilder.RenameIndex(
                name: "IX_Workouts_CreatedById",
                table: "Workout",
                newName: "IX_Workout_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutMovements_MovementId",
                table: "WorkoutMovement",
                newName: "IX_WorkoutMovement_MovementId");

            migrationBuilder.RenameIndex(
                name: "IX_Movements_ModifiedById",
                table: "Movement",
                newName: "IX_Movement_ModifiedById");

            migrationBuilder.RenameIndex(
                name: "IX_Movements_CreatedById",
                table: "Movement",
                newName: "IX_Movement_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessPathWorkouts_WorkoutId",
                table: "FitnessPathWorkout",
                newName: "IX_FitnessPathWorkout_WorkoutId");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessPaths_ModifiedById",
                table: "FitnessPath",
                newName: "IX_FitnessPath_ModifiedById");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessPaths_CreatedById",
                table: "FitnessPath",
                newName: "IX_FitnessPath_CreatedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workout",
                table: "Workout",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkoutMovement",
                table: "WorkoutMovement",
                columns: new[] { "WorkoutId", "MovementId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movement",
                table: "Movement",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessPathWorkout",
                table: "FitnessPathWorkout",
                columns: new[] { "FitnessPathId", "WorkoutId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessPath",
                table: "FitnessPath",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessPath_AspNetUsers_CreatedById",
                table: "FitnessPath",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessPath_AspNetUsers_ModifiedById",
                table: "FitnessPath",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessPathSubscription_FitnessPath_FitnessPathId",
                table: "FitnessPathSubscription",
                column: "FitnessPathId",
                principalTable: "FitnessPath",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessPathWorkout_FitnessPath_FitnessPathId",
                table: "FitnessPathWorkout",
                column: "FitnessPathId",
                principalTable: "FitnessPath",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessPathWorkout_Workout_WorkoutId",
                table: "FitnessPathWorkout",
                column: "WorkoutId",
                principalTable: "Workout",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movement_AspNetUsers_CreatedById",
                table: "Movement",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movement_AspNetUsers_ModifiedById",
                table: "Movement",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workout_AspNetUsers_CreatedById",
                table: "Workout",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workout_AspNetUsers_ModifiedById",
                table: "Workout",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutHistory_FitnessPath_FitnessPathId",
                table: "WorkoutHistory",
                column: "FitnessPathId",
                principalTable: "FitnessPath",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutHistory_Workout_WorkoutId",
                table: "WorkoutHistory",
                column: "WorkoutId",
                principalTable: "Workout",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutMovement_Movement_MovementId",
                table: "WorkoutMovement",
                column: "MovementId",
                principalTable: "Movement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutMovement_Workout_WorkoutId",
                table: "WorkoutMovement",
                column: "WorkoutId",
                principalTable: "Workout",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutSubscription_Workout_WorkoutId",
                table: "WorkoutSubscription",
                column: "WorkoutId",
                principalTable: "Workout",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
