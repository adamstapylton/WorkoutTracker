using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WorkoutTracker.Shared.Models;

namespace WorkoutTracker.Client.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly HttpClient http;

        public WorkoutService(HttpClient http)
        {
            this.http = http;
        }
        public async Task<HttpResponseMessage> AddWorkoutAsync(WorkoutModel workout)
        {
            return await http.PostAsJsonAsync("/api/workouts", workout);
        }

        public async Task<HttpResponseMessage> DeleteWorkoutAsync(WorkoutModel workout)
        {
            return await http.DeleteAsync($"/api/workouts/{workout.Id}");
        }

        public async Task<WorkoutModel> GetWorkoutByIdAsync(int workoutId)
        {
            return await http.GetFromJsonAsync<WorkoutModel>($"/api/workouts/{workoutId}");
        }

        public async Task<IEnumerable<WorkoutModel>> GetWorkoutsAsync()
        {
            return await http.GetFromJsonAsync<IEnumerable<WorkoutModel>>("/api/workouts");
        }

        public Task<HttpResponseMessage> UpdateWorkoutAsync(WorkoutModel workout)
        {
            throw new NotImplementedException();
        }

        // workout exercise services

        public async Task<HttpResponseMessage> AddExerciseToWorkoutAsync(int workoutId, WorkoutExerciseModel exercise)
        {
            return await http.PostAsJsonAsync($"/api/workouts/{workoutId}/exercises", exercise);
        }

        public async Task<HttpResponseMessage> UpdateExerciseAsync(int workoutId, WorkoutExerciseModel exercise)
        {
            return await http.PutAsJsonAsync($"/api/workouts/{workoutId}/exercises/{exercise.Id}", exercise);
        }

        public async Task<HttpResponseMessage> RemoveExerciseAsync(int workoutId, WorkoutExerciseModel exercise)
        {
            return await http.DeleteAsync($"/api/workouts/{workoutId}/exercises/{exercise.Id}");
        }

        public async Task<HttpResponseMessage> UpdateExerciseOrder(int workoutId, IEnumerable<WorkoutExerciseModel> exercises)
        {
            return await http.PutAsJsonAsync($"/api/workouts/{workoutId}/exercises", exercises);
        }
    }
}
