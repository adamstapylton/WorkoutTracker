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
    public partial class DeleteWorkoutModal
    {
        [Inject]
        public IWorkoutService WorkoutService { get; set; }

        [Inject]
        public IJSRuntime Js { get; set; }

        [Inject]
        public NavigationManager Nav { get; set; }

        [Parameter] public WorkoutModel Workout { get; set; }

        string Message;

        async Task DeleteWorkout()
        {
            var response = await WorkoutService.DeleteWorkoutAsync(Workout);

            if (response.IsSuccessStatusCode)
            {
                await Js.InvokeVoidAsync("closeModal", "#deleteWorkoutModal");
                Nav.NavigateTo("/workouts");
            }
            else
            {
                Message = await response.Content.ReadAsStringAsync();
            }
        }
    }
}
