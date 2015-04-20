using Newtonsoft.Json;

namespace DiscourseDotNet.Models.Topics
{
    public class User
    {
        [JsonProperty("id")]
        public int UserID { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("uploaded_avatar_id")]
        public int? AvatarID { get; set; }

        [JsonProperty("avatar_template")]
        public string AvatarTemplate { get; set; }
    }
}