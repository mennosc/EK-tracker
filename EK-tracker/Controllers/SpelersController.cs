using Microsoft.AspNetCore.Mvc;

namespace EK_tracker.Controllers
{
    public class SpelersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
