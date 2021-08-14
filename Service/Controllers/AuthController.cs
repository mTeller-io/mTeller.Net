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
        /// <param name="authBusiness">The injeted authentiation business class dependency</param>
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
        public async Task<IActionResult> SignUp (UserSignUp userSignUp)
        {       //Call the createUserAsync method to register the new user
                var signUpresult = await _authBusiness.CreateUserAsync(userSignUp);

                if(signUpresult.Status)
                {
                     return Created(string.Empty, string.Empty);
                }
                else
                {
                  return Problem(signUpresult.Data.First().ToString(), null, 500);
                }

           
        }

        /// <summary>
        /// Add or register new user
        /// </summary>
        /// <param name="userSignIn">The submitted user details</param>
        /// <returns>returns action result</returns>
        [HttpPost("signin")]
        public async Task<IActionResult> SignUp (UserSignIn userSignIn)
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
    }
}