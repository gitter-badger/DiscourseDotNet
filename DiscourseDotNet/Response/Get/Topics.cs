using System.Collections.Generic;
using DiscourseDotNet.Response.Get.Models;
using Newtonsoft.Json;

namespace DiscourseDotNet.Response.Get
{
    public class Topics
    {
        [JsonProperty("users")]
        public List<User> Users { get; set; }

        [JsonProperty("topic_list")]
        public TopicList TopicList { get; set; }
    }
}