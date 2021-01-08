using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutTracker.Server.Models;
using WorkoutTracker.Shared.Entities;

namespace WorkoutTracker.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<WeightLog> WeightLogs { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<MuscleGroup> MuscleGroups { get; set; }
        public DbSet<CompletedWorkout> CompletedWorkouts { get; set; }
        public DbSet<CompletedWorkoutExercise> CompletedWorkoutExercises { get; set; }
        public DbSet<CompletedSet> CompletedSets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var muscleGroups = new MuscleGroup[]
            {
                new MuscleGroup { Id = 1, Name = "Abs" },
                new MuscleGroup { Id = 2, Name = "Biceps" },
                new MuscleGroup { Id = 3, Name = "Calves" },
                new MuscleGroup { Id = 4, Name = "Chest" },
                new MuscleGroup { Id = 5, Name = "Forearms" },
                new MuscleGroup { Id = 6, Name = "Glutes" },
                new MuscleGroup { Id = 7, Name = "Hamstrings" },
                new MuscleGroup { Id = 8, Name = "Lats" },
                new MuscleGroup { Id = 9, Name = "Quads" },
                new MuscleGroup { Id = 10, Name = "Shoulders (Front)" },
                new MuscleGroup { Id = 11, Name = "Shoulders (Rear)" },
                new MuscleGroup { Id = 12, Name = "Shoulders (Side)" },
                new MuscleGroup { Id = 13, Name = "Traps" },
                new MuscleGroup { Id = 14, Name = "Triceps" },
                new MuscleGroup { Id = 15, Name = "Upper Back" },
                new MuscleGroup { Id = 16, Name = "Cardio (Steady State)" },
                new MuscleGroup { Id = 17, Name = "Cardio (HIIT)" }
            };

            var equipment = new Equipment[]
            {
                new Equipment { Id = 1, Name = "Barbell"},
                new Equipment { Id = 2, Name = "Dumbbell"},
                new Equipment { Id = 3, Name = "BodyWeight"},
                new Equipment { Id = 4, Name = "Plate Loaded Machine"},
                new Equipment { Id = 5, Name = "Weight Stack Machine"},
                new Equipment { Id = 6, Name = "Smith Machine"},
                new Equipment { Id = 7, Name = "Cable Machine"},
                new Equipment { Id = 8, Name = "Kettlebell"}

            };

