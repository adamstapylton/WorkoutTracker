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
    public class WorkoutsController : ControllerBase
    {
        private readonly IWorkoutRepository workoutRepository;
        private readonly IMapper mapper;

        public WorkoutsController(IWorkoutRepository workoutRepository, IMapper mapper)
        {
            this.workoutRepository = workoutRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var userId = User.GetUserId();

                var workouts = await workoutRepository.GetWorkoutsAsync(userId);

                var workoutModels = mapper.Map<IEnumerable<WorkoutModel>>(workouts);

                return Ok(workoutModels);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet("{workoutId}")]
        public async Task<IActionResult> Get(int workoutId)
        {
            try
            {
                var userId = User.GetUserId();

                var workout = await workoutRepository.GetWorkoutByIdAsync(userId, workoutId);

                if (workout != null)
                {
                    var workoutModel = mapper.Map<WorkoutModel>(workout);
                    return Ok(workoutModel);
                }

                return NotFound("Workout Not Found");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(WorkoutModel workoutModel)
        {
            try
            {
                var userId = User.GetUserId();

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var workout = mapper.Map<Workout>(workoutModel);
                workout.ApplicationUserId = userId;

                await workoutRepository.AddWorkoutAsync(workout);

                if (await workoutRepository.CommitAsync())
                {
                    workoutModel = mapper.Map<WorkoutModel>(workout);
                    return Ok(workoutModel);
                }

                return BadRequest();

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpDelete("{workoutId:int}")]
        public async Task<IActionResult> Delete(int workoutId)
        {
            try
            {
                var userId = User.GetUserId();

                await workoutRepository.DeleteWorkoutAsync(userId, workoutId);

                if (await workoutRepository.CommitAsync())
                {
                    return Ok("Workout deleted");
                }

                return BadRequest("Unable to delete workout");

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
    }
}
