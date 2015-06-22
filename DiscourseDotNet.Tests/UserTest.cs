using System;
using DiscourseDotNet.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiscourseDotNet.Tests
{
    [TestClass]
    public class UserTest
    {
        private readonly string _apiKey = Environment.GetEnvironmentVariable("DiscourseApiKey");
        private DiscourseApi _api;

        [TestInitialize]
        public void Initialize()
        {
            _api = DiscourseApi.GetInstance("http://discourse.logicpending.com", _apiKey);
        }

        [TestMethod]
        public void TestGetUser()
        {
            _api = DiscourseApi.GetInstance("https://meta.discourse.org", _apiKey);
            var result = _api.GetUser("chaoticloki");
            Assert.IsNotNull(result);
        }
    }
}