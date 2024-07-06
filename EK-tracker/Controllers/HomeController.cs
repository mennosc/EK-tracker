using EK_tracker.Models;
using EK_tracker.Models.ApiModels.Group;
using EK_tracker.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EK_tracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
