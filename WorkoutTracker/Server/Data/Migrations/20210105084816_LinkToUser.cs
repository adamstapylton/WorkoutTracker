using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkoutTracker.Server.Data.Migrations
{
    public partial class LinkToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "WeightLogs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CompletedWorkouts");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Workouts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "WeightLogs",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "CompletedWorkouts",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "WeightLogs");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "CompletedWorkouts");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Workouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "WeightLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CompletedWorkouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
