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

    }
}
