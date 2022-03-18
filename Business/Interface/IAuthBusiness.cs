using System;
using System.Collections.Generic;
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
       
         //validate user information
         OperationalResult<UserDetail> Validate (UserSignUp userSignUp);

         OperationalResult<UserDetail> GetToken (User user,
                                           IList<string> roles);

       

         
    }
}