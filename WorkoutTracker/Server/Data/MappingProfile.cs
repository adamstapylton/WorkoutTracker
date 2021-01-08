using AutoMapper;
using WorkoutTracker.Shared.Entities;
using WorkoutTracker.Shared.Models;

namespace WorkoutTracker.Server.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WeightLog, WeightLogModel>().ReverseMap();
            CreateMap<WeightLogModel, WeightLogModel>();
            CreateMap<Workout, WorkoutModel>().ReverseMap();

            CreateMap<WorkoutModel, WorkoutModel>();


            CreateMap<WorkoutExercise, WorkoutExerciseModel>().ReverseMap();

            CreateMap<WorkoutExerciseModel, WorkoutExerciseModel>();

            CreateMap<Exercise, ExerciseModel>().ReverseMap();

            CreateMap<ExerciseModel, ExerciseModel>();

            CreateMap<MuscleGroup, MuscleGroupModel>().ReverseMap();
            CreateMap<Equipment, EquipmentModel>().ReverseMap();

            CreateMap<CompletedWorkout, CompletedWorkoutModel>().ReverseMap();
            CreateMap<CompletedWorkoutExercise, CompletedWorkoutExerciseModel>().ReverseMap();
            CreateMap<CompletedSet, CompletedSetModel>().ReverseMap();
        }
    }
}
