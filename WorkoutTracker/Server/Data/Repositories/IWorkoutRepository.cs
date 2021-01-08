using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutTracker.Shared.Entities;

namespace WorkoutTracker.Server.Data.Repositories
{
    public interface IWorkoutRepository
    {
        Task<IEnumerable<Workout>> GetWorkoutsAsync(string userId);
        Task<Workout> GetWorkoutByIdAsync(string userId, int workoutId);
        Task<Workout> AddWorkoutAsync(Workout workout);
        Task DeleteWorkoutAsync(string userId, int workoutId);
        Task<WorkoutExercise> AddExerciseAsync(int workoutId, WorkoutExercise exercise);
        Task RemoveExerciseAsync(int workoutId, int exerciseId);
        Task<bool> CommitAsync();
    }
}
