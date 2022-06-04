using Business.DTO;
using Business.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

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
        private readonly IAuthBusiness _authBusiness;

        private readonly IUserBusiness _userBusiness;

        /// <summary>
        /// The default controller constructor
        /// </summary>
        /// <param name="authBusiness">The injected authentiation business class dependency</param>
        public AuthController(IAuthBusiness authBusiness, IUserBusiness userBusiness)
        {
            _authBusiness = authBusiness;
            _userBusiness = userBusiness;
        }

        /// <summary>
        /// Add or register new user
        /// </summary>
        /// <param name="userSignUp">The submitted user details</param>
        /// <returns>returns action result</returns>
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] UserSignUp userSignUp)
        {       //Call the createUserAsync method to register the new user
            var signUpresult = await _userBusiness.CreateUserAsync(userSignUp);

            if (signUpresult.Status)
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
        public async Task<IActionResult> GetToken(UserSignIn userSignIn)
        {       //Call the createUserAsync method to register the new user
            var result = await _userBusiness.SignIn(userSignIn);

            if (result.Status)
            {
                return Ok(result.AuthToken);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}