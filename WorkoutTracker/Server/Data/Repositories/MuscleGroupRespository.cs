using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkoutTracker.Shared.Entities;

namespace WorkoutTracker.Server.Data.Repositories
{
    public class MuscleGroupRespository : IMuscleGroupRespository
    {
        private readonly ApplicationDbContext db;

        public MuscleGroupRespository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<MuscleGroup>> GetMuscleGroupsAsync()
        {
            return await db.MuscleGroups.ToListAsync();
        }
    }
}
