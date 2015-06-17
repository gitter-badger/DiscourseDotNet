using DiscourseDotNet.Response.LatestEndpoint;
using RestSharp;

namespace DiscourseDotNet.Extensions
{
    public static partial class Api
    {
        public static Latest GetLatestTopics(this DiscourseApi api)
        {
            return api.ExecuteRequest<Latest>("/latest.json", Method.GET);
        }
    }
}