using System;
using DiscourseDotNet.Extensions;
using DiscourseDotNet.Request;
using DiscourseDotNet.Response.Post;
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
                TextColor = "FFFFFF",
                ParentCategoryID = 22
            };
            var response = api.CreateCategory(category);
            Assert.IsNotNull(response);
        }

        [TestMethod, TestCategory("Online")]
        public void CreateNewTopic()
        {
            var api = DiscourseApi.GetInstance("http://discourse.logicpending.com", _apiKey);
            var newTopic = new NewTopic
            {
                Content =
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut posuere eleifend nulla, vel interdum elit. Aenean auctor, libero in consectetur sollicitudin, dolor massa pharetra nulla, et mollis justo turpis nec tortor. Nullam lorem nunc, cursus ac pretium in, auctor eu nisi. Nullam quis lacus quam. Curabitur vel aliquet erat, sed vestibulum ante. Vivamus consequat lorem eget gravida gravida. Aenean quis arcu ut ligula facilisis aliquet. Vestibulum rutrum magna elit. Etiam sit amet malesuada quam, nec tempor mi. Nullam eu mauris dui. Sed at mi sit amet justo ultrices laoreet non eget urna. Proin felis ex, finibus et auctor a, rutrum nec elit.",
                Title = "Testing Topic: " + Guid.NewGuid(),
                CategoryID = 21
            };
            var response = api.PostNewTopic(newTopic);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
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