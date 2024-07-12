using EK_tracker.Data;
using EK_tracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace EK_tracker.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;
        public RegisterController(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
         public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new UserModel
                {
                    UserName = model.UserName,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if(result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                //Todo: Immediatly sign in and redirect to homepage
                return RedirectToAction("Index", "Login");
            }

            return View(model);
        }
    }
}