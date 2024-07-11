using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EK_tracker.Controllers
{
    
    public class HomeController : Controller
    { 
        public IActionResult Index()
        {
            return View();
        }
    }
}
