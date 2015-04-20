using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiscourseDotNet.Tests
{
    [TestClass]
    public class TopicTests
    {
        [TestMethod]
        public void GetLatestTopicTest()
        {
            var api = DiscourseApi.GetInstance("forum.azleaguecommunity.com",
                Environment.GetEnvironmentVariable("API_KEY"));
            var response = api.GetLatestTopics();

            Assert.IsNotNull(response);
        }
    }
}
