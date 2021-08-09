using System;
using System.Threading.Tasks;
using Business.DTO;
using DataAccess.Models;
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
    }
}