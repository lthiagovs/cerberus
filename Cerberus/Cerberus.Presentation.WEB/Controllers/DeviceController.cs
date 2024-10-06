using Cerberus.Domain.ApiService.Interface;
using Cerberus.Domain.Models.Machine;
using Cerberus.Presentation.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cerberus.Presentation.WEB.Controllers
{
    public class DeviceController : Controller
    {

        private readonly IComputerScriptApiService _computerScriptApiService;

        public DeviceController(IComputerScriptApiService computerScriptApiService)
        {
            this._computerScriptApiService = computerScriptApiService;
        }

        public IActionResult Index()
        {

            TempData["Scripts"] = this._computerScriptApiService.GetComputerScripts().Result.ToList();

            return View();
        }

        public IActionResult DataView([FromForm] ScriptRequest scriptRequest)
        {

            int scriptID = Convert.ToInt32(scriptRequest.ID);

            ComputerScript? script = _computerScriptApiService.GetComputerScriptByID(scriptID).Result;

            if (script == null)
                return Index();

            return RedirectToAction("Index", "Script", new {ID = scriptID});

        }

    }
}
