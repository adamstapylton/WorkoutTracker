using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutTracker.Server.Data.Repositories;
using WorkoutTracker.Shared.Models;

namespace WorkoutTracker.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseRepository exerciseRepository;
        private readonly IMapper mapper;

        public ExercisesController(IExerciseRepository exerciseRepository, IMapper mapper)
        {
            this.exerciseRepository = exerciseRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var exercises = await exerciseRepository.GetExercisesAsync();

                var exerciseModels = mapper.Map<IEnumerable<ExerciseModel>>(exercises);

                return Ok(exerciseModels);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet("{exerciseId}")]
        public async Task<IActionResult> Get(int exerciseId)
        {
            try
            {
                var exercise = await exerciseRepository.GetExerciseByIdAsync(exerciseId);

                if (exercise == null)
                {
                    return NotFound("No exercise found");
                }

                var exerciseModel = mapper.Map<ExerciseModel>(exercise);

                return Ok(exerciseModel);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
    }
}
