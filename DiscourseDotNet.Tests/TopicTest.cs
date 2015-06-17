using System;
using DiscourseDotNet.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiscourseDotNet.Tests
{
    [TestClass]
    public class TopicTests
    {
        [TestMethod]
        public void GetLatestTopicTest()
        {
            var api = DiscourseApi.GetInstance("meta.discourse.org",
                Environment.GetEnvironmentVariable("API_KEY"));
            var response = api.GetLatestTopics();

            Assert.IsNotNull(response);
        }
    }
}
