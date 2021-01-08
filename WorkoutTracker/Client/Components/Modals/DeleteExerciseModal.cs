using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutTracker.Client.Services;
using WorkoutTracker.Shared.Models;

namespace WorkoutTracker.Client.Components.Modals
{
    public partial class DeleteExerciseModal
    {
        [Inject]
        public IWorkoutService WorkoutService { get; set; }

        [Inject]
        public IJSRuntime Js { get; set; }

        [Parameter]
        public WorkoutModel Workout { get; set; }

        [Parameter]
        public WorkoutExerciseModel Exercise { get; set; }

        [Parameter]
        public EventCallback<bool> ExerciseRemoved { get; set; }

        string Message;

        private async Task RemoveExercise()
        {
            try
            {
                var response = await WorkoutService.RemoveExerciseAsync(Workout.Id, Exercise);

                if (response.IsSuccessStatusCode)
                {
                    await ExerciseRemoved.InvokeAsync(true);
                    await Js.InvokeVoidAsync("closeModal", "#deleteExerciseModal");
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
    }
}
