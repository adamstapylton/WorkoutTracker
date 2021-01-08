using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutTracker.Shared.Entities;

namespace WorkoutTracker.Server.Data.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly ApplicationDbContext db;

        public WorkoutRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Workout> AddWorkoutAsync(Workout workout)
        {
            await db.AddAsync(workout);
            return workout;
        }

        public async Task<bool> CommitAsync()
        {
            return (await db.SaveChangesAsync()) > 0;
        }

        public async Task DeleteWorkoutAsync(string userId, int workoutId)
        {
            var workout = await db.Workouts.Where(w => w.Id == workoutId && w.ApplicationUserId == userId).FirstOrDefaultAsync();
            db.Remove(workout);
        }

        public async Task<Workout> GetWorkoutByIdAsync(string userId, int workoutId)
        {
            var workout = db.Workouts.Where(w => w.ApplicationUserId == userId && w.Id == workoutId)
                .Include(w => w.WorkoutExercises)
                    .ThenInclude(we => we.Exercise)
                        .ThenInclude(ex => ex.MuscleGroup)
                .Include(w => w.WorkoutExercises)
                    .ThenInclude(we => we.Exercise)
                        .ThenInclude(ex => ex.Equipment);

            return await workout.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Workout>> GetWorkoutsAsync(string userId)
        {
            var workouts = db.Workouts.Where(w => w.ApplicationUserId == userId);
            return await workouts.ToListAsync();
        }


        // WorkoutExercises

        public async Task<WorkoutExercise> AddExerciseAsync(int workoutId, WorkoutExercise exercise)
        {
            exercise.WorkoutId = workoutId;
            await db.WorkoutExercises.AddAsync(exercise);
            return exercise;
        }

        public async Task RemoveExerciseAsync(int workoutId, int exerciseId)
        {
            var workout = await db.Workouts.Where(wo => wo.Id == workoutId).FirstOrDefaultAsync();
            var exercise = workout.WorkoutExercises.Where(we => we.Id == exerciseId).FirstOrDefault();
            db.Remove(exercise);
        }
    }
}
