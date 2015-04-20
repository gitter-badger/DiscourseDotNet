using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DiscourseDotNet
{
    internal class RequestManager
    {
        private static RequestManager _instance;
        public static string RootDomain;
        public static string ApiKey;

        private RequestManager(string rootDomain, string apiKey)
        {
            RootDomain = rootDomain;
            ApiKey = apiKey;
        }

        public static RequestManager GetInstance(string rootDomain, string apiKey)
        {
            if (_instance == null || RootDomain != rootDomain || ApiKey != apiKey)
            {
                _instance = new RequestManager(rootDomain, apiKey);
            }
            return _instance;
        }

        public T MakeServerRequest<T>(string endpoint, HttpVerb method, string username,
            APIRequest body = null, bool useHttps = false)
        {
            var url = (useHttps ? Uri.UriSchemeHttps : Uri.UriSchemeHttp) + Uri.SchemeDelimiter + RootDomain + endpoint;
            var payload = body == null ? null : body.ToString();
            var methodString = method.ToString().ToUpper();
            using (var client = new WebClient())
            {
                client.Headers["Content-Type"] = "application/json";
                try
                {
                    string response;
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
                    return JsonConvert.DeserializeObject<T>(response);
                }
                catch (WebException ex)
                {
                    HandleException(ex);
                }
            }
        }

        public async Task<T> MakeServerRequestAsync<T>(string endpoint, HttpVerb method, string username,
            APIRequest body = null, bool useHttps = false)
        {
            var url = (useHttps ? Uri.UriSchemeHttps : Uri.UriSchemeHttp) + Uri.SchemeDelimiter + RootDomain + endpoint;
            var payload = body == null ? null : body.ToString();
            var methodString = method.ToString().ToUpper();
            using (var client = new WebClient())
            {
                client.Headers["Content-Type"] = "application/json";
                try
                {
                    string response;
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
                    return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(response));
                }
                catch (WebException ex)
                {
                    HandleException(ex);
                }
            }
        }

        private void HandleException(WebException ex)
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