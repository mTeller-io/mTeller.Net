using Platform.Model;
using RestSharp;
using RestSharp.Authenticators;

namespace Platform
{
    public class APIAdapterAuthenticaor : AuthenticatorBase 
    {
        
        readonly string _tokenEndUrl;
        readonly string _clientId;
        readonly string _clientSecret;
        readonly string _baseUrl;
        readonly string _subscriptionKeyName;
        readonly string _subscriptionKey;

        public APIAdapterAuthenticaor(string baseUrl,string tokenEndUrl, string clientId, string clientSecret,string subscriptionKeyName,string subscriptionKey) : base("") {
            _baseUrl= baseUrl;
            _tokenEndUrl    = tokenEndUrl;
            _clientId     = clientId;
            _clientSecret = clientSecret;
            _subscriptionKeyName=subscriptionKeyName;
            _subscriptionKey = subscriptionKey;
             
        }

        protected override async ValueTask<Parameter> GetAuthenticationParameter(string accessToken) {
            var token = string.IsNullOrEmpty(accessToken) ? await GetToken() : accessToken;
            return new HeaderParameter(KnownHeaders.Authorization, token);
        }

            async Task<string> GetToken() {
            var options = new RestClientOptions(_baseUrl);
            using var client = new RestClient(options) {
            Authenticator = new HttpBasicAuthenticator(_clientId, _clientSecret)
            };

            var request = new RestRequest(_tokenEndUrl) //api end point
            .AddParameter("grant_type", "client_credentials");
            request.AddHeader(_subscriptionKeyName,_subscriptionKey);
           // .AddParameter(_subscriptionKeyName,_subscriptionKey);
            var response = await client.PostAsync<TokenResponse>(request);
           // return $"{response!.TokenType} {response!.AccessToken}";
              return response!.AccessToken;
            
            }

    }
    
}