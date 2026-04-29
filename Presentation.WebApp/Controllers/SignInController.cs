using Microsoft.AspNetCore.Mvc;
using Presentation.WebApp.Models;

namespace Presentation.WebApp.Controllers
{
    public class SignInController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(SignInViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            return RedirectToAction("Index", "Home");
        }
    }
}