using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutTracker.Shared.Entities;

namespace WorkoutTracker.Server.Data.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly ApplicationDbContext db;

        public ExerciseRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<Exercise> GetExerciseByIdAsync(int exerciseId)
        {
            return await db.Exercises
                .Where(ex => ex.Id == exerciseId)
                .Include(ex => ex.Equipment)
                .Include(ex => ex.MuscleGroup)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Exercise>> GetExercisesAsync()
        {
            return await db.Exercises
                  .Include(ex => ex.Equipment)
                  .Include(ex => ex.MuscleGroup)
                  .ToListAsync();

        }
    }
}
