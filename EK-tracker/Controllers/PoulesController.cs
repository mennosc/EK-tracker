using EK_tracker.Models.ApiModels.Group;
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
            List<GroupModel> groups = await GroupProcessor.GetGroupModel(_apiService);
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
