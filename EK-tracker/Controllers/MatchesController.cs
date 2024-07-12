﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using EK_tracker.Services;
using EK_tracker.Models;

namespace EK_tracker.Controllers
{
    [Authorize]
    public class MatchesController(ApiService apiService) : Controller
    {
        private readonly ApiService _apiService = apiService;

        public async Task<IActionResult> Index()
        {
            List<Match> matches = await _apiService.GetDataModel<List<Match>>("matches");
            matches = matches.Where(match => match?.TeamA?.Team != null && match?.TeamB?.Team != null).ToList();

            matches.Sort((matchA, matchB) => matchA.Date.CompareTo(matchB.Date));
            return View(matches);
        }
    }
}
