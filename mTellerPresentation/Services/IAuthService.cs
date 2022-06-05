using mTellerPresentation.DTO;
using System.Threading.Tasks;

namespace mTellerPresentation.Services
{
    public interface IAuthServices
    {
        public Task<string> SignUp(UserSignUp userSignUp);

        public Task<string> GetToken(UserSignIn userSignIn);
    }
}