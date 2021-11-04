using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Business.Interface;
using System.Linq;
using System;

namespace Service.Controllers
{

   /// <summary>
   /// Role controller class
   /// </summary>
   [Route("api/[controller]")]
   [ApiController]
    public class RoleController: ControllerBase
    {
        
       private readonly IRoleBusiness _roleBusiness;

       public RoleController(IRoleBusiness roleBusiness)
        {
            _roleBusiness = roleBusiness;
        }
        
        /// <summary>
        ///  Create a new role
        /// </summary>
        /// <param name="roleName"> New role name</param>
        /// <returns></returns>
        [HttpPost("Role")]
        public async Task<IActionResult> CreateRole ([FromBody] string roleName)
        {
           //add the new role to the context
           var result = await _roleBusiness.CreateRole(roleName);

           if(result.Status)
           {
              return Created( new Uri($"Roles/{roleName}"),roleName);
           }
           else
           {
             
             return Problem(result.ErrorList.FirstOrDefault().ErrorMessage,null,500);
           }

        }

    }
}