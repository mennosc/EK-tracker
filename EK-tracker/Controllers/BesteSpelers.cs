using Microsoft.AspNetCore.Mvc;

namespace EK_tracker.Controllers
{
    public class BesteSpelers : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
