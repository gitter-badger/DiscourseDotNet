using System;
using DiscourseDotNet.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace DiscourseDotNet.Tests
{
    [TestClass]
    public class TopicTests
    {
        [TestMethod]
        public void GetLatestTopicTest()
        {
            var api = DiscourseApi.GetInstance("https://meta.discourse.org",
                "null");
            var response = api.GetLatestTopics();

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void GetCategories()
        {
            var api = DiscourseApi.GetInstance("https://meta.discourse.org",
                "null");
            var response = api.GetCategories();

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void GetCategoryTopics()
        {
            var api = DiscourseApi.GetInstance("https://meta.discourse.org",
                "null");
            var response = api.GetCategoryTopics(2);

            Assert.IsNotNull(response);
        }
    }
}
