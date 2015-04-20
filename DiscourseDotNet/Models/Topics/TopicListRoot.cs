using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DiscourseDotNet.Models.Topics
{
    [Serializable]
    public class TopicListRoot
    {
        [JsonProperty("users")]
        public List<User> Users { get; set; }

        [JsonProperty("topic_list")]
        public TopicList TopicList { get; set; }
    }
}