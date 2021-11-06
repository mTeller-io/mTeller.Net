using System.Threading.Tasks;
using mTellerPresentation.DTO;

namespace mTellerPresentation.Services
{
    public interface IAuthServices
    {
        public Task<string> SignUp(UserSignUp userSignUp);
        public Task<string> GetToken(UserSignIn userSignIn);
    }
}
