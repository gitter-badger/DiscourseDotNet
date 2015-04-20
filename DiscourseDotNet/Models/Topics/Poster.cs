using System;
using Newtonsoft.Json;

namespace DiscourseDotNet.Models.Topics
{
    [Serializable]
    public class Poster
    {
        [JsonProperty("extras")]
        public string Extras { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("user_id")]
        public int UserID { get; set; }
    }
}