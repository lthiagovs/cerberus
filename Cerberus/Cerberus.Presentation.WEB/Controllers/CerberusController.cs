using Microsoft.AspNetCore.Mvc;

namespace Cerberus.Presentation.WEB.Controllers
{
    public class CerberusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
