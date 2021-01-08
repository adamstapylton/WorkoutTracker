using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutTracker.Client.Services;
using WorkoutTracker.Shared.Models;

namespace WorkoutTracker.Client.Pages
{
    public partial class RecordWorkout
    {

        [Inject]
        public IWorkoutService WorkoutService { get; set; }

        [Inject]
        public ICompletedWorkoutService CompletedWorkoutService { get; set; }

        [Inject]
        public NavigationManager Nav { get; set; }

        [Parameter]
        public int WorkoutId { get; set; }

        private int ApiFinished = 0;

        private string Message;

        private WorkoutModel Workout { get; set; }

        private CompletedWorkoutModel CompletedWorkout = new CompletedWorkoutModel();

        private List<CompletedWorkoutExerciseModel> CompletedExercises = new List<CompletedWorkoutExerciseModel>();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Workout = await WorkoutService.GetWorkoutByIdAsync(WorkoutId);
                CompletedWorkout.WorkoutId = WorkoutId;
                CompletedWorkout.WorkoutName = Workout.Name;

                // creating a new CompletedWorkoutExercise for each WorkoutExercise

                foreach (var exercise in Workout.WorkoutExercises)
                {
                    var exerciseToAdd = new CompletedWorkoutExerciseModel
                    {
                        Exercise = exercise.Exercise,
                        ScheduledSets = exercise.Sets,
                        RepScheme = exercise.RepScheme
                    };

                    // add the correct number of sets as per the WorkoutExercise
                    var setsToAdd = new List<CompletedSetModel>();

                    // if WorkoutExercise.Sets is 0 we need at least one set to appear
                    if (exercise.Sets < 1)
                    {
                        var set = new CompletedSetModel
                        {
                            SetNumber = 1,
                            Weight = 0,
                            Reps = 0
                        };

                        setsToAdd.Add(set);
                    }
                    else
                    {
                        for (int i = 0; i < exercise.Sets; i++)
                        {
                            var set = new CompletedSetModel
                            {
                                SetNumber = i + 1,
                                Weight = 0,
                                Reps = 0
                            };

                            setsToAdd.Add(set);
                        }
                    }

                    exerciseToAdd.Sets = setsToAdd;
                    CompletedExercises.Add(exerciseToAdd);
                }

                CompletedWorkout.CompletedExercises = CompletedExercises;
            }
            catch (Exception)
            {

                throw;
            }

            ApiFinished = 1;
        }

        private async Task SaveWorkout()
        {
            try
            {
                var response = await CompletedWorkoutService.AddCompletedWorkoutAsync(CompletedWorkout);

                if (response.IsSuccessStatusCode)
                {
                    Nav.NavigateTo("/completedworkouts");
                    //var returnedCompletedWorkout = await response.Content.ReadFromJsonAsync<CompletedWorkoutModel>();

                    //foreach (var exercise in CompletedExercises)
                    //{
                    //    exercise.CompletedWorkoutId = returnedCompletedWorkout.Id;
                    //}

                    //await AddExercisesToWorkout(returnedCompletedWorkout.Id);
                }
                else
                {
                    Message = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //private async Task AddExercisesToWorkout(int completedWorkoutId)
        //{

        //    var response = await cwService.AddCompletedExercisesToWorkoutAsync(completedWorkoutId, CompletedExercises);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        nav.NavigateTo("/completedworkouts");
        //    }
        //    else
        //    {
        //        Message = await response.Content.ReadAsStringAsync();
        //    }
        //}
    }
}
