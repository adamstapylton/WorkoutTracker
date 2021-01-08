using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WorkoutTracker.Shared.Entities
{
    public class CompletedWorkoutExercise
    {
        public int Id { get; set; }
        [Required]
        public Exercise Exercise { get; set; }
        public int ScheduledSets { get; set; }
        public string RepScheme { get; set; }
        public IEnumerable<CompletedSet> Sets { get; set; }

        public int CompletedWorkoutId { get; set; }
        public CompletedWorkout CompletedWorkout { get; set; }
    }
}
