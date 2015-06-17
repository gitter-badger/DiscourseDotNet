using System.Collections.Generic;
using DiscourseDotNet.Request;
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

        /// <summary>
        ///     Executes a RESTful API Request
        /// </summary>
        /// <typeparam name="T">Returned JSON data will be mapped to object T</typeparam>
        /// <param name="endpoint">End point for resource</param>
        /// <param name="method">HTTP Method used</param>
        /// <param name="requireAuthentication">Does the route require API Key</param>
        /// <param name="username">Username of target</param>
        /// <param name="parameters">Querystring Parameters</param>
        /// <param name="body">Json Body</param>
        /// <returns></returns>
        public T ExecuteRequest<T>(string endpoint, Method method, bool requireAuthentication = false,
            string username = "system", Dictionary<string, string> parameters = null, APIRequest body = null)
            where T : new()
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest(endpoint)
            {
                Method = method,
                RequestFormat = DataFormat.Json
            };
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
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
            if (body != null)
            {
                request.AddParameter("application/json", body, ParameterType.RequestBody);
            }

            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                throw new DiscourseException(
                    "There was an Error retrieving a response from Discourse, Please check inner details",
                    response.ErrorException);
            }
            return response.Data;
        }
    }
}