using DiscourseDotNet.Response;
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
    }
}