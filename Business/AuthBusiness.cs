using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Business.DTO;
using DataAccess.Models;
using Business.Interface;
using AutoMapper;

namespace Business
{
    /// <summary>
    /// AuthBusiness class for managing user authentication 
    /// </summary>
    public class AuthBusiness : IAuthBusiness
    {
        
        private readonly RoleManager<Role> _roleManager;     

        private readonly IJwtTokenBusiness _jwtTokenBusiness;   
        /// <summary>
        ///  The constructor of the AuthBusiness class
        /// </summary>
        /// <param name="userManager">The injected identity user manager class</param>
        /// <param name="mapper">The injected automapper </param>
        public AuthBusiness( RoleManager<Role> roleManager, IJwtTokenBusiness jwtTokenBusiness)
        {
           
            _roleManager = roleManager;
            _jwtTokenBusiness = jwtTokenBusiness;
        }
        
       
    
       public   OperationalResult Validate (UserSignUp userSignUp)
       {
           var result = new OperationalResult
           {
               Status= false
           };

           return  result;

       }

        /// <summary>
        /// Get token
        /// </summary>
        /// <param name="user"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        public OperationalResult GetToken (User user,IList<string> roles)
        {
            //Initialise the return result
            var result  = new OperationalResult
                {
                    Status = false
                } ;

                if(user !=null &&  !String.IsNullOrWhiteSpace(user.UserName) && roles!=null && roles.Any())
                {
                    result.Status=true;
                    //Generate the token
                    result.AuthToken =  _jwtTokenBusiness.GenerateJwt(user, roles);
                }
                else
                {
                     result.Status=false;
                     result.Message="User or roles cannot be null or empty";

                }
            
             return result;
        }
    }
}