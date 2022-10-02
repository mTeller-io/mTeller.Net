
using System.Text.Json.Serialization;

namespace Platform.Model
{
    public class TokenResponse
    {
       
        [JsonPropertyName("token_type")]
        public string TokenType { get; init; }= String.Empty;
        [JsonPropertyName("access_token")]
        public string AccessToken { get; init; }= String.Empty;
         [JsonPropertyName("expires_in")]
        public string ExpiresIn { get; init; }= String.Empty;
    }
    
}