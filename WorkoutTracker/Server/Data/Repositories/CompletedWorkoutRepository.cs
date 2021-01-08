using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutTracker.Shared.Entities;

namespace WorkoutTracker.Server.Data.Repositories
{
    public class CompletedWorkoutRepository : ICompletedWorkoutRepository
    {
        private readonly ApplicationDbContext db;

        public CompletedWorkoutRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<CompletedWorkout> AddCompletedWorkoutAsync(CompletedWorkout completedWorkout)
        {
            await db.AddAsync(completedWorkout);
            return completedWorkout;
        }

        public async Task DeleteCompletedWorkoutAsync(int completedWorkoutId)
        {
            var completedWorkoutToRemove = await db.CompletedWorkouts.Where(cw => cw.Id == completedWorkoutId).FirstOrDefaultAsync();
            db.Remove(completedWorkoutToRemove);
        }

        public async Task<CompletedWorkout> GetCompletedWorkoutByIdAsync(string userId, int completedWorkoutId)
        {
            return await db.CompletedWorkouts
                .Where(cw => cw.ApplicationUserId == userId && cw.Id == completedWorkoutId)
                .Include(cw => cw.CompletedExercises)
                .ThenInclude(ce => ce.Sets)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CompletedWorkout>> GetCompletedWorkoutsAsync(string userId)
        {
            return await db.CompletedWorkouts
                .Where(cw => cw.ApplicationUserId == userId)
                .Include(cw => cw.CompletedExercises)
                .ThenInclude(ce => ce.Sets)
                .ToListAsync();
        }

        public async Task<IEnumerable<CompletedWorkout>> GetCompletedWorkoutsByWorkoutIdAsync(string userId, int workoutId)
        {
            return await db.CompletedWorkouts
                .Where(cw => cw.ApplicationUserId == userId && cw.WorkoutId == workoutId)
                .Include(cw => cw.CompletedExercises)
                .ThenInclude(ce => ce.Sets)
                .ToListAsync();
        }

        public async Task<bool> CommitAsync()
        {
            return (await db.SaveChangesAsync()) > 0;
        }
    }
}
