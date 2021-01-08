using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WorkoutTracker.Shared.Models
{
    public class WeightLogModel
    {
        public int Id { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

    }
}
