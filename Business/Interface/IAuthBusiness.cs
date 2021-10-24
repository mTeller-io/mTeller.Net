using System;
using System.Threading.Tasks;
using Business.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Identity;

namespace Business.Interface
{
    /// <summary>
    /// The IAuthBusiness interface
    /// </summary>
    public interface IAuthBusiness
    {
        //Add new user 
         Task<OperationalResult> CreateUserAsync (UserSignUp userSignUp);
         //validate user information
         Task<OperationalResult> Validate (UserSignUp userSignUp);

         Task<OperationalResult> SignIn (UserSignIn userSignIn);

         Task<IdentityResult> CreateUserAsync (User user, string password);

         
    }
}