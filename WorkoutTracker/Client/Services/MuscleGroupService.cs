using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WorkoutTracker.Shared.Models;

namespace WorkoutTracker.Client.Services
{
    public class MuscleGroupService : IMuscleGroupService
    {
        private readonly HttpClient http;

        public MuscleGroupService(HttpClient http)
        {
            this.http = http;
        }
        public async Task<IEnumerable<MuscleGroupModel>> GetMuscleGroupsAsync()
        {
            return await http.GetFromJsonAsync<IEnumerable<MuscleGroupModel>>("/api/musclegroups");
        }
    }
}
