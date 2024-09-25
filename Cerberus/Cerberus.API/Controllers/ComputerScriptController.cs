﻿using Cerberus.API.Repository;
using Cerberus.Domain.Models.Machine;
using Microsoft.AspNetCore.Mvc;

namespace Cerberus.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ComputerScriptController : Controller
    {

        private readonly ComputerScriptRepository _computerScriptRepository;

        public ComputerScriptController(ComputerScriptRepository computerScriptRepository)
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

        [HttpPut("scriptID")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult UpdateScript(int scriptID, [FromBody]ComputerScript computerScript)
        {

            if (computerScript == null)
                return BadRequest(ModelState);

            if (scriptID != computerScript.Id)
                return BadRequest(ModelState);

            if (this._computerScriptRepository.ScriptExist(computerScript))
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

    }

}