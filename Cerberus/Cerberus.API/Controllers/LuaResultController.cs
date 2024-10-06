using Cerberus.API.Interfaces;
using Cerberus.Domain.Models.Script;
using Microsoft.AspNetCore.Mvc;

namespace Cerberus.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LuaResultController : Controller
    {

        private readonly ILuaResultRepository _luaResultRepository;

        public LuaResultController(ILuaResultRepository luaResultRepository)
        {
            this._luaResultRepository = luaResultRepository;
        }

        [HttpGet("GetLuaResults")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<LuaResult>))]
        public IActionResult GetLuaResults()
        {

            var result = this._luaResultRepository.GetLuaResults();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (result == null)
                return NotFound();

            return Ok(result);

        }

        [HttpGet("GetLuaResultsByComputerIP")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<LuaResult>))]
        public IActionResult GetLuaResultsByComputerIP(string IP)
        {

            var result = this._luaResultRepository.GetLuaResultsByIP(IP);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (result == null)
                return NotFound();

            return Ok(result);

        }

        [HttpGet("GetLuaResultByID")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<LuaResult>))]
        public IActionResult GetLuaResultByID(int ID)
        {

            var result = this._luaResultRepository.GetLuaResultByID(ID);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (result == null)
                return NotFound();

            return Ok(result);

        }

        [HttpPost("CreateLuaResult")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateLuaResult([FromBody] LuaResult luaResult)
        {

            if (luaResult == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!this._luaResultRepository.CreateLuaResult(luaResult))
            {
                ModelState.AddModelError("", "Something went wrong creating result.");
                return StatusCode(500, ModelState);
            }

            return Ok(true);

        }

    }

}
