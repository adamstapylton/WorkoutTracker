using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkoutTracker.Shared.Entities
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Equipment")]
        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }

        [ForeignKey("MuscleGroup")]
        public int MuscleGroupId { get; set; }
        public MuscleGroup MuscleGroup { get; set; }
    }
}
