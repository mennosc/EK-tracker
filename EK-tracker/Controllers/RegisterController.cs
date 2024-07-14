using EK_tracker.Data;
using EK_tracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EK_tracker.Controllers
{
    public class RegisterController(UserManager<User> userManager, SignInManager<User> signInManager) : Controller
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly SignInManager<User> _signInManager = signInManager;
         public IActionResult Index()
         {
            return View();
         }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User
            {
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var claims = new List<Claim>
                {
                    new("UserName", user.UserName),
                    new("EmailAddress", user.Email),
                    new("FirstName", user.FirstName),
                    new("LastName", user.LastName)
                };

                var claimResult = await _userManager.AddClaimsAsync(user, claims);
                if (claimResult.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                }
                return RedirectToAction("Index", "Home");
            } else
            {
                var errors = result.Errors;
                var message = string.Join(", ", errors);
                ModelState.AddModelError("", message);
            }

            return RedirectToAction("Index", "Login");

        }
    }
}