using EK_tracker.Services;
using EK_tracker.Models.ApiModels.Matches;
using Newtonsoft.Json;
using System.Text;

namespace EK_tracker.Models.ApiModels.Group
{
    public static class MatchProcessor
    {
        public static string GetMatchData()
        {
            string jsonData = ApiService.GetDataAsync("matches").Result;

            return jsonData;
        }

        public static List<Match> GetMatchModel()
        {
            string jsonData = ApiService.GetDataAsync("matches").Result;
            System.Diagnostics.Debug.WriteLine(jsonData);
            return JsonConvert.DeserializeObject<List<Match>>(jsonData);
        }
    }
}
