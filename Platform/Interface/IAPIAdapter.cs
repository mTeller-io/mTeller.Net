using System;
using System.Net;
using Platform.Model;

namespace Platform.Interface
{
    public interface IAPIAdapter
    {
        void PrepareRequest (APIRequestData apiRequestData);

        string MakeHttpWebRequest ();
        

        //string ProcessResponse ( HttpWebResponse requestResponse, string JsonResponseTpl);
    }
}                       