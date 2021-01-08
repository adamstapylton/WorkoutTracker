using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkoutTracker.Server.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompletedWorkouts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateComplete = table.Column<DateTime>(nullable: false),
                    WorkoutId = table.Column<int>(nullable: false),
                    WorkoutName = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedWorkouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MuscleGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuscleGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeightLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Weight = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Scheduled = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    EquipmentId = table.Column<int>(nullable: false),
                    MuscleGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exercises_MuscleGroups_MuscleGroupId",
                        column: x => x.MuscleGroupId,
                        principalTable: "MuscleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutExercises",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderInt = table.Column<int>(nullable: false),
                    OrderString = table.Column<string>(maxLength: 4, nullable: true),
                    ExerciseId = table.Column<int>(nullable: false),
                    Sets = table.Column<int>(nullable: false),
                    RepScheme = table.Column<string>(nullable: true),
                    Rest = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    WorkoutId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutExercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutExercises_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutExercises_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompletedWorkoutExercises",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkoutExerciseId = table.Column<int>(nullable: false),
                    CompletedWorkoutId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedWorkoutExercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompletedWorkoutExercises_CompletedWorkouts_CompletedWorkoutId",
                        column: x => x.CompletedWorkoutId,
                        principalTable: "CompletedWorkouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompletedWorkoutExercises_WorkoutExercises_WorkoutExerciseId",
                        column: x => x.WorkoutExerciseId,
                        principalTable: "WorkoutExercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompletedSets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SetNumber = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    Reps = table.Column<int>(nullable: false),
                    CompletedWorkoutExerciseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompletedSets_CompletedWorkoutExercises_CompletedWorkoutExerciseId",
                        column: x => x.CompletedWorkoutExerciseId,
                        principalTable: "CompletedWorkoutExercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Barbell" },
                    { 2, "Dumbbell" },
                    { 3, "BodyWeight" },
                    { 4, "Plate Loaded Machine" },
                    { 5, "Weight Stack Machine" },
                    { 6, "Smith Machine" },
                    { 7, "Cable Machine" },
                    { 8, "Kettlebell" }
                });

            migrationBuilder.InsertData(
                table: "MuscleGroups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 15, "Upper Back" },
                    { 14, "Triceps" },
                    { 13, "Traps" },
                    { 12, "Shoulders (Side)" },
                    { 11, "Shoulders (Rear)" },
                    { 10, "Shoulders (Front)" },
                    { 9, "Quads" },
                    { 5, "Forearms" },
                    { 7, "Hamstrings" },
                    { 6, "Glutes" },
                    { 16, "Cardio (Steady State)" },
                    { 4, "Chest" },
                    { 3, "Calves" },
                    { 2, "Biceps" },
                    { 1, "Abs" },
                    { 8, "Lats" },
                    { 17, "Cardio (HIIT)" }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "EquipmentId", "MuscleGroupId", "Name" },
                values: new object[,]
                {
                    { 8, 1, 4, "Bench Press" },
                    { 59, 4, 10, "Plate Loaded Shoulder Press" },
                    { 58, 2, 10, "Arnold Press (Seated)" },
                    { 57, 2, 10, "Arnold Press (Standing)" },
                    { 56, 2, 10, "Dumbbell Shoulder Press (Standing)" },
                    { 55, 2, 10, "Dumbbell Shoulder Press (Seated)" },
                    { 54, 1, 10, "Barbell Shoulder Press (Seated)" },
                    { 60, 5, 10, "Weight Stack Shoulder Press" },
                    { 53, 1, 10, "Barbell Shoulder Press (Standing)" },
                    { 6, 6, 9, "Smith Machine Squat" },
                    { 5, 4, 9, "Hack Squat" },
                    { 4, 4, 9, "Leg Press" },
                    { 3, 1, 9, "Front Squat" },
                    { 2, 1, 9, "Low Bar Back Squat" },
                    { 1, 1, 9, "High Bar Back Squat" },
                    { 7, 2, 9, "Bulgarian Split Squat" },
                    { 40, 5, 8, "Weight Stack Lat Pulldown" },
                    { 64, 2, 10, "Dumbbell Front Raise" },
                    { 66, 2, 11, "Dumbbell Rear Delt Flies" },
                    { 37, 4, 15, "Plate Loaded High Row" },
                    { 36, 2, 15, "1 Arm Dumbbell Row" },
                    { 35, 2, 15, "Chest Supported Dumbbell Row" },
                    { 34, 5, 15, "Seated Cable Row" },
                    { 33, 1, 15, "Bent Over Barbell Row" },
                    { 72, 7, 12, "Cable Upright Row (Wide Grip)" },
                    { 65, 7, 10, "Cable Front Raise" },
                    { 71, 7, 12, "Cable Upright Row (Close Grip)" },
                    { 69, 1, 12, "Barbell Upright Row (Wide Grip)" },
                    { 63, 7, 12, "Cable Lateral Raises (1 Arm)" },
                    { 62, 7, 12, "Cable Lateral Raises" },
                    { 61, 2, 12, "Dumbbell Lateral Raises" },
                    { 68, 5, 11, "Reverse Pec Dec" },
                    { 67, 7, 11, "Cable Rear Delt Flies" },
                    { 70, 1, 12, "Barbell Upright Row (Close Grip)" },
                    { 39, 4, 8, "Plate Loaded Lat Pulldown" },
                    { 32, 5, 8, "Underhand Lat Pulldown" },
                    { 31, 5, 8, "Overhand Lat Pulldown" },
                    { 22, 7, 4, "Cable Flies (Upper Chest)" },
                    { 21, 7, 4, "Cable Flies" },
                    { 20, 5, 4, "Pec Dec" },
                    { 19, 5, 4, "Weight Stack Incline Chest Press" },
                    { 18, 5, 4, "Weight Stack Chest Press" },
                    { 17, 5, 4, "Weight Stack Decline Chest Press" },
                    { 23, 3, 4, "Pushups" },
                    { 16, 4, 4, "Plate Loaded Decline Chest Press" },
                    { 14, 4, 4, "Plate Loaded Chest Press" },
                    { 13, 2, 4, "Dumbbell Decline Bench Press" },
                    { 12, 2, 4, "Dumbbell Flat Bench Press" },
                    { 11, 2, 4, "Dumbbell Incline Bench Press" },
                    { 10, 1, 4, "Decline Bench Press" },
                    { 9, 1, 4, "Incline Bench Press" },
                    { 15, 4, 4, "Plate Loaded Incline Chest Press" },
                    { 24, 3, 4, "Feet Elevated Pushups" },
                    { 25, 3, 4, "Hands Elevated Pushups" },
                    { 26, 3, 4, "Dips" },
                    { 30, 5, 8, "Neutral Grip Lat Pulldown" },
                    { 29, 3, 8, "Neutral Grip Chinups" },
                    { 28, 3, 8, "Chinups" },
                    { 27, 3, 8, "Pullups" },
                    { 52, 5, 7, "Seated Leg Curl" },
                    { 51, 5, 7, "Standing Leg Curl" },
                    { 50, 5, 7, "Laying Leg Curl" },
                    { 49, 2, 7, "Dumbell Sumo Deadlift" },
                    { 48, 2, 7, "Dumbell Stiff Legged Deadlift" },
                    { 47, 2, 7, "Dumbell Romanian Deadlift" },
                    { 46, 1, 7, "Deficit Deadlift" },
                    { 45, 1, 7, "Sumo Deadlift" },
                    { 44, 1, 7, "Stiff Legged Deadlift" },
                    { 43, 1, 7, "Deadlift" },
                    { 42, 1, 7, "Romanian Deadlift" },
                    { 38, 4, 15, "Plate Loaded Low Row" },
                    { 41, 5, 15, "Weight Stack Chest Supported Row" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompletedSets_CompletedWorkoutExerciseId",
                table: "CompletedSets",
                column: "CompletedWorkoutExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedWorkoutExercises_CompletedWorkoutId",
                table: "CompletedWorkoutExercises",
                column: "CompletedWorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedWorkoutExercises_WorkoutExerciseId",
                table: "CompletedWorkoutExercises",
                column: "WorkoutExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_EquipmentId",
                table: "Exercises",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_MuscleGroupId",
                table: "Exercises",
                column: "MuscleGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExercises_ExerciseId",
                table: "WorkoutExercises",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExercises_WorkoutId",
                table: "WorkoutExercises",
                column: "WorkoutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompletedSets");

            migrationBuilder.DropTable(
                name: "WeightLogs");

            migrationBuilder.DropTable(
                name: "CompletedWorkoutExercises");

            migrationBuilder.DropTable(
                name: "CompletedWorkouts");

            migrationBuilder.DropTable(
                name: "WorkoutExercises");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "MuscleGroups");
        }
    }
}
