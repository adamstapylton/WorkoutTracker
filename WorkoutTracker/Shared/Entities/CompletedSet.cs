using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WorkoutTracker.Shared.Entities
{
    public class CompletedSet
    {
        public int Id { get; set; }
        [Required]
        [Range(0, 100)]
        public int SetNumber { get; set; }
        [Required]
        [Range(0, 9999)]
        public int Weight { get; set; }
        [Required]
        [Range(0, 9999)]
        public int Reps { get; set; }

        public int CompletedWorkoutExerciseId { get; set; }
        public CompletedWorkoutExercise CompletedWorkoutExercise { get; set; }
    }
}
