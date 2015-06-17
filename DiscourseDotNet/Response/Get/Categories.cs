using System.Collections.Generic;
using DiscourseDotNet.Response.Models;
using Newtonsoft.Json;

namespace DiscourseDotNet.Response.Get
{
    public class Categories
    {
        [JsonProperty("featured_users")]
        public List<FeaturedUser> FeaturedUsers { get; set; }

        [JsonProperty("category_list")]
        public CategoryList CategoryList { get; set; }
    }
}