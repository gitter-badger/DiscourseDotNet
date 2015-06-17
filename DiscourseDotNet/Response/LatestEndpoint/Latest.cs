using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DiscourseDotNet.Response.LatestEndpoint
{
    [Serializable]
    public class Latest
    {
        [JsonProperty("users")]
        public IList<TopicUser> Users { get; set; }

        [JsonProperty("topic_list")]
        public TopicList TopicList { get; set; }
    }
}