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
        private readonly RoleManager<Role> _roleManager;     

        private readonly IJwtTokenBusiness _jwtTokenBusiness;   
        /// <summary>
        ///  The constructor of the AuthBusiness class
        /// </summary>
        /// <param name="userManager">The injected identity user manager class</param>
        /// <param name="mapper">The injected automapper </param>
        public AuthBusiness(UserManager<User> userManager, IMapper mapper, RoleManager<Role> roleManager, IJwtTokenBusiness jwtTokenBusiness)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
            _jwtTokenBusiness = jwtTokenBusiness;
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
        
        /// <summary>
        /// Add user to specified role
        /// </summary>
        /// <param name="userEmail"> user email</param>
        /// <param name="roleName">role name</param>
        /// <returns></returns>
        public async Task<OperationalResult> AddUserToRole (string userEmail, string roleName)
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
        /// Add a new role 
        /// </summary>
        /// <param name="roleName">The name of the new role</param>
        /// <returns></returns>
        public async Task<OperationalResult> CreateRole(string roleName)
        {
                //initialise result
                var result = new OperationalResult
                {
                    Status= false
                    
                };

                //Check for null or empty string 
                if(!String.IsNullOrWhiteSpace(roleName))
                {
                    var newRole = new Role
                    {
                        Name = roleName
                    };
                    
                    //Create new role
                    var roleResult = await _roleManager.CreateAsync(newRole);
                   
                    if(roleResult.Succeeded)
                    {  
                        result.Status= true;
                        result.Message=$"New role {newRole} created successfully";
                    }
                    else
                    {
                        //Set the status to false
                        result.Status = false;
                        //Get error from identity operation
                        var lsErr= roleResult.Errors;
                        //Convert and assign identity error to custom error object.
                        result.ErrorList.AddRange(lsErr.Select(x=> new Error{
                            ErrorCode = x.Code,
                            ErrorMessage = x.Description
                        }));

                        result.Message=$"Sorry. Unable to create new role {newRole}.Please try again";
                    }
                }
                else
                {
                    result.Message="New role name cannot be null or empty";
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