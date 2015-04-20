using System;
using DiscourseDotNet.Models.Topics;

namespace DiscourseDotNet
{
    public class DiscourseApi
    {
        private static DiscourseApi _instance;
        private static RequestManager _requestManager;

        private DiscourseApi(string rootDomain, string apiKey)
        {
            _requestManager = RequestManager.GetInstance(rootDomain, apiKey);
        }

        public static DiscourseApi GetInstance(string rootDomain, string apiKey)
        {
            if (_instance == null || _requestManager.RootDomain != rootDomain ||
                _requestManager.ApiKey != apiKey)
            {
                _instance = new DiscourseApi(rootDomain, apiKey);
            }
            return _instance;
        }

        public TopicListRoot GetLatestTopics()
        {
            return _requestManager.MakeServerRequest<TopicListRoot>("/latest.json", HttpVerb.Get);
        }

        public TopicListRoot GetNewTopics()
        {
            return _requestManager.MakeServerRequest<TopicListRoot>("/new.json", HttpVerb.Get);
        } 
    }
}