using Platform.Model;
using RestSharp;
using RestSharp.Authenticators;

namespace Platform
{
    public class APIAdapterAuthenticaor : AuthenticatorBase 
    {
        
        readonly string _baseUrl;
        readonly string _clientId;
        readonly string _clientSecret;

        public APIAdapterAuthenticaor(string baseUrl, string clientId, string clientSecret) : base("") {
            _baseUrl      = baseUrl;
            _clientId     = clientId;
            _clientSecret = clientSecret;
        }

        protected override async ValueTask<Parameter> GetAuthenticationParameter(string accessToken) {
            var token = string.IsNullOrEmpty(Token) ? await GetToken() : Token;
            return new HeaderParameter(KnownHeaders.Authorization, token);
        }

            async Task<string> GetToken() {
            var options = new RestClientOptions(_baseUrl);
            using var client = new RestClient(options) {
            Authenticator = new HttpBasicAuthenticator(_clientId, _clientSecret),
            };

            var request = new RestRequest("oauth2/token")
            .AddParameter("grant_type", "client_credentials");
            var response = await client.PostAsync<TokenResponse>(request);
            return $"{response!.TokenType} {response!.AccessToken}";
            }

    }
    
}