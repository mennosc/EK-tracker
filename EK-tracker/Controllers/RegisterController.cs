﻿using EK_tracker.Data;
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
        public async Task<IActionResult> Index(RegistratedUser model)
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

            var result = await _userManager.CreateAsync(user, model?.Password ?? string.Empty);
            if (result.Succeeded)
            {
                var claims = new List<Claim>
                {
                    new("UserName", user?.UserName ?? string.Empty),
                    new("EmailAddress", user?.Email ?? string.Empty),
                    new("FirstName", user?.FirstName ?? string.Empty),
                    new("LastName", user?.LastName ?? string.Empty)
                };

                var claimResult = await _userManager.AddClaimsAsync(user!, claims);
                if (claimResult.Succeeded)
                {
                    await _signInManager.SignInAsync(user!, isPersistent: false);
                }
                return RedirectToAction("Index", "Home");
            }
            //Todo: Immediatly sign in and redirect to homepage
            return RedirectToAction("Index", "Login");

        }
    }
}