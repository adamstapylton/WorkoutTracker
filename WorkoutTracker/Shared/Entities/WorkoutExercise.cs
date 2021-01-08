using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorkoutTracker.Shared.Entities
{
    public class WorkoutExercise
    {
        public int Id { get; set; }
        [Required]
        public int OrderInt { get; set; }
        [MaxLength(4)]
        public string OrderString { get; set; }
        [Required]
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        [Range(0, 100)]
        public int Sets { get; set; }
        public string RepScheme { get; set; }
        public string Rest { get; set; }
        public string Notes { get; set; }

        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }
    }
}
