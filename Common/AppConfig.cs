using Microsoft.Extensions.Configuration;

namespace Common
{
    public class AppConfig : IAppConfig
    {
        public AppConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private readonly IConfiguration _configuration;

        public string PrimarySubscriptionKey =>
        _configuration["Disbursemnt-PrimarySubscriptionKey"];

        public string SecondarySubscriptionKey =>
        _configuration["Disbursemnt-SecondarySubscriptionKey"];
    }

    public interface IAppConfig
    {
        //Primary subscription key assigned by API provider
        string PrimarySubscriptionKey { get; }

        //Secondary subscription key assigned by API provider
        string SecondarySubscriptionKey { get; }

        //Type of product for subscription .e.g collection, disbursement etc
        //  string ProductType {get;set;}
        //The name identifier of the API provider
        //  string NetworkName {get;set;}
        //API user identification. This must be created
        //  Guid APIUser {get;set;}
        //API User key for identification. This must be created
        //  Guid APIKey {get;set;}
        //API usage target environment e.g sandbox or production.
        // string TargetEnvironment {get;set;}
        // Host or base url of the API
        // string BaseUrl {get;set;}
    }
}