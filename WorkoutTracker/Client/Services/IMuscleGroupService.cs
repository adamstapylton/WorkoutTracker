using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutTracker.Shared.Models;

namespace WorkoutTracker.Client.Services
{
    public interface IMuscleGroupService
    {
        Task<IEnumerable<MuscleGroupModel>> GetMuscleGroupsAsync();
    }
}
