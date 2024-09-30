using Cerberus.Domain.ApiService.Interface;
using Cerberus.Domain.Models.Person;
using Cerberus.Presentation.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cerberus.Presentation.WEB.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUserApiService _userApiService;

        public LoginController(IUserApiService userApiService)
        {
            this._userApiService = userApiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OnPostLogin([FromForm] AccountRequestModel loginRequest)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            User? user = null;

            if (loginRequest.ResquestEmail != null && loginRequest.RequestPassword != null)
            {
                try
                {
                    user = await this._userApiService.GetUserByLogin(loginRequest.ResquestEmail, loginRequest.RequestPassword);
                }
                catch (Exception ex)
                {
                    TempData["AlertMessage"] = ex.Message;
                }
            }

            if (user == null)
            {
                TempData["AlertMessage"] = "Account not found!";
                return RedirectToAction("Index");
            }



            return RedirectToAction("Index", "User");

        }

    }
}
