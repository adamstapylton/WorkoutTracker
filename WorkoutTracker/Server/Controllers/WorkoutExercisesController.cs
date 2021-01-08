using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutTracker.API.Data;
using WorkoutTracker.Server.Data.Repositories;
using WorkoutTracker.Shared.Entities;
using WorkoutTracker.Shared.Models;

namespace WorkoutTracker.Server.Controllers
{
    [Route("api/workouts/{workoutId:int}/exercises")]
    [ApiController]
    public class WorkoutExercisesController : ControllerBase
    {
        private readonly IWorkoutRepository workoutRepository;
        private readonly IMapper mapper;

        public WorkoutExercisesController(IWorkoutRepository workoutRepository, IMapper mapper)
        {
            this.workoutRepository = workoutRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(int workoutId, WorkoutExerciseModel exerciseModel)
        {
            try
            {
                var userId = User.GetUserId();

                var workout = await workoutRepository.GetWorkoutByIdAsync(userId, workoutId);

                if (workout == null)
                {
                    return NotFound("No workout was found");
                }

                var exercise = mapper.Map<WorkoutExercise>(exerciseModel);

                await workoutRepository.AddExerciseAsync(workoutId, exercise);

                if (await workoutRepository.CommitAsync())
                {
                    exerciseModel = mapper.Map<WorkoutExerciseModel>(exercise);
                    return Ok(exerciseModel);
                }

                return BadRequest("Unable to add exercise to workout");
            }
            catch (Exception)
            {
                throw;
               // return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPut("{exerciseId:int}")]
        public async Task<IActionResult> Put(int workoutId, int exerciseId, WorkoutExerciseModel updatedExercise)
        {
            try
            {
                var userId = User.GetUserId();

                var workout = await workoutRepository.GetWorkoutByIdAsync(userId, workoutId);

                if (workout == null)
                {
                    return BadRequest("Workout not found");
                }

                var exerciseToUpdate = workout.WorkoutExercises.Where(we => we.Id == exerciseId).FirstOrDefault();

                if (exerciseToUpdate == null)
                {
                    return NotFound("Exercise not found");
                }

                // fix as mapper is erroring
                exerciseToUpdate.RepScheme = updatedExercise.RepScheme;
                exerciseToUpdate.Sets = updatedExercise.Sets;
                exerciseToUpdate.Rest = updatedExercise.Rest;
                exerciseToUpdate.OrderString = updatedExercise.OrderString;
                exerciseToUpdate.Notes = updatedExercise.Notes;

                //mapper.Map(updatedExercise, exerciseToUpdate);

                if (await workoutRepository.CommitAsync())
                {
                    return Ok(updatedExercise);
                }

                return BadRequest("bad Request");
            }
            catch (Exception)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpDelete("{exerciseId:int}")]
        public async Task<IActionResult> Delete(int workoutId, int exerciseId)
        {
            try
            {
                var userId = User.GetUserId();

                var workout = await workoutRepository.GetWorkoutByIdAsync(userId, workoutId);

                if (workout == null)
                {
                    return NotFound("Workout not found");
                }

                var exerciseToDelete = workout.WorkoutExercises.Where(we => we.Id == exerciseId).FirstOrDefault();

                if (exerciseToDelete == null)
                {
                    return NotFound("Exercise not found");
                }

                await workoutRepository.RemoveExerciseAsync(workoutId, exerciseId);

                if (await workoutRepository.CommitAsync())
                {
                    return Ok("Exercise removed from workout");
                }

                return BadRequest("Bad Request");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(int workoutId, IEnumerable<WorkoutExerciseModel> exercises)
        {
            try
            {
                var userId = User.GetUserId();

                var workout = await workoutRepository.GetWorkoutByIdAsync(userId, workoutId);

                if (workout == null)
                {
                    return NotFound("Workout not found");
                }

                var exercisesToUpdate = workout.WorkoutExercises;

                if (exercisesToUpdate == null)
                {
                    return NotFound("No exercises to update");
                }

                foreach (var exercise in exercisesToUpdate)
                {
                    exercise.OrderInt = exercises.Where(e => e.Id == exercise.Id).FirstOrDefault().OrderInt;
                }

                if (await workoutRepository.CommitAsync())
                {
                    return Ok(exercises);
                }

                return BadRequest("Unable to update exercise order");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
    }
}
