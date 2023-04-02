using Common.Helpers;
using Platform.Interface;
using RestSharp;
using RestSharp.Serializers;

namespace Platform
{
    public class APIAdapter : IAPIAdapter
    {
        private readonly RestClient _restClient;
        private readonly string userName;
        private readonly string password;
        private readonly string baseUrl;
        private readonly string basicToken;
        private readonly string subscriptionKeyName;
        private readonly string subscriptionKey;

        //private readonly APIRequestData apiRequestData;

        public APIAdapter(string userName, string password, string baseUrl, RestClient restClient)
        {
            if (String.IsNullOrWhiteSpace(userName) || String.IsNullOrWhiteSpace(password) || String.IsNullOrWhiteSpace(baseUrl))
                throw new Exception("Username or password or baseurl cannot be either null, whitespace or empty");
            this.userName = userName;

            this.password = password;
            this.baseUrl = baseUrl.EncodeCodeBase64();
            this.basicToken = (this.userName + ':' + this.password).EncodeCodeBase64();

            _restClient = restClient;
        }

        public APIAdapter(string userName, string password, string baseUrl, string tokenEnpoint, string subscriptionKeyName, string subscriptionKey)
        {
            if (String.IsNullOrWhiteSpace(userName) || String.IsNullOrWhiteSpace(password) || String.IsNullOrWhiteSpace(baseUrl))
                throw new Exception("Username or password or baseurl cannot be either null, whitespace or empty");
            this.userName = userName;
            this.password = password;
            this.baseUrl = baseUrl; //.EncodeCodeBase64();
            this.basicToken = (this.userName + ':' + this.password).EncodeCodeBase64();
            this.subscriptionKeyName = subscriptionKeyName;
            this.subscriptionKey = subscriptionKey;

            var options = new RestClientOptions(this.baseUrl);

            _restClient = new RestClient(options)
            {
                Authenticator = new APIAdapterAuthenticaor(this.baseUrl, tokenEnpoint, this.userName, this.password, this.subscriptionKeyName, this.subscriptionKey)
            };
        }

        public async Task<RestResponse> ExecuteGetAsync(string endpoint, Dictionary<string, string>? requestHeaders = null,
        Dictionary<string, string>? queryStrings = null, Dictionary<string, string>? routeParams = null)
        {
            var url = PopulatePlaceholders(endpoint, routeParams);
            var restRequest = new RestRequest(url);//, Method.Get);
                                                   // restRequest = AddUrlParams(restRequest, routeParams);
            restRequest = AddRequestHeaders(restRequest, requestHeaders);
            restRequest = AddQueryStrings(restRequest, queryStrings);
            return await ExecuteAsync(restRequest);
        }

        public async Task<RestResponse> ExecutePostAsync(string endpoint, Object requestBody, Dictionary<string, string>? requestHeaders = null,
        Dictionary<string, string>? queryStrings = null, Dictionary<string, string>? routeParams = null)
        {
            var restRequest = new RestRequest(endpoint, Method.Post);
            restRequest = AddUrlParams(restRequest, routeParams);
            restRequest = AddRequestHeaders(restRequest, requestHeaders);
            restRequest = AddQueryStrings(restRequest, queryStrings);
            restRequest = AddRequestBody(restRequest, requestBody);
            return await ExecuteAsync(restRequest);
        }

        public async Task<RestResponse> ExecutePostAsync(string endpoint, string requestStringBody, Dictionary<string, string>? requestHeaders = null,
        Dictionary<string, string>? queryStrings = null, Dictionary<string, string>? routeParams = null)
        {
            var restRequest = new RestRequest(endpoint, Method.Post);
            restRequest = AddUrlParams(restRequest, routeParams);
            restRequest = AddRequestHeaders(restRequest, requestHeaders);
            restRequest = AddQueryStrings(restRequest, queryStrings);
            restRequest = AddStringRequestBody(restRequest, requestStringBody);
            return await ExecuteAsync(restRequest);
        }

