using Newtonsoft.Json;

namespace EK_tracker.Services
{
    public class ApiService(HttpClient client, IConfiguration configuration)
    {
        private readonly HttpClient _client = client;
        private readonly IConfiguration _configuration = configuration;

        public async Task<string> GetDataAsync(string path)
        {
            var host = _configuration["x-rapidapi-host"];
            using HttpResponseMessage response = await _client.GetAsync($"https://{host}/{path}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<T> GetDataModel<T>(string path)
        {
            string jsonData = await this.GetDataAsync(path);

            T? model = JsonConvert.DeserializeObject<T>(jsonData);

            return model!;
        }
    }
}