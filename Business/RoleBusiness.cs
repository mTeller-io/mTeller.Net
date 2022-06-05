using Business.DTO;
using Business.Interface;
using DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Business
{
    public class RoleBusiness : IRoleBusiness
    {
        private readonly RoleManager<Role> _roleManager;

        public RoleBusiness(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        /// <summary>
        /// Add a new role
        /// </summary>
        /// <param name="roleName">The name of the new role</param>
        /// <returns></returns>
        public async Task<OperationalResult<Role>> CreateRole(string roleName)
        {
            //initialise result
            var result = new OperationalResult<Role>
            {
                Status = false
            };

            //Check for null or empty string
            if (!String.IsNullOrWhiteSpace(roleName))
            {
                var newRole = new Role
                {
                    Name = roleName
                };

                //Create new role
                var roleResult = await _roleManager.CreateAsync(newRole);

                if (roleResult.Succeeded)
                {
                    result.Status = true;
                    result.Message = $"New role {newRole} created successfully";
                }
                else
                {
                    //Set the status to false
                    result.Status = false;
                    //Get error from identity operation
                    var lsErr = roleResult.Errors;
                    //Convert and assign identity error to custom error object.
                    result.ErrorList.AddRange(lsErr.Select(x => new Error
                    {
                        ErrorCode = x.Code,
                        ErrorMessage = x.Description
                    }));

                    result.Message = $"Sorry. Unable to create new role {newRole}.Please try again";
                }
            }
            else
            {
                result.Message = "New role name cannot be null or empty";
            }

            return result;
        }
    }
}