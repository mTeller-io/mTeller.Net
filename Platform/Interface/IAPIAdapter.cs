using RestSharp;

namespace Platform.Interface
{
    public interface IAPIAdapter
    {
        Task<RestResponse> ExecuteGetAsync(string endpoint,
            Dictionary<string, string>? requestheaders = null,
            Dictionary<string, string>? queryString = null,
            Dictionary<string, string>? routeParams = null);

        Task<RestResponse> ExecutePostAsync(string endpoint,
            Object requestBody,
            Dictionary<string, string>? requestheaders = null,
            Dictionary<string, string>? queryString = null,
            Dictionary<string, string>? routeParams = null);

        Task<RestResponse> ExecutePostAsync(string endpoint,
            string requestStringBody,
            Dictionary<string, string>? requestheaders = null,
            Dictionary<string, string>? queryString = null,
            Dictionary<string, string>? routeParams = null);

        Task<RestResponse> ExecutePutAsync(string endpoint,
            Object requestBody,
            Dictionary<string, string>? requestheaders = null,
            Dictionary<string, string>? queryString = null,
            Dictionary<string, string>? routeParams = null);

        Task<RestResponse> ExecutePutAsync(string endpoint,
            string requestStringBody,
            Dictionary<string, string>? requestheaders = null,
            Dictionary<string, string>? queryParams = null,
            Dictionary<string, string>? routeParams = null);

        Task<RestResponse> DeleteAsync(string endpoint, int Id, Dictionary<string, string>? requestHeaders,
        Dictionary<string, string>? routeParams, Dictionary<string, string>? queryStrings);

        //string ProcessResponse ( HttpWebResponse requestResponse, string JsonResponseTpl);
    }
}