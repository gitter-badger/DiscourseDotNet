using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DiscourseDotNet.Request;
using Newtonsoft.Json;
using RestSharp;

namespace DiscourseDotNet
{
    internal class RequestManager
    {
        private static RequestManager _requestManager;
        private static RestClient _webClient;
        public readonly string ApiKey;
        public readonly string RootDomain;

        private RequestManager(string rootDomain, string apiKey)
        {
            RootDomain = rootDomain;
            ApiKey = apiKey;
            _webClient = new RestClient(rootDomain);
        }

        public static RequestManager GetInstance(string rootDomain, string apiKey)
        {
            if (_requestManager == null || _requestManager.RootDomain != rootDomain || _requestManager.ApiKey != apiKey)
            {
                _requestManager = new RequestManager(rootDomain, apiKey);
            }

            return _requestManager;
        }

        public T ExecuteRequest<T>(string endpoint, Method method, bool requireAuthentication = false,
            string username = "system", NameValueCollection parameters = null, APIRequest body = null)
        {
            if (parameters == null) parameters = new NameValueCollection();
            if (requireAuthentication)
            {
                parameters["api_key"] = ApiKey;
                parameters["api_username"] = username;
            }
            
        }

        public static Uri AttachParameters(this Uri uri, NameValueCollection parameters)
        {
            var stringBuilder = new StringBuilder();
            var str = "?";
            for (var index = 0; index < parameters.Count; ++index)
            {
                stringBuilder.Append(str + parameters.AllKeys[index] + "=" + parameters[index]);
                str = "&";
            }
            return new Uri(uri + stringBuilder.ToString());
        }

        public T MakeServerRequest<T>(string endpoint, HttpVerb method, string username = "system",
            NameValueCollection parameters = null, APIRequest body = null, bool useHttps = false)
        {
            if (parameters == null) parameters = new NameValueCollection();
            parameters["api_key"] = ApiKey;
            parameters["api_username"] = username;

            var url =
                new Uri((useHttps ? Uri.UriSchemeHttps : Uri.UriSchemeHttp) + Uri.SchemeDelimiter + RootDomain +
                        endpoint).AttachParameters(parameters);
            var payload = body == null ? null : body.ToString();
            var methodString = method.ToString().ToUpper();
            var response = string.Empty;
            using (var client = new WebClient())
            {
                client.Headers["Content-Type"] = "application/json";
                try
                {
                    switch (method)
                    {
                        case HttpVerb.Post:
                        case HttpVerb.Put:
                            if (payload == null) throw new Exception("Malformed Payload");
                            response = client.UploadString(url, methodString, payload);
                            break;
                        default:
                            response = client.DownloadString(url);
                            break;
                    }
                }
                catch (WebException ex)
                {
                    HandleException(ex);
                }
            }
            return JsonConvert.DeserializeObject<T>(response);
        }

        public async Task<T> MakeServerRequestAsync<T>(string endpoint, HttpVerb method,
            string username = "system",
            NameValueCollection parameters = null, APIRequest body = null, bool useHttps = false)
        {
            if (parameters == null) parameters = new NameValueCollection();
            parameters["api_key"] = ApiKey;
            parameters["api_username"] = username;

            var url =
                new Uri((useHttps ? Uri.UriSchemeHttps : Uri.UriSchemeHttp) + Uri.SchemeDelimiter + RootDomain +
                        endpoint).AttachParameters(parameters);
            var payload = body == null ? null : body.ToString();
            var methodString = method.ToString().ToUpper();
            var response = string.Empty;
            using (var client = new WebClient())
            {
                client.Headers["Content-Type"] = "application/json";
                try
                {
                    switch (method)
                    {
                        case HttpVerb.Post:
                        case HttpVerb.Put:
                            if (payload == null) throw new Exception("Malformed Payload");
                            response = await client.UploadStringTaskAsync(url, methodString, payload);
                            break;
                        default:
                            response = await client.DownloadStringTaskAsync(url);
                            break;
                    }
                }
                catch (WebException ex)
                {
                    HandleException(ex);
                }
            }
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(response));
        }

        private static void HandleException(WebException ex)
        {
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse) ex.Response;
            }
            catch (NullReferenceException)
            {
                response = null;
            }

            if (response == null)
            {
                throw new DiscourseException(ex.Message);
            }

            switch (response.StatusCode)
            {
                case HttpStatusCode.ServiceUnavailable:
                    throw new DiscourseException("503, Service unavailable");
                case HttpStatusCode.InternalServerError:
                    throw new DiscourseException("500, Internal server error");
                case HttpStatusCode.Unauthorized:
                    throw new DiscourseException("401, Unauthorized");
                case HttpStatusCode.BadRequest:
                    throw new DiscourseException("400, Bad request");
                case HttpStatusCode.NotFound:
                    throw new DiscourseException("404, Resource not found");
            }
        }
    }
}