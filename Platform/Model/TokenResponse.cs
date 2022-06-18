
using System.Text.Json.Serialization;

namespace Platform.Model
{
    public class TokenResponse
    {
       
    [JsonPropertyName("token_type")]
    public string TokenType { get; init; }
    [JsonPropertyName("access_token")]
    public string AccessToken { get; init; }
    }
    
}