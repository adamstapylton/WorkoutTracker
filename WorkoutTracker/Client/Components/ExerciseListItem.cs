using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutTracker.Client.Services;
using WorkoutTracker.Shared.Models;

namespace WorkoutTracker.Client.Components
{
    public partial class ExerciseListItem
    {
        [Inject]
        public IWorkoutService WorkoutService { get; set; }

        [Parameter]
        public WorkoutModel Workout { get; set; }

        [Parameter]
        public WorkoutExerciseModel Exercise { get; set; }

        [Parameter]
        public EventCallback<WorkoutExerciseModel> ExerciseToDelete { get; set; }

        [Parameter]
        public EventCallback<WorkoutExerciseModel> DragStarted { get; set; }

        [Parameter]
        public EventCallback<WorkoutExerciseModel> DraggedCallback { get; set; }

        string Message;

        string DragClass = "";

        [Parameter]
        public string Mode { get; set; }

        async Task UpdateExercise()
        {

            var response = await WorkoutService.UpdateExerciseAsync(Workout.Id, Exercise);

            if (!response.IsSuccessStatusCode)
            {
                Message = await response.Content.ReadAsStringAsync();
            }
        }


        async Task DeleteExercise()
        {
            await ExerciseToDelete.InvokeAsync(Exercise);
        }

       // Dragging Methods - on drag start this will callback to the parent component to let it know which child component is being dragged

       //then it 

       async Task DragStart()
        {
            await DragStarted.InvokeAsync(Exercise);
            DragClass = "dragging";
        }

        async Task Drop()
        {
            await DraggedCallback.InvokeAsync(Exercise);
        }

        void StopDrag()
        {
            DragClass = "";
        }
    }
}
