using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutTracker.Shared.Entities;

namespace WorkoutTracker.Server.Data.Repositories
{
    public interface ICompletedWorkoutRepository
    {
        Task<IEnumerable<CompletedWorkout>> GetCompletedWorkoutsAsync(string userId);
        Task<CompletedWorkout> GetCompletedWorkoutByIdAsync(string userId, int completedWorkoutId);
        Task<IEnumerable<CompletedWorkout>> GetCompletedWorkoutsByWorkoutIdAsync(string userId, int workoutId);
        Task<CompletedWorkout> AddCompletedWorkoutAsync(CompletedWorkout completedWorkout);
        Task DeleteCompletedWorkoutAsync(int completedWorkoutId);
        Task<bool> CommitAsync();
    }
}
