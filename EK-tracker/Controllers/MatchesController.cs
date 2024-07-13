using Microsoft.AspNetCore.Mvc;
using EK_tracker.Models;
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
            var matches = await _apiService.GetDataModel<List<Match>>("matches");
            matches = matches.Where(match => match.TeamA.Team != null && match.TeamB.Team != null).ToList();

            matches.Sort((matchA, matchB) => matchA.Date.CompareTo(matchB.Date));
            return View(matches);
        }
    }
}
