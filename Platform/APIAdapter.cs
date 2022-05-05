using System;
using Platform.Interface;
using Platform.Model;
using System.Net;
using System.Text;
using Common.Helpers;
namespace Platform
{
    public class APIAdapter : IAPIAdapter
    {

        private readonly string userName;
        private readonly string password;
        private readonly string baseUrl;
        private readonly string basicToken;

        private readonly APIRequestData apiRequestData;

        public APIAdapter(string userName,string password, string baseUrl)
        {
            if(String.IsNullOrWhiteSpace(userName)|| String.IsNullOrWhiteSpace(password)|| String.IsNullOrWhiteSpace(baseUrl))
                throw new Exception("Username or password or baseurl cannot be either null, whitespace or empty");
            this.userName = userName;
            this.password= password;
            this.baseUrl= baseUrl.EncodeCodeBase64();
            this.basicToken =  (this.userName + ':' + this.password).EncodeCodeBase64();
  
            
        }

        public void PrepareRequest (APIRequestData apiRequestData)
        {
            //this.apiRequestData = apiRequestData;


        }

        public string MakeHttpWebRequest()
        {
            string responseContent="";
            byte[] dataStream = Encoding.GetEncoding("ISO-8859-1")
                               .GetBytes(apiRequestData.PayLoad);
            var uri = new Uri(baseUrl + apiRequestData.EndPoint);

            var authType = apiRequestData.IsBasicRequest?"Basic":"Bearer";
            var token = apiRequestData.IsBasicRequest?basicToken:apiRequestData.AuthToken;

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.ContentType=apiRequestData.ContentType;
            httpWebRequest.Headers.Add(HttpRequestHeader.Authorization,String.Format(authType+" {0}",token));                           
            httpWebRequest.Method= apiRequestData.HttpActionType;
            httpWebRequest.ContentLength = dataStream.Length;

            using (Stream contentStream = httpWebRequest.GetRequestStream())
            {
                contentStream.Write(dataStream,0,dataStream.Length);
                
            }
             
             WebResponse webResponse = httpWebRequest.GetResponse();

             using(Stream responseStream = webResponse.GetResponseStream())
             {
                 StreamReader streamReader = new StreamReader(responseStream);

                 responseContent = streamReader.ReadToEnd();

             }
                    
            return responseContent;
                            
        }
    }
}