using Microsoft.AspNetCore.Mvc;
using EK_tracker.Models.ApiModels.Matches;
using EK_tracker.Models.ApiModels.Group;
using EK_tracker.Services;

namespace EK_tracker.Controllers
{
    public class MatchesController : Controller
    {
        public IActionResult Index()
        {
            List<Match> matches = MatchProcessor.GetMatchModel()
                                    .Where(match => match.TeamA.team != null && match.TeamB.team != null)
                                    .ToList();

            matches.Sort((matchA, matchB) => matchA.Date.CompareTo(matchB.Date));
            return View(matches);
        }
    }
}
