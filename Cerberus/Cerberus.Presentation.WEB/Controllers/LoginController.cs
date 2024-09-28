using Cerberus.Presentation.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cerberus.Presentation.WEB.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult OnPostLogin([FromForm] AccountRequestModel loginRequest)
        {

            // Check if the model state is valid
            if (!ModelState.IsValid)
            {
                return View(); // Return the page with validation errors
            }

            // Add your login logic here
            // If successful, redirect to another page
            return RedirectToAction("Index", "User"); // Adjust as necessary

        }

    }
}
