using Business.DTO;
using Business.Interface;
using DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using System;

//using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    /// <summary>
    /// AuthBusiness class for managing user authentication
    /// </summary>
    public class AddCashIn : IAuthBusiness
    {
        private readonly RoleManager<Role> _roleManager;

        private readonly IJwtTokenBusiness _jwtTokenBusiness;

        /// <summary>
        ///  The constructor of the AuthBusiness class
        /// </summary>
        /// <param name="userManager">The injected identity user manager class</param>
        /// <param name="mapper">The injected automapper </param>
        public AddCashIn(RoleManager<Role> roleManager, IJwtTokenBusiness jwtTokenBusiness)
        {
            _roleManager = roleManager;
            _jwtTokenBusiness = jwtTokenBusiness;
        }

        public OperationalResult<UserDetail> Validate(UserSignUp userSignUp)
        {
            var result = new OperationalResult<UserDetail>
            {
                Status = false
            };

            return result;
        }

        /// <summary>
        /// Get token
        /// </summary>
        /// <param name="user"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        public OperationalResult<UserDetail> GetToken(User user, IList<string> roles)
        {
            //Initialise the return result
            var result = new OperationalResult<UserDetail>
            {
                Status = false
            };

            if (user != null && !String.IsNullOrWhiteSpace(user.UserName) && roles != null && roles.Any())
            {
                result.Status = true;
                //Generate the token
                result.AuthToken = _jwtTokenBusiness.GenerateJwt(user, roles);
            }
            else
            {
                result.Status = false;
                result.Message = "User or roles cannot be null or empty";
            }

            return result;
        }
    }
}