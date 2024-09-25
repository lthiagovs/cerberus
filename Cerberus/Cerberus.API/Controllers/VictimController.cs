using Cerberus.API.Interfaces;
using Cerberus.Domain.Models.Person;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace Cerberus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VictimController : Controller
    {

        private readonly IVictimRepository _victimRepository;

        public VictimController(IVictimRepository victimRepository)
        {
            this._victimRepository = victimRepository;
        }

        [HttpGet]
        [ProducesResponseType(200,Type= typeof(IEnumerable<Victim>))]
        public IActionResult GetVictims()
        {
            var victims = _victimRepository.GetVictims();

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            return Ok(victims);

        }

        [HttpGet("{IP}")]
        [ProducesResponseType(200,Type = typeof(Victim))]
        public IActionResult GetVictimByID(int ID)
        {

            var victim = _victimRepository.GetVictimByID(ID);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(victim == null)
            {
                return NotFound();
            }

            return Ok(victim);

        }

        [HttpGet("{Name}")]
        [ProducesResponseType(200,Type = typeof(Victim))]
        public IActionResult GetVictimByName(string Name)
        {
            var victim = _victimRepository.GetVictimByName(Name);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(victim == null)
            {
                return NotFound();
            }

            return Ok(victim);


        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateVictim([FromBody] Victim victim)
        {

            if (victim == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!this._victimRepository.CreateVictim(victim))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return StatusCode(500, ModelState);
            }

            return Ok("Sucessfully created");

        }

        [HttpPut("{victimID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult UpdateVictim(int victimID, [FromBody]Victim victim)
        {

            if (victim == null)
                return BadRequest(ModelState);

            if (victimID != victim.ID)
                return BadRequest(ModelState);

            if (!this._victimRepository.VictimExist(victimID))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!this._victimRepository.UpdateVictim(victim))
            {
                ModelState.AddModelError("", "Something went wrong while updating vicitm.");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

    }
}
