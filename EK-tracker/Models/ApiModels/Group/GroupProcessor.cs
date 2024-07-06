using EK_tracker.Services;
using Newtonsoft.Json;
using System.Text;

namespace EK_tracker.Models.ApiModels.Group
{
    public static class GroupProcessor
    {
        public static string GetGroupData()
        {
            string jsonData = ApiService.GetDataAsync("groups").Result;

            return jsonData;
        }

        public async static Task<List<GroupModel>> GetGroupModel()
        {
            string jsonData = await ApiService.GetDataAsync("groups");

            List<GroupModel> groups = JsonConvert.DeserializeObject<List<GroupModel>>(jsonData);

            return groups;
        }
    }
}
