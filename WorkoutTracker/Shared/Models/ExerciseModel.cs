using WorkoutTracker.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutTracker.Shared.Models
{
    public class ExerciseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EquipmentModel Equipment { get; set; }
        public MuscleGroupModel MuscleGroup { get; set; }
    }
}
