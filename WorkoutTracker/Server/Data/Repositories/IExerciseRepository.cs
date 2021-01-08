using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkoutTracker.Shared.Entities;

namespace WorkoutTracker.Server.Data.Repositories
{
    public interface IExerciseRepository
    {
        Task<IEnumerable<Exercise>> GetExercisesAsync();
        Task<Exercise> GetExerciseByIdAsync(int exerciseId);
    }
}
