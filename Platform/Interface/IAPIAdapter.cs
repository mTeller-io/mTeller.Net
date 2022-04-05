using System;
using System.Net;

namespace Platform.Interface
{
    public interface IAPIAdapter
    {
        HttpWebRequest PrepareRequest (string payLoad, string headers, string baseUrl, string endPoint);

        string MakeRequest (HttpWebRequest webRequest);

        string ProcessResponse ( string requestResponse, string JsonResponseTpl);
    }
}