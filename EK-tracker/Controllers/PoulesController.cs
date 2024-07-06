using EK_tracker.Models.ApiModels.Group;
using Microsoft.AspNetCore.Mvc;

namespace EK_tracker.Controllers
{
    public class PoulesController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<GroupModel> groups = await GroupProcessor.GetGroupModel();
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
