namespace EK_tracker.Services
{
    public class ApiService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;

        public ApiService(HttpClient client, IConfiguration configuration)
        {
            _configuration = configuration;
            _client = client;
        }

        public async Task<string> GetDataAsync(string path)
        {
            var host = _configuration["x-rapidapi-host"];
            using HttpResponseMessage response = await _client.GetAsync($"https://{host}/{path}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}