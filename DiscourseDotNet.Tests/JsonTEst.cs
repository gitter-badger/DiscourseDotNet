using System;
using System.Collections.Generic;
using DiscourseDotNet.Lib;
using DiscourseDotNet.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace DiscourseDotNet.Tests
{
    [TestClass]
    public class JsonTest
    {
        [TestMethod]
        public void TestCategory()
        {
            var category = new NewCategory
            {
                AllowBadges = true,
                AutoCloseBasedOnLastPost = true,
                AutoCloseHours = 3,
                Color = "FFFFFF",
                Name = "test",
                TextColor = "ffff"
            };

            category.AddOrUpdatePermission("everyone", Permission.CreateReplySee);
            category.AddOrUpdatePermission("trust_level_0", Permission.See);

            var actual = JsonConvert.SerializeObject(category);
            var expected =
                "{\"name\":\"test\",\"color\":\"FFFFFF\",\"text_color\":\"ffff\",\"permissions\":{\"everyone\":1,\"trust_level_0\":3},\"auto_close_hours\":3,\"auto_close_based_on_last_post\":true,\"allow_badges\":true}";
            Assert.AreEqual(expected, actual);
        }
    }
}