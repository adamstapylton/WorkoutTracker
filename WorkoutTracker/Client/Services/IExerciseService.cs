using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutTracker.Shared.Models;

namespace WorkoutTracker.Client.Services
{
    public interface IExerciseService
    {
        Task<IEnumerable<ExerciseModel>> GetExercisesAsync();
        Task<ExerciseModel> GetExerciseByIdAsync(int exerciseId);
    }
}
