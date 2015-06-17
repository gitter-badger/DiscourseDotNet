using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscourseDotNet.Response;
using RestSharp;

namespace DiscourseDotNet.Extensions
{
    public static partial class Api
    {
        public static Categories GetCategories(this DiscourseApi api)
        {
            return api.ExecuteRequest<Categories>("/categories.json", Method.GET);
        }
    }
}
