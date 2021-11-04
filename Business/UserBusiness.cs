using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.DTO;
using Business.Interface;
using DataAccess.Models;
using Microsoft.AspNetCore.Identity;

namespace Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

         private readonly IJwtTokenBusiness _jwtTokenBusiness;  
        
         /// <summary>
        ///  The constructor of the AuthBusiness class
        /// </summary>
        /// <param name="userManager">The injected identity user manager class</param>
        /// <param name="mapper">The injected automapper </param>
        public UserBusiness(UserManager<User> userManager, IMapper mapper, IJwtTokenBusiness jwtTokenBusiness)
        {
            _userManager=userManager;
            _mapper = mapper;
              _jwtTokenBusiness = jwtTokenBusiness;
        }
        /// <summary>
        /// Add user to specified role
        /// </summary>
        /// <param name="userEmail"> user email</param>
        /// <param name="roleName">role name</param>
        /// <returns></returns>
        public async Task<OperationalResult> AddRoleToUser (string userEmail, string roleName)
        {
            var result = new OperationalResult
            {
                Status= false
            };
             //check for  null of input values
            if(!string.IsNullOrWhiteSpace(userEmail) && !string.IsNullOrWhiteSpace(roleName))
            {
                //Get the user by username
                var user = _userManager.Users.SingleOrDefault(u=>u.UserName==userEmail);

                if(!String.IsNullOrWhiteSpace(user.UserName))
                {    //Add the user to the specified role
                     var addRoleResult = await _userManager.AddToRoleAsync(user,roleName);

                     if(addRoleResult.Succeeded){
                         result.Status = true;
                         result.Message =$"User {user.UserName} added to the role {roleName} successfully";
                     }
                     else{

                        result.Message=$"Sorry. An error occurred when adding user {user.UserName} to the role {roleName}. Please try again";

                        result.ErrorList.AddRange (AddIdentityError(addRoleResult));
                     }
                }
            }

            return result;
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
               //Move it to repository
               var signUpResult = await CreateUserAsync(user, userSignUp.Password);

               if(signUpResult.Succeeded)
               {
                   result.Status =true;

               }
               else
               {
                  //Set the status to false
                  result.Status = false;
                  //Get error from identity operation
                  var lsErr= signUpResult.Errors;
                  //Convert and assign identity error to custom error object.
                  result.ErrorList.AddRange(lsErr.Select(x=> new Error{
                      ErrorCode = x.Code,
                      ErrorMessage = x.Description
                  }));
                   
               }
   
            }

             return result;
        }
         
        /// <summary>
        /// Create identity user
        /// </summary>
        /// <param name="user">The domain user model</param>
        /// <param name="password">The passord</param>
        /// <returns></returns>
        public async Task<IdentityResult> CreateUserAsync (User user, string password)
        {

           var signUpResult = await _userManager.CreateAsync(user, password);

             return signUpResult;
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
                        //get list of row names the user belongs to
                        var roles = await _userManager.GetRolesAsync(user);
                        //Set the operational status to true
                        result.Status=true;
                        //Generate the token
                        result.AuthToken = _jwtTokenBusiness.GenerateJwt(user, roles);

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


         /// <summary>
        /// Process identity result error
        /// </summary>
        /// <param name="identityResult"></param>
        /// <returns></returns>
        private List<Error> AddIdentityError ( IdentityResult identityResult)
        {
             var errorList = new List<Error>();

                if(identityResult!=null && identityResult.Errors.Any())
                {
                        //Get error from identity operation
                        var lsErr= identityResult.Errors;
                        //Convert and assign identity error to custom error object.
                        errorList.AddRange(lsErr.Select(x=> new Error{
                            ErrorCode = x.Code,
                            ErrorMessage = x.Description
                        })); 
                }
                      

             return errorList;
        }
        

        
    }
}