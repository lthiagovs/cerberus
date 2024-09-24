using Cerberus.API.Repository;
using Cerberus.Domain.Models.Machine;
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

        [HttpGet("{ComputerID}")]
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



    }
}
