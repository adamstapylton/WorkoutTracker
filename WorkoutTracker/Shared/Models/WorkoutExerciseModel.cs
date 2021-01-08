using WorkoutTracker.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WorkoutTracker.Shared.Models
{
    public class WorkoutExerciseModel
    {
        public int Id { get; set; }
        [Required]
        public int OrderInt { get; set; }
        [MaxLength(4)]
        public string OrderString { get; set; }
        [Required]
        public int ExerciseId { get; set; }
        public ExerciseModel Exercise { get; set; }
        [Range(0, 999)]
        public int Sets { get; set; }
        public string RepScheme { get; set; }
        public string Rest { get; set; }
        public string Notes { get; set; }
    }
}
