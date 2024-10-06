using Cerberus.Domain.ApiService.ApiService;
using Cerberus.Domain.ApiService.Interface;
using Cerberus.Domain.Models.Machine;
using Cerberus.Domain.Models.Script;
using Cerberus.Presentation.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cerberus.Presentation.WEB.Controllers
{
    public class ScriptController : Controller
    {

        private ILuaResultApiService _luaResultApiService;
        private IComputerScriptApiService _computerScriptApiService;

        public ScriptController(ILuaResultApiService luaResultApiService, IComputerScriptApiService computerScriptApiService)
        {
            this._luaResultApiService = luaResultApiService;
            this._computerScriptApiService = computerScriptApiService;
        }



        public IActionResult Index(int ID)
        {

            TempData["Script"] = _computerScriptApiService.GetComputerScriptByID(ID).Result;
            TempData["Data"] = _luaResultApiService.GetLuaResults().Result;

            return View();

        }

        public IActionResult ShowData([FromForm]DataRequestModel dataRequest)
        {

            int ID = Convert.ToInt32(dataRequest.ID);

            LuaResult? result = _luaResultApiService.GetLuaResultByID(ID).Result;

            byte[] htmlBytes = System.Text.Encoding.UTF8.GetBytes(result.Json);

            return File(htmlBytes, "text/html", result.ID+" - data.html");

        }

    }
}
