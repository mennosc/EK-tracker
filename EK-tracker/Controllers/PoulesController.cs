using EK_tracker.Models;
using EK_tracker.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EK_tracker.Controllers
{
    [Authorize]
    public class PoulesController : Controller
    {
        private readonly ApiService _apiService;
        public PoulesController(ApiService apiService) {
            _apiService = apiService;
        }
        public async Task<IActionResult> Index()
        {
            var groups = await _apiService.GetDataModel<List<Group>>("groups");
            foreach (var group in groups)
            {
                group.Teams.Sort((a, b) =>
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
