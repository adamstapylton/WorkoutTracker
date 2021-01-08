using WorkoutTracker.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WorkoutTracker.Shared.Models
{
    public class WorkoutModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public IEnumerable<WorkoutExerciseModel> WorkoutExercises { get; set; }
        public Day Scheduled { get; set; }
    }
}
