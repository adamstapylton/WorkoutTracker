using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WorkoutTracker.Shared.Models;

namespace WorkoutTracker.Client.Services
{
    public interface IWorkoutService
    {
        Task<IEnumerable<WorkoutModel>> GetWorkoutsAsync();
        Task<WorkoutModel> GetWorkoutByIdAsync(int workoutId);
        Task<HttpResponseMessage> AddWorkoutAsync(WorkoutModel workout);
        Task<HttpResponseMessage> UpdateWorkoutAsync(WorkoutModel workout);
        Task<HttpResponseMessage> DeleteWorkoutAsync(WorkoutModel workout);

        // workout exercise services
        Task<HttpResponseMessage> AddExerciseToWorkoutAsync(int workoutId, WorkoutExerciseModel exercise);
        Task<HttpResponseMessage> UpdateExerciseAsync(int workoutId, WorkoutExerciseModel exercise);
        Task<HttpResponseMessage> RemoveExerciseAsync(int workoutId, WorkoutExerciseModel exercise);
        Task<HttpResponseMessage> UpdateExerciseOrder(int workoutId, IEnumerable<WorkoutExerciseModel> exercises);
    }
}