        public async Task<RestResponse> ExecutePutAsync(string endpoint, Object requestBody,
        Dictionary<string, string>? requestHeaders = null,
        Dictionary<string, string>? queryStrings = null,
        Dictionary<string, string>? routeParams = null)
        {
            var restRequest = new RestRequest(endpoint, Method.Put);
            restRequest = AddUrlParams(restRequest, routeParams);
            restRequest = AddRequestHeaders(restRequest, requestHeaders);
            restRequest = AddQueryStrings(restRequest, queryStrings);
            restRequest = AddRequestBody(restRequest, requestBody);
            return await ExecuteAsync(restRequest);
        }

        public async Task<RestResponse> ExecutePutAsync(string endpoint,
        string requestStringBody,
        Dictionary<string, string>? requestHeaders = null,
        Dictionary<string, string>? queryStrings = null,
        Dictionary<string, string>? routeParams = null)
        {
            var restRequest = new RestRequest(endpoint, Method.Put);
            restRequest = AddUrlParams(restRequest, routeParams);
            restRequest = AddRequestHeaders(restRequest, requestHeaders);
            restRequest = AddQueryStrings(restRequest, queryStrings);
            restRequest = AddStringRequestBody(restRequest, requestStringBody);
            return await ExecuteAsync(restRequest);
        }

        public async Task<RestResponse> DeleteAsync(string endpoint, int Id, Dictionary<string, string>? requestHeaders,
        Dictionary<string, string>? routeParams, Dictionary<string, string>? queryStrings)
        {
            var restRequest = new RestRequest(endpoint, Method.Delete);
            restRequest = AddUrlParams(restRequest, routeParams);
            restRequest = AddRequestHeaders(restRequest, requestHeaders);
            restRequest = AddQueryStrings(restRequest, queryStrings);
            return await ExecuteAsync(restRequest);
        }

        private static RestRequest AddUrlParams(RestRequest restRequest, Dictionary<string, string>? routeParams)
        {
            if (restRequest == null || routeParams == null || routeParams.Count <= 0)
                return restRequest;
            Console.Write(routeParams.Count.ToString());
            foreach (var param in routeParams)
            {
                restRequest?.AddUrlSegment(param.Key, param.Value);
            }

            return restRequest;
        }

        /// <summary>
        /// Replace placeholders within curly brackets with values.
        /// </summary>
        /// <param name="endpoint"> string containing placeholders</param>
        /// <param name="routeParams">value key structure of containing placeholder values</param>
        /// <returns></returns>
        private static string PopulatePlaceholders(string endpoint, Dictionary<string, string>? routeParams)
        {
            var url = "";
            if (endpoint == null || routeParams == null || routeParams.Count <= 0)
                return endpoint;
            Console.Write(routeParams.Count.ToString());
            url = endpoint;
            foreach (var param in routeParams)
            {
                url = url.Replace("{" + param.Key + "}", param.Value);
            }

            return url;
        }

        private static RestRequest AddRequestHeaders(RestRequest restRequest, Dictionary<string, string>? requestHeaders)
        {
            if (requestHeaders == null || requestHeaders.Count <= 0)
                return restRequest;

            foreach (var item in requestHeaders)
            {
                restRequest.AddHeader(item.Key, item.Value);
            }

            return restRequest;
        }

        private static RestRequest AddQueryStrings(RestRequest restRequest, Dictionary<string, string>? queryStrings)
        {
            if (queryStrings == null || queryStrings.Count <= 0)
                return restRequest;

            foreach (var item in queryStrings)
            {
                restRequest.AddParameter(item.Key, item.Value);
            }

            return restRequest;
        }

        private static RestRequest AddRequestBody(RestRequest restRequest, Object requestBody)
        {
            if (requestBody == null)
                return restRequest;

            return restRequest.AddJsonBody(requestBody);
        }

        private static RestRequest AddStringRequestBody(RestRequest restRequest, string requestJsonBody)
        {
            if (requestJsonBody == null)
                return restRequest;

            return restRequest.AddStringBody(requestJsonBody, ContentType.Json);
        }

        private async Task<RestResponse> ExecuteAsync(RestRequest restRequest)
        {
            var result = new RestResponse()
            {
                IsSuccessful = false
            };

            try
            {
                if (restRequest == null)
                    return result;

                result = await _restClient.ExecuteAsync(restRequest);
            }
            catch (Exception ex)
            {
                throw ex;
                // result.Content = ex.StackTrace;
            }
            return result;
        }
    }
}