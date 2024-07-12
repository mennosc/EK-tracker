using EK_tracker.Data;
using EK_tracker.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EK_tracker.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<UserModel> _signInManager;
        private readonly UserManager<UserModel> _userManager;

        public LoginController(SignInManager<UserModel> signInManager, UserManager<UserModel> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                await _signInManager.PasswordSignInAsync(user, model.Password,false, false);
            }
            
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}