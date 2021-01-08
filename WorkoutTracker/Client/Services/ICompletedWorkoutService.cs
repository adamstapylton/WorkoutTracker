using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WorkoutTracker.Shared.Models;

namespace WorkoutTracker.Client.Services
{
    public interface ICompletedWorkoutService
    {
        Task<IEnumerable<CompletedWorkoutModel>> GetCompletedWorkoutsAsync();
        Task<HttpResponseMessage> AddCompletedWorkoutAsync(CompletedWorkoutModel completedWorkout);

        // Services for Workout Exercises
        Task<IEnumerable<CompletedWorkoutExerciseModel>> GetCompletedExercisesAsync();
        Task<CompletedWorkoutExerciseModel> GetCompletedExerciseByIdAsync(int completedWorkoutId);
        Task<HttpResponseMessage> AddCompletedExercisesToWorkoutAsync(int completedWorkoutId, IEnumerable<CompletedWorkoutExerciseModel> completedWorkoutExercises);
    }
}
