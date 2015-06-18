using System;
using DiscourseDotNet.Extensions;
using DiscourseDotNet.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiscourseDotNet.Tests
{
    [TestClass]
    public class TopicTests
    {
        [TestMethod]
        public void GetLatestTopicTest()
        {
            var api = DiscourseApi.GetInstance("http://discourse.logicpending.com",
                "2dc502bac050595af6ba30f363e84bb9285c0d205622939c82ac03a4f9c475ea");
            var response = api.GetLatestTopics();

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void GetCategories()
        {
            var api = DiscourseApi.GetInstance("http://discourse.logicpending.com",
                "2dc502bac050595af6ba30f363e84bb9285c0d205622939c82ac03a4f9c475ea");
            var response = api.GetCategories();

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void GetCategoryTopics()
        {
            var api = DiscourseApi.GetInstance("http://discourse.logicpending.com",
                "2dc502bac050595af6ba30f363e84bb9285c0d205622939c82ac03a4f9c475ea");
            var response = api.GetCategoryTopics(2);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void GetNewCategoryTopics()
        {
            var api = DiscourseApi.GetInstance("http://discourse.logicpending.com",
                "2dc502bac050595af6ba30f363e84bb9285c0d205622939c82ac03a4f9c475ea");
            var response = api.GetNewCategoryTopics(5, "ChaoticLoki");

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void GetNewTopics()
        {
            var api = DiscourseApi.GetInstance("http://discourse.logicpending.com",
                "2dc502bac050595af6ba30f363e84bb9285c0d205622939c82ac03a4f9c475ea");
            var response = api.GetNewTopics("ChaoticLoki");

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void CreateNewCategory()
        {
            var api = DiscourseApi.GetInstance("http://discourse.logicpending.com",
                "2dc502bac050595af6ba30f363e84bb9285c0d205622939c82ac03a4f9c475ea");
            var category = new NewCategory
            {
                Name = "API Test " + Guid.NewGuid(),
                Color = "FFA500",
                TextColor = "FFFFFF"
            };
            var response = api.CreateCategory(category);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void TestSmilarPosts()
        {
            var api = DiscourseApi.GetInstance("https://meta.discourse.org", "null");

            var response = api.GetSimilarTopics("DiscourseApi", "Discourse Api post topic yes no, there");
            Assert.IsNotNull(response);
        }
    }
}