using Microsoft.AspNetCore.Mvc;

namespace Cerberus.Presentation.WEB.Controllers
{
    public class RepositoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
