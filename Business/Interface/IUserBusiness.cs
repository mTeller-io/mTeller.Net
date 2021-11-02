using System.Threading.Tasks;
using Business.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Identity;


namespace Business.Interface
{
    public interface IUserBusiness
    {

        //Add new user 
         Task<OperationalResult> CreateUserAsync (UserSignUp userSignUp);

        Task<IdentityResult> CreateUserAsync (User user, string password);

        Task<OperationalResult> SignIn (UserSignIn userSignIn);

       Task<OperationalResult> AddRoleToUser (string userEmail, string roleName);
         
    }
}