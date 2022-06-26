using mTellerPresentation.DTO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace mTellerPresentation.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly HttpClient _httpClient;

        public AuthServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetToken(UserSignIn userSignIn)
        {
            var userSignInJson = new StringContent(JsonSerializer.Serialize(userSignIn), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/Auth/signin", userSignInJson);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return "Failed";
            }
        }

        public async Task<string> SignUp(UserSignUp userSignUp)
        {
            var userSignUpJson = new StringContent(JsonSerializer.Serialize(userSignUp), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/Auth/signup", userSignUpJson);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return "Failed";
            }
        }
    }
}