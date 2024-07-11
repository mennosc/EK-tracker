using EK_tracker.Services;
using Newtonsoft.Json;

namespace EK_tracker.Models.ApiModels.Group
{
    public static class GroupProcessor
    {
        public async static Task<List<GroupModel>> GetGroupModel(ApiService _apiService)
        {
            string jsonData = await _apiService.GetDataAsync("groups");

            List<GroupModel> groups = JsonConvert.DeserializeObject<List<GroupModel>>(jsonData);

            return groups;
        }
    }
}
