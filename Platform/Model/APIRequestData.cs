namespace Platform.Model
{
    public class APIRequestData
    {
        public string PayLoad { get; set; }
        public Dictionary<string, string> RequestHeaders { get; set; }
        public string AuthToken { get; set; }

        public bool IsBasicRequest { get; set; }
        public Dictionary<string, string> QueryParams { get; set; }

        public APIRequestData()
        {
            PayLoad = string.Empty;
            RequestHeaders = new Dictionary<string, string>();
            AuthToken = string.Empty;
            QueryParams = new Dictionary<string, string>(); ;
        }
    }
}