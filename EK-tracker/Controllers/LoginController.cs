using EK_tracker.Data;
using EK_tracker.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Security.Claims;

namespace EK_tracker.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserDbContext _context;

        public LoginController(UserDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Index(UserLoginModel user)
        {
            if (ModelState.IsValid)
            {   
                var match = _context.users.Where(storedUser => storedUser.UserName == user.UserName && storedUser.Password == user.Password);                                                                
                
                //We found a user in the db
                if(match.Count() != 0)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, "Admin")
                    };

                    var identity = new ClaimsIdentity(claims, "UserCookie");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync("UserCookie", claimsPrincipal);

                    return RedirectToAction("Index", "Home");
                }
            }
            
            return View(user);
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}