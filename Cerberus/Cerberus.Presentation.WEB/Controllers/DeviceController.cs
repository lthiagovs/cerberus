using Cerberus.Domain.ApiService.Interface;
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

        public IActionResult DataView()
        {



            return RedirectToAction("Index", "Script");

        }

    }
}
