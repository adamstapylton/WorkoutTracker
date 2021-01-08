using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorkoutTracker.Shared.Models
{
    public class CompletedWorkoutExerciseModel
    {
        public int Id { get; set; }
        [Required]
        public ExerciseModel Exercise { get; set; }
        public int ScheduledSets { get; set; }
        public string RepScheme { get; set; }
        public IEnumerable<CompletedSetModel> Sets { get; set; }

        public int CompletedWorkoutId { get; set; }
    }
}