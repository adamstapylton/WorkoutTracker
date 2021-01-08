using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WorkoutTracker.Shared.Entities
{
    public class WeightLog
    {
        
        public int Id { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        [Column(TypeName="Date")]
        public DateTime Date { get; set; }
        [Required]
        public string ApplicationUserId { get; set; }


    }
}
