using System;
using System.Collections.Generic;
using DiscourseDotNet.Response.Models;
using Newtonsoft.Json;

namespace DiscourseDotNet.Response
{
    [Serializable]
    public class LatestTopics
    {
        [JsonProperty("users")]
        public List<User> Users { get; set; }

        [JsonProperty("topic_list")]
        public TopicList TopicList { get; set; }
    }
}