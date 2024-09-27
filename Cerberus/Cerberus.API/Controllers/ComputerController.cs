using Cerberus.API.Interfaces;
using Cerberus.Domain.Models.Machine;
using Microsoft.AspNetCore.Mvc;

namespace Cerberus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerController : Controller
    {

        private readonly IComputerRepository _computerRepository;

        public ComputerController(IComputerRepository computerRepository)
        {
            this._computerRepository = computerRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Computer>))]
        public IActionResult GetComputers()
        {
            var computers = this._computerRepository.GetComputers();

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(computers);

        }

        [HttpGet("{ID:int}")]
        [ProducesResponseType(200, Type = typeof(Computer))]
        public IActionResult GetComputerByID(int ID)
        {

            var computer = this._computerRepository.GetComputerByID(ID);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(computer);

        }

        [HttpGet("{IP}")]
        [ProducesResponseType(200, Type = typeof(Computer))]
        public IActionResult GetComputerByIP(string IP)
        {

            var computer = this._computerRepository.GetComputerByIP(IP);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(computer);

        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateComputer([FromBody]Computer computer)
        {
            if (computer == null)
                return BadRequest(ModelState);

            var computerVerify = this._computerRepository.GetComputers().Where(cpt => cpt.IP == computer.IP).FirstOrDefault();

            if(computerVerify != null)
            {
                ModelState.AddModelError("", "IP already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!this._computerRepository.CreateComputer(computer))
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
        public IActionResult UpdateComputer(int ID, [FromBody]Computer computer)
        {

            if (computer == null)
                return BadRequest(ModelState);

            if (ID != computer.ID)
                return BadRequest(ModelState);

            if (!this._computerRepository.ComputerExist(ID))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!this._computerRepository.UpdateComputer(computer))
            {
                ModelState.AddModelError("", "Something went wrong while updating computer.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{ID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult DeleteComputer(int ID)
        {
            var computer = this._computerRepository.GetComputerByID(ID);

            if (computer == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!this._computerRepository.DeleteComputer(computer))
                ModelState.AddModelError("", "Something went wrong deleting the computer");

            return NoContent();

        }



    }
}
