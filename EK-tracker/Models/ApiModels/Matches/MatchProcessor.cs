using EK_tracker.Services;
using EK_tracker.Models.ApiModels.Matches;
using Newtonsoft.Json;

namespace EK_tracker.Models.ApiModels.Group
{
    public static class MatchProcessor
    {
        public static async Task<List<Match>> GetMatchModel(ApiService apiService)
        {
            string jsonData = await apiService.GetDataAsync("matches");
            return JsonConvert.DeserializeObject<List<Match>>(jsonData);
        }
    }
}
