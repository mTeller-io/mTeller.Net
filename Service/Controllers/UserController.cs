using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Business;
using Business.DTO;
using Business.Interface;

namespace Service.Controllers
{
    /// <summary>
    /// User controller class
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;
        public UserController(UserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }
           
            /// <summary>
        /// Add or register new user
        /// </summary>
        /// <param name="userSignUp">The submitted user details</param>
        /// <returns>returns action result</returns>
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp ([FromBody] UserSignUp userSignUp)
        {       //Call the createUserAsync method to register the new user
                var signUpresult = await _userBusiness.CreateUserAsync(userSignUp);

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
        /// 
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>

         [HttpPost("user/{userEmail}/Role")]
        public async Task<IActionResult> AddRoleToUser (string userEmail,[FromBody] string roleName)
        {
              var result = await _userBusiness.AddRoleToUser(userEmail,roleName);

              if(result.Status)
              {
                return Ok();
              }
              else
              {
                return Problem(result.ErrorList.FirstOrDefault().ErrorMessage,null,500);
              }
        }
        
        /*  [HttpGet]
        public async Task<IActionResult> Get()
        {



        } */

        
        
    }

      
}