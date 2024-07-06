using EK_tracker.Services;
using EK_tracker.Models.ApiModels.Matches;
using Newtonsoft.Json;

namespace EK_tracker.Models.ApiModels.Group
{
    public static class MatchProcessor
    {
        public static string GetMatchData()
        {
            string jsonData = ApiService.GetDataAsync("matches").Result;

            return jsonData;
        }

        public static async Task<List<Match>> GetMatchModel()
        {
            string jsonData = await ApiService.GetDataAsync("matches");
            return JsonConvert.DeserializeObject<List<Match>>(jsonData);
        }
    }
}
