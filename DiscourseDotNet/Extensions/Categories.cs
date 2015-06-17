using System;
using DiscourseDotNet.Request;
using DiscourseDotNet.Response;
using DiscourseDotNet.Response.Get;
using DiscourseDotNet.Response.Post;
using DiscourseDotNet.Response.Post.Models;
using RestSharp;

namespace DiscourseDotNet.Extensions
{
    public static partial class Api
    {
        public static Categories GetCategories(this DiscourseApi api)
        {
            return api.ExecuteRequest<Categories>("/categories.json", Method.GET);
        }

        public static Category CreateCategory(this DiscourseApi api, NewCategory newCategory, string username = DefaultUsername)
        {
            var response = api.ExecuteRequest<CreatedCategory>("/categories", Method.POST, true, username, null, newCategory);
            return response == null ? null : response.Category;
        }

        public static Topics GetCategoryTopics(this DiscourseApi api, int categoryId)
        {
            var route = String.Format("/c/{0}.json", categoryId);
            return api.ExecuteRequest<Topics>(route, Method.GET);
        }

        public static Topics GetLatestCategoryTopics(this DiscourseApi api, int categoryId)
        {
            var route = String.Format("/c/{0}/l/latest.json", categoryId);
            return api.ExecuteRequest<Topics>(route, Method.GET);
        }

        public static Topics GetNewCategoryTopics(this DiscourseApi api, int categoryId,
            string username = DefaultUsername)
        {
            var route = String.Format("/c/{0}/l/new.json", categoryId);
            return api.ExecuteRequest<Topics>(route, Method.GET, true, username);
        }

        public static Topics GetSubCategoryTopics(this DiscourseApi api, int parentCategory, int childCategory)
        {
            var route = String.Format("/c/{0}/{1}.json", parentCategory, childCategory);
            return api.ExecuteRequest<Topics>(route, Method.GET);
        }
    }
}