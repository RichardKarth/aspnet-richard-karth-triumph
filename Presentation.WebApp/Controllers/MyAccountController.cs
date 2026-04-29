using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers
{
    public class MyAccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Membership()
        {
            return View();
        }

        public IActionResult Bookings()
        {
            return View();
        }
    }
}
