using Microsoft.AspNetCore.Mvc;

namespace Cerberus.Presentation.WEB.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
