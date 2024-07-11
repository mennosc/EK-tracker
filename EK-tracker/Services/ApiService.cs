namespace EK_tracker.Services
{
    public class ApiService
    {
        private readonly HttpClient _client;

        public ApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> GetDataAsync(string path)
        {
            using HttpResponseMessage response = await _client.GetAsync($"https://euro-20242.p.rapidapi.com/{path}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}