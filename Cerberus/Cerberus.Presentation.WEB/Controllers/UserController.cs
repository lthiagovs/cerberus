using Cerberus.Domain.ApiService.Interface;
using Cerberus.Domain.Models.Machine;
using Cerberus.Presentation.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cerberus.Presentation.WEB.Controllers
{
    public class UserController : Controller
    {

        private readonly IComputerApiService _computerApiService;

        public UserController(IComputerApiService computerApiService)
        {
            this._computerApiService = computerApiService;
        }

        public async Task<IActionResult> Index()
        {

            TempData["Devices"] = await this._computerApiService.GetComputers();

            return View();

        }

        public async Task<IActionResult> AcessDevice([FromForm] DeviceRequestModel deviceRequest)
        {

            if (deviceRequest == null)
                return RedirectToAction("Index");

            int ID = Convert.ToInt32(deviceRequest.ID);

            Computer? computer = await this._computerApiService.GetComputerByID(ID);

            if (computer == null)
                return RedirectToAction("Index");

            return RedirectToAction("Index", "Device");

        }

    }
}
