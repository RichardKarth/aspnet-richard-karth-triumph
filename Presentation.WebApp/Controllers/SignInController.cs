using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebApp.Models;

namespace Presentation.WebApp.Controllers;

public class SignInController : Controller
{
 
    public SignInController()
    {
        
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(SignInViewModel model)
    {
        if (!ModelState.IsValid)
           
            return RedirectToAction("Index", "Home");

        ModelState.AddModelError("", "Incorrect email or password");

        return View(model);
    }
}