using Newtonsoft.Json;

namespace DiscourseDotNet.Response.Post
{
    public class GroupPermission
    {
        [JsonProperty("permission_type")]
        public int PermissionType { get; set; }

        [JsonProperty("group_name")]
        public string GroupName { get; set; }
    }
}