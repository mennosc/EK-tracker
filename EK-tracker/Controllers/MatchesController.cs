using Microsoft.AspNetCore.Mvc;
using EK_tracker.Models.ApiModels.Matches;
using EK_tracker.Models.ApiModels.Group;
using Microsoft.AspNetCore.Authorization;
using EK_tracker.Services;

namespace EK_tracker.Controllers
{
    [Authorize]
    public class MatchesController : Controller
    {
        private readonly ApiService _apiService;
        public MatchesController(ApiService service)
        {
            _apiService = service;
        }
        public async Task<IActionResult> Index()
        {
            List<Match> matches = await MatchProcessor.GetMatchModel(_apiService);
            matches = matches.Where(match => match.TeamA.team != null && match.TeamB.team != null).ToList();

            matches.Sort((matchA, matchB) => matchA.Date.CompareTo(matchB.Date));
            return View(matches);
        }
    }
}
