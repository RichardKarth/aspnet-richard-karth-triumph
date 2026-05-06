using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers
{
    public class PageNotFoundController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
