using Microsoft.AspNetCore.Mvc;

namespace Cerberus.Presentation.WEB.Controllers
{
    public class ScriptController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
