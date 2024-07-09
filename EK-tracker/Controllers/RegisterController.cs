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
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserModel user)
        {
            if (ModelState.IsValid)
            {
                using UserDbContext context = new UserDbContext(new DbContextOptionsBuilder<UserDbContext>()
                                                                                .UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = YourDatabase")
                                                                                .Options);
                context.users.Add(user);

                context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }
    }
}