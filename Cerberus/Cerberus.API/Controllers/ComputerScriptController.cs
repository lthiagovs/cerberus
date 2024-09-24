using Cerberus.API.Repository;
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

    }

}
