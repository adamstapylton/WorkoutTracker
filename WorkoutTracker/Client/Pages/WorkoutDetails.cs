using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutTracker.Client.Services;
using WorkoutTracker.Shared.Models;

namespace WorkoutTracker.Client.Pages
{
    public partial class WorkoutDetails
    {

        [Inject] public IWorkoutService WorkoutService { get; set; }

        [Inject] public IExerciseService ExerciseService { get; set; }

        [Inject] public IMuscleGroupService MuscleGroupService { get; set; }

        [Inject] public IJSRuntime Js { get; set; }

        [Inject] public NavigationManager Nav { get; set; }

        [Parameter] public int WorkoutId { get; set; }

        [Parameter] public WorkoutExerciseModel ExerciseToDelete { get; set; }

        private WorkoutModel Workout { get; set; }

        public List<WorkoutExerciseModel> WorkoutExercises { get; set; }

        private IEnumerable<ExerciseModel> ExerciseOptions { get; set; }

        public IEnumerable<MuscleGroupModel> MuscleGroups { get; set; }

        private WorkoutExerciseModel ExerciseToAdd = new WorkoutExerciseModel();

        private WorkoutExerciseModel DraggedItem;

        private string Message;

        private string DisplayClass = "d-none";

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Workout = await WorkoutService.GetWorkoutByIdAsync(WorkoutId);
                ExerciseOptions = await ExerciseService.GetExercisesAsync();
                MuscleGroups = await MuscleGroupService.GetMuscleGroupsAsync();
                WorkoutExercises = Workout.WorkoutExercises.OrderBy(we => we.OrderInt).ToList();
            }
            catch (Exception)
            {
                Message = "Workout not found!";
            }

        }

        void ToggleAddExercises()
        {
            if (DisplayClass == "d-none")
            {
                DisplayClass = "";
            }
            else
            {
                DisplayClass = "d-none";
            }
        }

        async Task AddExercise()
        {
            try
            {
                if (Workout.WorkoutExercises.Count() > 0)
                {
                    var lastOrder = Workout.WorkoutExercises.Max(w => w.OrderInt);
                    ExerciseToAdd.OrderInt = lastOrder + 1;
                }
                else
                {
                    ExerciseToAdd.OrderInt = 1;
                }

                var response = await WorkoutService.AddExerciseToWorkoutAsync(Workout.Id, ExerciseToAdd);

                if (response.IsSuccessStatusCode)
                {
                    //Workout = await woService.GetWorkoutByIdAsync(WorkoutId);
                    await OnInitializedAsync();
                    ExerciseToAdd = new WorkoutExerciseModel();
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

        // methods for dragging and dropping the list items

        async Task UpdateWorkout()
        {
            await OnInitializedAsync();
        }

        void UpdateExerciseToDelete(WorkoutExerciseModel exercise)
        {
            ExerciseToDelete = exercise;
        }

        void ItemBeingDragged(WorkoutExerciseModel excercise)
        {
            DraggedItem = excercise;
        }

        async Task ListUpdated(WorkoutExerciseModel exerciseDroppedOn)
        {
            var indexOfStart = WorkoutExercises.FindIndex(e => e.Id == DraggedItem.Id);
            var indexOfDrop = WorkoutExercises.FindIndex(e => e.Id == exerciseDroppedOn.Id);
            WorkoutExercises.RemoveAt((indexOfStart));
            WorkoutExercises.Insert(indexOfDrop, DraggedItem);

            if (indexOfStart != indexOfDrop)
            {
                foreach(var exercise in WorkoutExercises)
                {
                    exercise.OrderInt = (WorkoutExercises.FindIndex(e => e.Id == exercise.Id)) + 1;
                }

                var response = await WorkoutService.UpdateExerciseOrder(WorkoutId, WorkoutExercises);

                if (!response.IsSuccessStatusCode)
                {
                    Message = "Unable to update database";
                }
            }

        }
    }
}
