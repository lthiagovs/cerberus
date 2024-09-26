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

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<LuaResult>))]
        public IActionResult GetLuaResultByComputerIP(string IP)
        {

            var result = this._luaResultRepository.GetLuaResultsByIP(IP);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (result == null)
                return NotFound();

            return Ok(result);

        }

    }

}
