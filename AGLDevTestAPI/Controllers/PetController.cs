using AGLDevTestAPI.Model;
using AGLDevTestAPI.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AGLDevTestAPI.Controllers
{

    [Produces("application/json")]    
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        IPetService _petService;
        public PetController(IPetService petService)
        {
            _petService = petService;
        }
        /// <summary>
        /// Retrieve all the Pet types.
        /// </summary>
        [HttpGet("types")]
        [ProducesResponseType(200, Type = typeof(List<string>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            IEnumerable<string> petTypes;

            try
            {
                petTypes = await _petService.GetPetTypes();
                if (petTypes == null) return NotFound();
            }
            catch (AggregateException)
            {
                return BadRequest();//shout/catch/throw/log
            }

            return Ok(petTypes);

        }

        /// <summary>
        /// Retrieves all pet names of the supplied pet type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpGet("{type}")]
        [ProducesResponseType(200, Type = typeof(List<string>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<PetNamesbyOwnerGender>>> GetListofPetsByOwnerGender(string type)

        {
            if (string.IsNullOrEmpty(type)) return BadRequest(ModelState);

            IEnumerable<PetNamesbyOwnerGender> petlistByOwnerGender;
            try
            {
                petlistByOwnerGender = await _petService.GetListofPetsByOwnerGender(type);
                if (petlistByOwnerGender == null) return NotFound();
            }
            catch (AggregateException)
            {
                return BadRequest();//shout/catch/throw/log
            }

            return Ok(petlistByOwnerGender);

        }
    }
}
