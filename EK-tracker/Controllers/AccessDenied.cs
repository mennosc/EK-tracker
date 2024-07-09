using Microsoft.AspNetCore.Mvc;

namespace EK_tracker.Controllers
{
    public class AccessDenied : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
