using System.Collections.Generic;
using DiscourseDotNet.Request;
using DiscourseDotNet.Response.LatestEndpoint;
using RestSharp;

namespace DiscourseDotNet
{
    public partial class DiscourseApi
    {
        public readonly string ApiKey;
        public readonly string BaseUrl;

        private DiscourseApi(string baseUrl, string apiKey)
        {
            BaseUrl = baseUrl;
            ApiKey = apiKey;
        }

        public T ExecuteRequest<T>(string endpoint, Method method, bool requireAuthentication = false,
            string username = "system", Dictionary<string, string> parameters = null, APIRequest body = null) where T : new()
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest(endpoint) {Method = method};
            if (parameters == null) parameters = new Dictionary<string, string>();
            if (requireAuthentication)
            {
                request.AddQueryParameter("api_key", ApiKey);
                request.AddQueryParameter("api_username", username);
            }
            foreach (var parameter in parameters)
            {
                request.AddQueryParameter(parameter.Key, parameter.Value);
            }
            if (body != null) request.AddBody(body);

            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                throw new DiscourseException("There was an Error retrieving a response from Discourse, Please check inner details", response.ErrorException);
            }
            return response.Data;
        }
    }
}