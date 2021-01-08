using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WorkoutTracker.Shared.Entities
{
    class WeightTarget
    {
        public int Id { get; set; }
        [Column(TypeName="Date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime TargetDate { get; set; }
        [Required]
        [Range(0, 999)]
        public double StartWeight { get; set; }
        [Required]
        [Range(0, 999)]
        public double TargetWeight { get; set; }

        public string ApplicationUserId { get; set; }
    }
}
