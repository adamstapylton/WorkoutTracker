using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkoutTracker.Server.Data.Migrations
{
    public partial class CompletedWorkoutExFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompletedWorkoutExercises_WorkoutExercises_WorkoutExerciseId",
                table: "CompletedWorkoutExercises");

            migrationBuilder.DropIndex(
                name: "IX_CompletedWorkoutExercises_WorkoutExerciseId",
                table: "CompletedWorkoutExercises");

            migrationBuilder.DropColumn(
                name: "WorkoutExerciseId",
                table: "CompletedWorkoutExercises");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "CompletedWorkoutExercises",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RepScheme",
                table: "CompletedWorkoutExercises",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScheduledSets",
                table: "CompletedWorkoutExercises",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CompletedWorkoutExercises_ExerciseId",
                table: "CompletedWorkoutExercises",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedWorkoutExercises_Exercises_ExerciseId",
                table: "CompletedWorkoutExercises",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompletedWorkoutExercises_Exercises_ExerciseId",
                table: "CompletedWorkoutExercises");

            migrationBuilder.DropIndex(
                name: "IX_CompletedWorkoutExercises_ExerciseId",
                table: "CompletedWorkoutExercises");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "CompletedWorkoutExercises");

            migrationBuilder.DropColumn(
                name: "RepScheme",
                table: "CompletedWorkoutExercises");

            migrationBuilder.DropColumn(
                name: "ScheduledSets",
                table: "CompletedWorkoutExercises");

            migrationBuilder.AddColumn<int>(
                name: "WorkoutExerciseId",
                table: "CompletedWorkoutExercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CompletedWorkoutExercises_WorkoutExerciseId",
                table: "CompletedWorkoutExercises",
                column: "WorkoutExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedWorkoutExercises_WorkoutExercises_WorkoutExerciseId",
                table: "CompletedWorkoutExercises",
                column: "WorkoutExerciseId",
                principalTable: "WorkoutExercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
