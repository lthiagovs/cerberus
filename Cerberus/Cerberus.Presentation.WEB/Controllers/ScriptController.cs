using Cerberus.Domain.ApiService.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Cerberus.Presentation.WEB.Controllers
{
    public class ScriptController : Controller
    {

        private readonly IComputerScriptApiService _computerScriptApiService;

        public ScriptController(IComputerScriptApiService computerScriptApiService)
        {
            this._computerScriptApiService = computerScriptApiService;
        }



        public IActionResult Index()
        {

            TempData["Scripts"] = this._computerScriptApiService.GetComputerScripts();

            return View();

        }

    }
}
