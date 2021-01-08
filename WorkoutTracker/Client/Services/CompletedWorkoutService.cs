using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using WorkoutTracker.Shared.Models;

namespace WorkoutTracker.Client.Services
{
    public class CompletedWorkoutService : ICompletedWorkoutService
    {
        private readonly HttpClient http;

        public CompletedWorkoutService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<HttpResponseMessage> AddCompletedExercisesToWorkoutAsync(int completedWorkoutId, IEnumerable<CompletedWorkoutExerciseModel> completedWorkoutExerciseModels)
        {
            return await http.PostAsJsonAsync($"/api/completedworkouts/{completedWorkoutId}/", completedWorkoutExerciseModels);
        }

        public async Task<HttpResponseMessage> AddCompletedWorkoutAsync(CompletedWorkoutModel completedWorkout)
        {
            return await http.PostAsJsonAsync("/api/completedworkouts/", completedWorkout);

        }

        public Task<CompletedWorkoutExerciseModel> GetCompletedExerciseByIdAsync(int completedWorkoutId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CompletedWorkoutExerciseModel>> GetCompletedExercisesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CompletedWorkoutModel>> GetCompletedWorkoutsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
