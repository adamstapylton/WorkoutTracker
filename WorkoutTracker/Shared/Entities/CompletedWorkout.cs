using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WorkoutTracker.Shared.Entities
{
    public class CompletedWorkout
    {
        public int Id { get; set; }
        [Required]
        public DateTime DateComplete { get; set; }
        public IEnumerable<CompletedWorkoutExercise> CompletedExercises { get; set; }
        [Required]
        public int WorkoutId { get; set; }
        [Required]
        public string WorkoutName { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }
    }
}
