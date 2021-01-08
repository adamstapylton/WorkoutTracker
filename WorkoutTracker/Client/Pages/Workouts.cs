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
    public partial class Workouts 
    {
        [Inject]
        private IJSRuntime Js { get; set; }

        [Inject]
        private IWorkoutService WorkoutService { get; set; }

        private IEnumerable<WorkoutModel> WorkoutList;

        private WorkoutModel NewWorkout = new WorkoutModel();

        private string Message;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                WorkoutList = await WorkoutService.GetWorkoutsAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        async Task AddWorkout()
        {
            var response = await WorkoutService.AddWorkoutAsync(NewWorkout);

            if (response.IsSuccessStatusCode)
            {
                WorkoutList = await WorkoutService.GetWorkoutsAsync();
                await Js.InvokeVoidAsync("closeModal", "#addWorkoutModal");
                NewWorkout = new WorkoutModel();
            }
            else
            {
                Message = await response.Content.ReadAsStringAsync();
            }
        }

        void RemoveMessage()
        {
            Message = null;
        }
    }
}


 