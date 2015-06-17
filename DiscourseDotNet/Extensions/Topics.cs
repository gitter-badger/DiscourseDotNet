using System;
using DiscourseDotNet.Response;
using RestSharp;

namespace DiscourseDotNet.Extensions
{
    public static partial class Api
    {
        public static LatestTopics GetLatestTopics(this DiscourseApi api)
        {
            return api.ExecuteRequest<LatestTopics>("/latest.json", Method.GET);
        }

        public static CategoryTopics GetCategoryTopics(this DiscourseApi api, int categoryId)
        {
            var route = String.Format("/c/{0}.json", categoryId);
            return api.ExecuteRequest<CategoryTopics>(route, Method.GET);
        }
    }
}