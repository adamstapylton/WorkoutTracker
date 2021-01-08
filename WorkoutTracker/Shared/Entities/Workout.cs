using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorkoutTracker.Shared.Entities
{
    public class Workout
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public IEnumerable<WorkoutExercise> WorkoutExercises { get; set; }
        public Day Scheduled { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }
    }
}
