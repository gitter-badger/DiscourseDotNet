using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscourseDotNet.Response.Get;
using RestSharp;

namespace DiscourseDotNet.Extensions
{
    public static partial class Api
    {
        public static GetUserModel GetUser(this DiscourseApi api, string username)
        {
            var path = String.Format("/users/{0}.json", username);
            return api.ExecuteRequest<GetUserModel>(path, Method.GET);
        }
    }
}
