using EK_tracker.Models;
using EK_tracker.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EK_tracker.Controllers
{
    [Authorize]
    public class PoulesController(ApiService apiService) : Controller
    {
        private readonly ApiService _apiService = apiService;

        public async Task<IActionResult> Index()
        {
            var groups = await _apiService.GetDataModel<List<Poule>>("groups");
            foreach (var group in groups)
            {
                group?.Teams?.Sort((a, b) =>
                {
                    var ret = b.Points.CompareTo(a.Points);
                    if (ret == 0)
                    {
                        ret = b.GoalDifference.CompareTo(a.GoalDifference);
                    }
                    return ret;
                });
            }

            return View(groups);
        }
    }
}
