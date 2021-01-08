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
    [Route("api/[controller]")]
    [ApiController]
    public class CompletedWorkoutsController : ControllerBase
    {
        private readonly ICompletedWorkoutRepository completedWorkoutRepository;
        private readonly IMapper mapper;

        public CompletedWorkoutsController(ICompletedWorkoutRepository completedWorkoutRepository, IMapper mapper)
        {
            this.completedWorkoutRepository = completedWorkoutRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CompletedWorkoutModel completedWorkoutModel)
        {
            try
            {
                var userId = User.GetUserId();

                var completedWorkout = mapper.Map<CompletedWorkout>(completedWorkoutModel);

                completedWorkout.ApplicationUserId = userId;

                await completedWorkoutRepository.AddCompletedWorkoutAsync(completedWorkout);

                if (await completedWorkoutRepository.CommitAsync())
                {
                    completedWorkoutModel = mapper.Map<CompletedWorkoutModel>(completedWorkout);
                    return Ok(completedWorkoutModel);
                }

                return BadRequest("Unable to add record workout");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var userId = User.GetUserId();

                var completedWorkouts = await completedWorkoutRepository.GetCompletedWorkoutsAsync(userId);

                var completedWorkoutModels = mapper.Map<IEnumerable<CompletedWorkoutModel>>(completedWorkouts);

                return Ok(completedWorkoutModels);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPost("/{completedWorkoutId:int}/exercises")]
        public async Task<IActionResult> AddExercisesToWorkout(int completedWorkoutId, IEnumerable<CompletedWorkoutExerciseModel> completedWorkoutExercisesModel)
        {
            try
            {
                var userId = User.GetUserId();

                var completedWorkout = await completedWorkoutRepository.GetCompletedWorkoutByIdAsync(userId, completedWorkoutId);

                if (completedWorkout == null)
                {
                    return NotFound("Workout Not Found");
                }

                var completedWorkoutExercises = mapper.Map<IEnumerable<CompletedWorkoutExercise>>(completedWorkoutExercisesModel);

                completedWorkout.CompletedExercises = completedWorkoutExercises;

                if (await completedWorkoutRepository.CommitAsync())
                {
                    mapper.Map<IEnumerable<CompletedWorkoutExerciseModel>>(completedWorkoutExercises);
                    return Ok(completedWorkoutExercisesModel);
                }

                return BadRequest("Unable to add exercises to completed workout");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
    }
}
