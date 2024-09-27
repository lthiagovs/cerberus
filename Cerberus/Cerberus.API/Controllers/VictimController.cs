using Cerberus.API.Interfaces;
using Cerberus.Domain.Models.Person;
using Microsoft.AspNetCore.Mvc;

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
            var victims = this._victimRepository.GetVictims();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(victims);

        }

        [HttpGet("{ID:int}")]
        [ProducesResponseType(200,Type = typeof(Victim))]
        public IActionResult GetVictimByID(int ID)
        {

            var victim = this._victimRepository.GetVictimByID(ID);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            

            if(victim == null)
                return NotFound();
            

            return Ok(victim);

        }

        [HttpGet("{Name}")]
        [ProducesResponseType(200,Type = typeof(Victim))]
        public IActionResult GetVictimByName(string Name)
        {
            var victim = this._victimRepository.GetVictimByName(Name);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            

            if(victim == null)
                return NotFound();
            

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

        [HttpPut("{ID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult UpdateVictim(int ID, [FromBody]Victim victim)
        {

            if (victim == null)
                return BadRequest(ModelState);

            if (ID != victim.ID)
                return BadRequest(ModelState);

            if (!this._victimRepository.VictimExist(ID))
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

        [HttpDelete("{ID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult DeleteVictim(int ID)
        {

            var victim = this._victimRepository.GetVictimByID(ID);

            if (victim == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!this._victimRepository.DeleteVictim(victim))
                ModelState.AddModelError("", "Something went wrong deleting victim.");

            return NoContent();
        }

    }
}
