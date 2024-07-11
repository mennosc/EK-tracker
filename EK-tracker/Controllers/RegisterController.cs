using EK_tracker.Data;
using EK_tracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Security.Claims;

namespace EK_tracker.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserDbContext _context;
        public RegisterController(UserDbContext context)
        {
            _context = context;
        }
         public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserRegistrationModel user)
        {
            if (ModelState.IsValid)
            {
                _context.users.Add(user);

                _context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }
    }
}