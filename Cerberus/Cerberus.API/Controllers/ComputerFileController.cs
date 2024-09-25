using Cerberus.API.Repository;
using Cerberus.Domain.Models.Machine;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace Cerberus.API.Controllers
{

    [ApiController]
    [Route("api/[controller")]
    public class ComputerFileController : Controller
    {
        
        private readonly ComputerFileRepository _computerFileRepository;

        public ComputerFileController(ComputerFileRepository computerFileRepository)
        {
            this._computerFileRepository = computerFileRepository;
        }

        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ComputerFile>))]
        public IActionResult GetComputerFiles(int computerID)
        {

            var files = this._computerFileRepository.GetComputerFiles(computerID);

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

        [HttpPut("{fileID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateComputerFile(int fileID, [FromBody]ComputerFile computerFile)
        {

            if (computerFile == null)
                return BadRequest(ModelState);

            if (fileID != computerFile.ID)
                return BadRequest(ModelState);

            if (!this._computerFileRepository.ComputerFileExist(computerFile))
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

    }
}
