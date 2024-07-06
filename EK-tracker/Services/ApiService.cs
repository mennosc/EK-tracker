using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using static EK_tracker.Models.ApiModels.Group.GroupModel;

namespace EK_tracker.Services
{
    public static class ApiService
    {
        private static readonly HttpClient _client;

        static ApiService()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("x-rapidapi-key", "344c1167cfmshc9911752708472bp1264d4jsnd2036d7cf1b9");
            _client.DefaultRequestHeaders.Add("x-rapidapi-host", "euro-20242.p.rapidapi.com");
        }

        public static async Task<string> GetDataAsync(string path)
        {
            using HttpResponseMessage response = await _client.GetAsync($"https://euro-20242.p.rapidapi.com/{path}");
            response.EnsureSuccessStatusCode();
            string uri = $"https://euro-20242.p.rapidapi.com/{path}";
            return await response.Content.ReadAsStringAsync();
        }
    }
}