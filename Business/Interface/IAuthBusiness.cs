using Business.DTO;
using DataAccess.Models;
using System.Collections.Generic;

namespace Business.Interface
{
    /// <summary>
    /// The IAuthBusiness interface
    /// </summary>
    public interface IAuthBusiness
    {
        //validate user information
        OperationalResult<UserDetail> Validate(UserSignUp userSignUp);

        OperationalResult<UserDetail> GetToken(User user,
                                          IList<string> roles);
    }
}