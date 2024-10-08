﻿using Cerberus.API.Interfaces;
using Cerberus.API.Repository;
using Cerberus.Domain.Models.Machine;
using Microsoft.AspNetCore.Mvc;

namespace Cerberus.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ComputerFileController : Controller
    {
        
        private readonly IComputerFileRepository _computerFileRepository;

        public ComputerFileController(IComputerFileRepository computerFileRepository)
        {
            this._computerFileRepository = computerFileRepository;
        }

        [HttpGet("Computer")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ComputerFile>))]
        public IActionResult GetComputerFiles([FromQuery] int ID)
        {

            var files = this._computerFileRepository.GetComputerFiles(ID);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(files);

        }

        [HttpGet("{ID}")]
        [ProducesResponseType(200, Type = typeof(ComputerFile))]
        public IActionResult GetComputerFileByID(int ID)
        {

            var script = this._computerFileRepository.GetComputerFileByID(ID);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(script);

        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateComputerFile([FromBody]ComputerFile computerFile)
        {

            if (computerFile == null)
                return BadRequest(ModelState);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!this._computerFileRepository.CreateComputerFile(computerFile))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return StatusCode(500, ModelState);
            }

            return Ok("Sucessfully created");

        }

        [HttpPut("{ID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateComputerFile(int ID, [FromBody]ComputerFile computerFile)
        {

            if (computerFile == null)
                return BadRequest(ModelState);

            if (ID != computerFile.ID)
                return BadRequest(ModelState);

            if (!this._computerFileRepository.ComputerFileExist(ID))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!this._computerFileRepository.UpdateComputerFile(computerFile))
            {
                ModelState.AddModelError("", "Something went wrong while updating file");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

        [HttpDelete("{ID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteComputerFile(int ID)
        {

            var file = this._computerFileRepository.GetComputerFileByID(ID);

            if (file == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!this._computerFileRepository.DeleteComputerFile(file))
                ModelState.AddModelError("", "Something went wrong deleting file.");

            return NoContent();

        }

    }
}
