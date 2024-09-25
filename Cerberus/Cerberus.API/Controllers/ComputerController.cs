﻿using Cerberus.API.Repository;
using Cerberus.Domain.Models.Machine;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace Cerberus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerController : Controller
    {

        private readonly ComputerRepository _computerRepository;

        public ComputerController(ComputerRepository computerRepository)
        {
            _computerRepository = computerRepository;
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

        [HttpGet("{ID}")]
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

        [HttpPut("{computerID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult UpdateComputer(int computerID, [FromBody]Computer computer)
        {

            if (computer == null)
                return BadRequest(ModelState);

            if (computerID != computer.ID)
                return BadRequest(ModelState);

            if (!this._computerRepository.ComputerExist(computerID))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(this._computerRepository.UpdateComputer(computer))
            {
                ModelState.AddModelError("", "Something went wrong while updating computer.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }



    }
}