            var exercises = new Exercise[]
            {
                new Exercise {Id = 1, Name = "High Bar Back Squat", EquipmentId = 1, MuscleGroupId = 9 },
                new Exercise {Id = 2, Name = "Low Bar Back Squat", EquipmentId = 1, MuscleGroupId = 9},
                new Exercise {Id = 3, Name = "Front Squat", EquipmentId = 1, MuscleGroupId = 9},
                new Exercise {Id = 4, Name = "Leg Press", EquipmentId = 4, MuscleGroupId = 9},
                new Exercise {Id = 5, Name = "Hack Squat", EquipmentId = 4, MuscleGroupId = 9},
                new Exercise {Id = 6, Name = "Smith Machine Squat", EquipmentId = 6, MuscleGroupId = 9},
                new Exercise {Id = 7, Name = "Bulgarian Split Squat", EquipmentId = 2 , MuscleGroupId = 9},
                new Exercise {Id = 8, Name = "Bench Press", EquipmentId =1, MuscleGroupId = 4},
                new Exercise {Id = 9, Name = "Incline Bench Press", EquipmentId = 1, MuscleGroupId = 4 },
                new Exercise {Id = 10, Name = "Decline Bench Press", EquipmentId =1 , MuscleGroupId = 4 },
                new Exercise {Id = 11, Name = "Dumbbell Incline Bench Press", EquipmentId = 2, MuscleGroupId = 4},
                new Exercise {Id = 12, Name = "Dumbbell Flat Bench Press", EquipmentId = 2, MuscleGroupId = 4},
                new Exercise {Id = 13, Name = "Dumbbell Decline Bench Press", EquipmentId = 2, MuscleGroupId = 4},
                new Exercise {Id = 14, Name = "Plate Loaded Chest Press", EquipmentId = 4, MuscleGroupId = 4},
                new Exercise {Id = 15, Name = "Plate Loaded Incline Chest Press", EquipmentId = 4, MuscleGroupId = 4},
                new Exercise {Id = 16, Name = "Plate Loaded Decline Chest Press", EquipmentId = 4, MuscleGroupId = 4},
                new Exercise {Id = 17, Name = "Weight Stack Decline Chest Press", EquipmentId = 5, MuscleGroupId = 4},
                new Exercise {Id = 18, Name = "Weight Stack Chest Press", EquipmentId = 5, MuscleGroupId = 4},
                new Exercise {Id = 19, Name = "Weight Stack Incline Chest Press", EquipmentId = 5, MuscleGroupId = 4},
                new Exercise {Id = 20, Name = "Pec Dec", EquipmentId = 5, MuscleGroupId = 4},
                new Exercise {Id = 21, Name = "Cable Flies", EquipmentId = 7, MuscleGroupId = 4},
                new Exercise {Id = 22, Name = "Cable Flies (Upper Chest)", EquipmentId = 7, MuscleGroupId = 4},
                new Exercise {Id = 23, Name = "Pushups", EquipmentId = 3, MuscleGroupId = 4},
                new Exercise {Id = 24, Name = "Feet Elevated Pushups", EquipmentId = 3, MuscleGroupId = 4},
                new Exercise {Id = 25, Name = "Hands Elevated Pushups", EquipmentId = 3, MuscleGroupId = 4},
                new Exercise {Id = 26, Name = "Dips", EquipmentId =3, MuscleGroupId = 4},
                new Exercise {Id = 27, Name = "Pullups", EquipmentId = 3, MuscleGroupId = 8},
                new Exercise {Id = 28, Name = "Chinups", EquipmentId = 3, MuscleGroupId = 8},
                new Exercise {Id = 29, Name = "Neutral Grip Chinups", EquipmentId = 3, MuscleGroupId = 8},
                new Exercise {Id = 30, Name = "Neutral Grip Lat Pulldown", EquipmentId = 5, MuscleGroupId = 8},
                new Exercise {Id = 31, Name = "Overhand Lat Pulldown", EquipmentId = 5, MuscleGroupId = 8},
                new Exercise {Id = 32, Name = "Underhand Lat Pulldown", EquipmentId = 5, MuscleGroupId = 8},
                new Exercise {Id = 33, Name = "Bent Over Barbell Row", EquipmentId = 1, MuscleGroupId = 15},
                new Exercise {Id = 34, Name = "Seated Cable Row", EquipmentId = 5, MuscleGroupId = 15},
                new Exercise {Id = 35, Name = "Chest Supported Dumbbell Row", EquipmentId = 2, MuscleGroupId = 15},
                new Exercise {Id = 36, Name = "1 Arm Dumbbell Row", EquipmentId = 2, MuscleGroupId = 15},
                new Exercise {Id = 37, Name = "Plate Loaded High Row", EquipmentId = 4, MuscleGroupId = 15},
                new Exercise {Id = 38, Name = "Plate Loaded Low Row", EquipmentId = 4, MuscleGroupId = 15},
                new Exercise {Id = 39, Name = "Plate Loaded Lat Pulldown", EquipmentId = 4, MuscleGroupId = 8},
                new Exercise {Id = 40, Name = "Weight Stack Lat Pulldown", EquipmentId = 5, MuscleGroupId = 8},
                new Exercise {Id = 41, Name = "Weight Stack Chest Supported Row", EquipmentId =5, MuscleGroupId = 15},
                new Exercise {Id = 42, Name = "Romanian Deadlift", EquipmentId= 1, MuscleGroupId = 7},
                new Exercise {Id = 43, Name = "Deadlift", EquipmentId = 1, MuscleGroupId = 7},
                new Exercise {Id = 44, Name = "Stiff Legged Deadlift", EquipmentId = 1, MuscleGroupId = 7},
                new Exercise {Id = 45, Name = "Sumo Deadlift", EquipmentId = 1, MuscleGroupId = 7},
                new Exercise {Id = 46, Name = "Deficit Deadlift", EquipmentId = 1, MuscleGroupId = 7},
                new Exercise {Id = 47, Name = "Dumbell Romanian Deadlift", EquipmentId = 2, MuscleGroupId = 7},
                new Exercise {Id = 48, Name = "Dumbell Stiff Legged Deadlift", EquipmentId = 2, MuscleGroupId = 7},
                new Exercise {Id = 49, Name = "Dumbell Sumo Deadlift", EquipmentId = 2, MuscleGroupId = 7},
                new Exercise {Id = 50, Name = "Laying Leg Curl", EquipmentId = 5, MuscleGroupId = 7},
                new Exercise {Id = 51, Name = "Standing Leg Curl", EquipmentId = 5, MuscleGroupId = 7},
                new Exercise {Id = 52, Name = "Seated Leg Curl", EquipmentId = 5, MuscleGroupId = 7},
                new Exercise {Id = 53, Name = "Barbell Shoulder Press (Standing)", EquipmentId = 1, MuscleGroupId = 10},
                new Exercise {Id = 54, Name = "Barbell Shoulder Press (Seated)", EquipmentId = 1, MuscleGroupId = 10},
                new Exercise {Id = 55, Name = "Dumbbell Shoulder Press (Seated)", EquipmentId = 2, MuscleGroupId = 10},
                new Exercise {Id = 56, Name = "Dumbbell Shoulder Press (Standing)", EquipmentId = 2, MuscleGroupId = 10},
                new Exercise {Id = 57, Name = "Arnold Press (Standing)", EquipmentId = 2, MuscleGroupId = 10},
                new Exercise {Id = 58, Name = "Arnold Press (Seated)", EquipmentId = 2, MuscleGroupId = 10},
                new Exercise {Id = 59, Name = "Plate Loaded Shoulder Press", EquipmentId =4, MuscleGroupId = 10},
                new Exercise {Id = 60, Name = "Weight Stack Shoulder Press", EquipmentId = 5, MuscleGroupId = 10},
                new Exercise {Id = 61, Name = "Dumbbell Lateral Raises", EquipmentId =2, MuscleGroupId = 12},
                new Exercise {Id = 62, Name = "Cable Lateral Raises", EquipmentId = 7, MuscleGroupId = 12},
                new Exercise {Id = 63, Name = "Cable Lateral Raises (1 Arm)", EquipmentId = 7, MuscleGroupId = 12},
                new Exercise {Id = 64, Name = "Dumbbell Front Raise", EquipmentId = 2, MuscleGroupId = 10},
                new Exercise {Id = 65, Name = "Cable Front Raise", EquipmentId = 7, MuscleGroupId = 10},
                new Exercise {Id = 66, Name = "Dumbbell Rear Delt Flies", EquipmentId = 2, MuscleGroupId = 11},
                new Exercise {Id = 67, Name = "Cable Rear Delt Flies", EquipmentId = 7, MuscleGroupId = 11},
                new Exercise {Id = 68, Name = "Reverse Pec Dec", EquipmentId = 5, MuscleGroupId = 11},
                new Exercise {Id = 69, Name = "Barbell Upright Row (Wide Grip)", EquipmentId = 1, MuscleGroupId = 12},
                new Exercise {Id = 70, Name = "Barbell Upright Row (Close Grip)", EquipmentId = 1, MuscleGroupId = 12},
                new Exercise {Id = 71, Name = "Cable Upright Row (Close Grip)", EquipmentId = 7, MuscleGroupId = 12},
                new Exercise {Id = 72, Name = "Cable Upright Row (Wide Grip)", EquipmentId = 7, MuscleGroupId = 12}


            };

            builder.Entity<Equipment>().HasData(equipment);
            builder.Entity<MuscleGroup>().HasData(muscleGroups);
            builder.Entity<Exercise>().HasData(exercises);


        }
    }
}
