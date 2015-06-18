using System;
using DiscourseDotNet.Extensions;
using DiscourseDotNet.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiscourseDotNet.Tests
{
    [TestClass]
    public class TopicTests
    {
        private readonly string _apiKey = Environment.GetEnvironmentVariable("DiscourseApiKey");

        [TestMethod, TestCategory("Online")]
        public void GetLatestTopicTest()
        {
            var api = DiscourseApi.GetInstance("http://discourse.logicpending.com", _apiKey);
            var response = api.GetLatestTopics();

            Assert.IsNotNull(response);
        }

        [TestMethod, TestCategory("Online")]
        public void GetCategories()
        {
            var api = DiscourseApi.GetInstance("http://discourse.logicpending.com", _apiKey);
            var response = api.GetCategories();

            Assert.IsNotNull(response);
        }

        [TestMethod, TestCategory("Online")]
        public void GetCategoryTopics()
        {
            var api = DiscourseApi.GetInstance("http://discourse.logicpending.com", _apiKey);
            var response = api.GetCategoryTopics(2);

            Assert.IsNotNull(response);
        }

        [TestMethod, TestCategory("Online")]
        public void GetNewCategoryTopics()
        {
            var api = DiscourseApi.GetInstance("http://discourse.logicpending.com", _apiKey);
            var response = api.GetNewCategoryTopics(5, "ChaoticLoki");

            Assert.IsNotNull(response);
        }

        [TestMethod, TestCategory("Online")]
        public void GetNewTopics()
        {
            var api = DiscourseApi.GetInstance("http://discourse.logicpending.com", _apiKey);
            var response = api.GetNewTopics("ChaoticLoki");

            Assert.IsNotNull(response);
        }

        [TestMethod, TestCategory("Online")]
        public void CreateNewCategory()
        {
            var api = DiscourseApi.GetInstance("http://discourse.logicpending.com", _apiKey);
            var category = new NewCategory
            {
                Name = "API Test " + Guid.NewGuid(),
                Color = "FFA500",
                TextColor = "FFFFFF"
            };
            var response = api.CreateCategory(category);
            Assert.IsNotNull(response);
        }

        [TestMethod, TestCategory("Online")]
        public void TestSmilarPosts()
        {
            var api = DiscourseApi.GetInstance("https://meta.discourse.org", "noKey");

            var response = api.GetSimilarTopics("DiscourseApi", "Discourse Api post topic yes no, there");
            Assert.IsNotNull(response);
        }
    }
}