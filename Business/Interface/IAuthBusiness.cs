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
         OperationalResult Validate (UserSignUp userSignUp);

         OperationalResult GetToken (User user,
                                           IList<string> roles);

       

         
    }
}