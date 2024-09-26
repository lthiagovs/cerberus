using Cerberus.API.Interfaces;
using Cerberus.Domain.Models.Machine;
using Microsoft.AspNetCore.Mvc;

namespace Cerberus.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ComputerScriptController : Controller
    {

        private readonly IComputerScriptRepository _computerScriptRepository;

        public ComputerScriptController(IComputerScriptRepository computerScriptRepository)
        {
            this._computerScriptRepository = computerScriptRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type =  typeof(IEnumerable<ComputerScript>))]
        public IActionResult GetComputerScripts()
        {

            var scripts = this._computerScriptRepository.GetComputerScripts();

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(scripts);

        }

        [HttpGet("{ID}")]
        [ProducesResponseType(200, Type = typeof(ComputerScript))]
        public IActionResult GetComputerScriptByID(int ID)
        {

            var script = this._computerScriptRepository.GetComputerScriptByID(ID);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(script);

        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateComputerScript([FromBody]ComputerScript script)
        {

            if (script == null)
                return BadRequest(ModelState);

            var scriptVerify = this._computerScriptRepository.GetComputerScripts().Where(scpt => scpt.ComputerId == script.ComputerId 
            && scpt.Name == script.Name).FirstOrDefault();

            if(scriptVerify!= null)
            {
                ModelState.AddModelError("", "a script with this name already exist in this computer.");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!this._computerScriptRepository.CreateComputerScript(script))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500,ModelState);
            }

            return Ok("Sucessfully created");

        }

        [HttpPut("ID")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult UpdateScript(int ID, [FromBody] ComputerScript computerScript)
        {

            if (computerScript == null)
                return BadRequest(ModelState);

            if (ID != computerScript.ID)
                return BadRequest(ModelState);

            if (!this._computerScriptRepository.ComputerScriptExist(ID))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!this._computerScriptRepository.UpdateComputerScript(computerScript))
            {
                ModelState.AddModelError("", "Something went wrong while updating script.");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

        [HttpDelete("ID")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult DeleteScript(int ID)
        {

            var script = this._computerScriptRepository.GetComputerScriptByID(ID);

            if (script == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (this._computerScriptRepository.DeleteComputerScript(script))
                ModelState.AddModelError("","Something went wrong deleting script.");

            return NoContent();

        }

    }

}
