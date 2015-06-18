using System;
using System.Collections.Generic;
using System.Globalization;
using DiscourseDotNet.Request;
using DiscourseDotNet.Response.Get;
using DiscourseDotNet.Response.Post;
using RestSharp;

namespace DiscourseDotNet.Extensions
{
    public static partial class Api
    {
        public static Topics GetLatestTopics(this DiscourseApi api)
        {
            return api.ExecuteRequest<Topics>("/latest.json", Method.GET);
        }

        public static Topics GetTopTopics(this DiscourseApi api)
        {
            return api.ExecuteRequest<Topics>("/top.json", Method.GET);
        }

        public static Topics GetNewTopics(this DiscourseApi api, string username = DefaultUsername)
        {
            return api.ExecuteRequest<Topics>("/new.json", Method.GET, true, username);
        }

        public static CreatedTopic PostNewTopic(this DiscourseApi api, NewTopic data, string username = DefaultUsername)
        {
            return api.ExecuteRequest<CreatedTopic>("/posts", Method.POST, true, username, null, data);
        }

        public static List<SimilarTopic> GetSimilarTopics(this DiscourseApi api, string title, string content)
        {
            var timestamp =
                (DateTime.Now - new DateTime(1970, 1, 1).ToLocalTime()).TotalMilliseconds.ToString(
                    CultureInfo.InvariantCulture);
            var parameters = new Dictionary<string, string>
            {
                {"title", title},
                {"raw", content},
                {"_", timestamp}
            };
            return api.ExecuteRequest<List<SimilarTopic>>("/topics/similar_to", Method.GET, false, DefaultUsername,
                parameters);
        }
    }
}