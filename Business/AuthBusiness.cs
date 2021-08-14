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
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        
        /// <summary>
        ///  The constructor of the AuthBusiness class
        /// </summary>
        /// <param name="userManager">The injected identity user manager class</param>
        /// <param name="mapper">The injected automapper </param>
        public AuthBusiness(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        
        
        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="userSignUp">The user sign up submitted from client</param>
        /// <returns>Returns operational result</returns>
        public async Task<OperationalResult> CreateUserAsync (UserSignUp userSignUp)
        {
            //Initialise the return result
            var result  = new OperationalResult
                {
                    Status = false
                } ;
            
            //Check if data is submitted and create new user
            if(userSignUp!=null && !String.IsNullOrWhiteSpace(userSignUp.FullName))
            { 
                 //TODO: Validate submitted form which

               //automap the submitted data and the domain user model
               var user = _mapper.Map<UserSignUp,User>(userSignUp);
              
               //Add the new user if it does not already exist
               var signUpResult = await _userManager.CreateAsync(user, userSignUp.Password);

               if(signUpResult.Succeeded)
               {
                   result.Status =true;

               }
               else
               {
                  result.Status = false;
                  var lsErr= signUpResult.Errors.ToList();
                  result.Data.AddRange(lsErr);
                   
               }
   
            }

             return result;
        }


         /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="userSignIn">The user sign in submitted from client</param>
        /// <returns>Returns operational result</returns>
        public async Task<OperationalResult> SignIn (UserSignIn userSignIn)
        {
            //Initialise the return result
            var result  = new OperationalResult
                {
                    Status = false
                } ;
            
            //Check if data is submitted and create new user
            if(userSignIn!=null && !String.IsNullOrWhiteSpace(userSignIn.UserName))
            { 
               //automap the submitted data and the domain user model
               var user =  _userManager.Users.SingleOrDefault(u=>u.UserName==userSignIn.UserName);

               if(user is null){

                   result.Status=false;
                   result.Message="User not found";

               }
               else
               {
                 
                     var signInResult= await _userManager.CheckPasswordAsync(user,userSignIn.Password);
                 
                    if(signInResult)
                    {
                        result.Status=true;
                    
                    }
                    else
                    {
                        result.Message="UserName or password incorrect";
                    }

               }
 
            }
            else
            {
                result.Message="Invalid sign in details. Please provide username and password";
            }
             return result;
        }

       public async  Task<OperationalResult> Validate (UserSignUp userSignUp)
       {
           var result = new OperationalResult
           {
               Status= false
           };

           return result;

       }
    }
}