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
    public class MuscleGroupsController : ControllerBase
    {

        private readonly IMuscleGroupRespository muscleGroupRespository;
        private readonly IMapper mapper;

        public MuscleGroupsController(IMuscleGroupRespository muscleGroupRespository, IMapper mapper)
        {
            this.muscleGroupRespository = muscleGroupRespository;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Get()
        {
            try
            {
                var muscleGroups = await muscleGroupRespository.GetMuscleGroupsAsync();

                if (muscleGroups == null)
                {
                    return NotFound();
                }

                var muscleGroupModels = mapper.Map<IEnumerable<MuscleGroupModel>>(muscleGroups);

                return Ok(muscleGroupModels);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
    }
}
