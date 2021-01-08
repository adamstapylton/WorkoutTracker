using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutTracker.Shared.Entities;

namespace WorkoutTracker.Server.Data.Repositories
{
    public interface IMuscleGroupRespository
    {
        Task<IEnumerable<MuscleGroup>> GetMuscleGroupsAsync();
    }
}
