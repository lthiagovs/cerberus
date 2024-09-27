using Microsoft.AspNetCore.Mvc;

namespace Cerberus.Presentation.WEB.Controllers
{
    public class UserScriptController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
