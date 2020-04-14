using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessCelebrity.Web.Migrations
{
    public partial class baseupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FitnessPathSubscription_AspNetUsers_ApplicationUserId",
                table: "FitnessPathSubscription");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile_AspNetUsers_CreatedById",
                table: "UserProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile_AspNetUsers_ModifiedById",
                table: "UserProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSubscription_AspNetUsers_ApplicationUserId",
                table: "UserSubscription");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutSubscription_AspNetUsers_ApplicationUserId",
                table: "WorkoutSubscription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkoutSubscription",
                table: "WorkoutSubscription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSubscription",
                table: "UserSubscription");

            migrationBuilder.DropIndex(
                name: "IX_UserProfile_CreatedById",
                table: "UserProfile");

            migrationBuilder.DropIndex(
                name: "IX_UserProfile_ModifiedById",
                table: "UserProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessPathSubscription",
                table: "FitnessPathSubscription");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "UserProfile");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "WorkoutSubscription",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "WorkoutSubscription",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UserSubscription",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "UserSubscription",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "UserProfile",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId2",
                table: "UserProfile",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "FitnessPathSubscription",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "FitnessPathSubscription",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkoutSubscription",
                table: "WorkoutSubscription",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSubscription",
                table: "UserSubscription",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessPathSubscription",
                table: "FitnessPathSubscription",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSubscription_ApplicationUserId",
                table: "WorkoutSubscription",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubscription_ApplicationUserId",
                table: "UserSubscription",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_ApplicationUserId1",
                table: "UserProfile",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_ApplicationUserId2",
                table: "UserProfile",
                column: "ApplicationUserId2");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessPathSubscription_ApplicationUserId",
                table: "FitnessPathSubscription",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessPathSubscription_AspNetUsers_ApplicationUserId",
                table: "FitnessPathSubscription",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_AspNetUsers_ApplicationUserId1",
                table: "UserProfile",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_AspNetUsers_ApplicationUserId2",
                table: "UserProfile",
                column: "ApplicationUserId2",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSubscription_AspNetUsers_ApplicationUserId",
                table: "UserSubscription",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutSubscription_AspNetUsers_ApplicationUserId",
                table: "WorkoutSubscription",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FitnessPathSubscription_AspNetUsers_ApplicationUserId",
                table: "FitnessPathSubscription");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile_AspNetUsers_ApplicationUserId1",
                table: "UserProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile_AspNetUsers_ApplicationUserId2",
                table: "UserProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSubscription_AspNetUsers_ApplicationUserId",
                table: "UserSubscription");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutSubscription_AspNetUsers_ApplicationUserId",
                table: "WorkoutSubscription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkoutSubscription",
                table: "WorkoutSubscription");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutSubscription_ApplicationUserId",
                table: "WorkoutSubscription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSubscription",
                table: "UserSubscription");

            migrationBuilder.DropIndex(
                name: "IX_UserSubscription_ApplicationUserId",
                table: "UserSubscription");

            migrationBuilder.DropIndex(
                name: "IX_UserProfile_ApplicationUserId1",
                table: "UserProfile");

            migrationBuilder.DropIndex(
                name: "IX_UserProfile_ApplicationUserId2",
                table: "UserProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessPathSubscription",
                table: "FitnessPathSubscription");

            migrationBuilder.DropIndex(
                name: "IX_FitnessPathSubscription_ApplicationUserId",
                table: "FitnessPathSubscription");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "WorkoutSubscription");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserSubscription");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId2",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FitnessPathSubscription");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "WorkoutSubscription",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UserSubscription",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "UserProfile",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedById",
                table: "UserProfile",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "FitnessPathSubscription",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkoutSubscription",
                table: "WorkoutSubscription",
                columns: new[] { "ApplicationUserId", "WorkoutId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSubscription",
                table: "UserSubscription",
                columns: new[] { "ApplicationUserId", "UserProfileId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessPathSubscription",
                table: "FitnessPathSubscription",
                columns: new[] { "ApplicationUserId", "FitnessPathId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_CreatedById",
                table: "UserProfile",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_ModifiedById",
                table: "UserProfile",
                column: "ModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessPathSubscription_AspNetUsers_ApplicationUserId",
                table: "FitnessPathSubscription",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_AspNetUsers_CreatedById",
                table: "UserProfile",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_AspNetUsers_ModifiedById",
                table: "UserProfile",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSubscription_AspNetUsers_ApplicationUserId",
                table: "UserSubscription",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutSubscription_AspNetUsers_ApplicationUserId",
                table: "WorkoutSubscription",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
