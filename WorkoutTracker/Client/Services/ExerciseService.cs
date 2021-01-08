using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WorkoutTracker.Shared.Models;

namespace WorkoutTracker.Client.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly HttpClient http;

        public ExerciseService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<IEnumerable<ExerciseModel>> GetExercisesAsync()
        {
            return await http.GetFromJsonAsync<IEnumerable<ExerciseModel>>("/api/exercises");
        }

        public async Task<ExerciseModel> GetExerciseByIdAsync(int exerciseId)
        {
            return await http.GetFromJsonAsync<ExerciseModel>($"/api/exercises/{exerciseId}");
        }
    }
}
