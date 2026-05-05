using Application.Members.Abstractions;
using Application.Members.Inputs;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebApp.Models.Account;

namespace Presentation.WebApp.Controllers;

[Authorize]
[Route("account")]
public class AccountController(UserManager<ApplicationUser> userManager, IGetMemberProfileService getMemberProfileService, IUpdateMemberProfileService updateMemberProfileService) : Controller
{
    [HttpGet("my")]
    public async Task<IActionResult> My(CancellationToken ct = default)
    {
        var user = await userManager.GetUserAsync(User);
        if(user is null)
        {
            return Challenge();
        }
        var profile = await getMemberProfileService.ExecuteAsync(user.Id, ct);
        if (profile is null)
            {
            return NotFound();
        }
        var viewModel = new MyAccountViewModel
        {
            Email = user.Email ?? string.Empty,
            AboutMeForm = new MyProfileForm
            {
                FirstName = profile.Value?.FirstName ?? string.Empty,
                LastName = profile.Value?.LastName ?? string.Empty,
                Email = user.Email ?? string.Empty,
                PhoneNumber = profile.Value?.PhoneNumber ?? string.Empty,
                ProfileImageUrl = profile.Value?.ProfileImageUrl ?? string.Empty
            }
        };
       
        return View(viewModel);
    }

    [HttpPost("my")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> My(MyAccountViewModel viewModel, CancellationToken ct = default)
    {


        if (!ModelState.IsValid)
        {
            foreach (var error in ModelState)
            {
                foreach (var message in error.Value.Errors)
                {
                    Console.WriteLine($"{error.Key}: {message.ErrorMessage}");
                }
            }

            return View(viewModel);
        }
        var user = await userManager.GetUserAsync(User);
        if (user is null)
        {
            return Challenge();
        }
        viewModel.Email = user.Email ?? string.Empty;
        viewModel.AboutMeForm.Email = user.Email ?? string.Empty;

        var input = new UpdateMemberProfileInput(
            user.Id,
            viewModel.AboutMeForm.FirstName,
            viewModel.AboutMeForm.LastName,
            user.Email ?? string.Empty,
            viewModel.AboutMeForm.PhoneNumber,
            viewModel.AboutMeForm.ProfileImageUrl
        );

        var result = await updateMemberProfileService.ExecuteAsync(input, ct);

        if(!result.Success )
        {
            ViewData["ErrorMessage"] = result.ErrorMessage ?? "An error occurred while updating your profile.";
            return View(viewModel);
        }
        else
        {
            ViewData["SuccessMessage"] = "Your profile has been updated successfully.";
        }

        return View(viewModel);
    }
}