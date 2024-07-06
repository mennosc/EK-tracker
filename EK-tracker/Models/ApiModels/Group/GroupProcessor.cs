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

        public static List<GroupModel> GetGroupModel()
        {
            string jsonData = ApiService.GetDataAsync("groups").Result;

            return JsonConvert.DeserializeObject<List<GroupModel>>(jsonData);
        }
    }
}
