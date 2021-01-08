using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WorkoutTracker.Shared.Models
{
    public class CompletedWorkoutModel
    {
        public int Id { get; set; }
        [Required]
        public DateTime DateComplete { get; set; }
        public IEnumerable<CompletedWorkoutExerciseModel> CompletedExercises { get; set; }
        [Required]
        public int WorkoutId { get; set; }
        [Required]
        public string WorkoutName { get; set; }
    }
}
