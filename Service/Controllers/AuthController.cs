using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Business;
using Business.DTO;
namespace Service.Controllers
{   
    /// <summary>
    /// The Authentication controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //The authentication business class
        private readonly AuthBusiness _authBusiness ;
        
        /// <summary>
        /// The default controller constructor
        /// </summary>
        /// <param name="authBusiness">The injected authentiation business class dependency</param>
        public  AuthController(AuthBusiness authBusiness)
        {
            _authBusiness  = authBusiness;
        }
        /// <summary>
        /// Add or register new user
        /// </summary>
        /// <param name="userSignUp">The submitted user details</param>
        /// <returns>returns action result</returns>
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp ([FromBody] UserSignUp userSignUp)
        {       //Call the createUserAsync method to register the new user
                var signUpresult = await _authBusiness.CreateUserAsync(userSignUp);

                if(signUpresult.Status)
                {
                     return Created("User created succesfully", string.Empty);
                }
                else
                {
                    //TODO:Change it to IActionResult that takes list or type as argument
                  return Problem(signUpresult.ErrorList.FirstOrDefault().ErrorMessage.ToString(), null, 500);
                }

           
        }

        /// <summary>
        /// Add or register new user
        /// </summary>
        /// <param name="userSignIn">The submitted user details</param>
        /// <returns>returns action result</returns>
        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] UserSignIn userSignIn)
        {       //Call the createUserAsync method to register the new user
                var signInResult = await _authBusiness.SignIn(userSignIn);

                if(signInResult.Status)
                {
                     return Ok();
                }
                else
                {
                  return BadRequest(signInResult.Message);
                }

        }
        
        /// <summary>
        ///  Create a new role
        /// </summary>
        /// <param name="roleName"> New role name</param>
        /// <returns></returns>
        [HttpPost("Roles")]
        public async Task<IActionResult> CreateRole ([FromBody] string roleName)
        {
           //add the new role to the context
           var result = await _authBusiness.CreateRole(roleName);

           if(result.Status)
           {
              return Created( new Uri($"Roles/{roleName}"),roleName);
           }
           else
           {
             
             return Problem(result.ErrorList.FirstOrDefault().ErrorMessage,null,500);
           }

        }

        [HttpPost("user/{userEmail}/Role")]
        public async Task<IActionResult> AddRoleToUser (string userEmail,[FromBody] string roleName)
        {
              var result = await _authBusiness.AddUserToRole(userEmail,roleName);

              if(result.Status)
              {
                return Ok();
              }
              else
              {
                return Problem(result.ErrorList.FirstOrDefault().ErrorMessage,null,500);
              }
        }
    }
}