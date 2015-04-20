using System;
using DiscourseDotNet.Models.Topics;

namespace DiscourseDotNet
{
    public class DiscourseApi
    {
        private static DiscourseApi _instance;

        private DiscourseApi(string rootDomain, string apiKey)
        {
            RequestManager.RootDomain = rootDomain;
            RequestManager.ApiKey = apiKey;
        }

        public static DiscourseApi GetInstance(string rootDomain, string apiKey)
        {
            if (_instance == null || RequestManager.RootDomain != rootDomain ||
                RequestManager.ApiKey != apiKey)
            {
                _instance = new DiscourseApi(rootDomain, apiKey);
            }
            return _instance;
        }

        public TopicListRoot GetLatestTopics()
        {
            return RequestManager.MakeServerRequest<TopicListRoot>("/latest.json", HttpVerb.Get);
        }
    }
}