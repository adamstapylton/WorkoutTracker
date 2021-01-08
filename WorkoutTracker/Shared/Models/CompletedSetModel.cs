using System.ComponentModel.DataAnnotations;

namespace WorkoutTracker.Shared.Models
{
    public class CompletedSetModel
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
    }
}