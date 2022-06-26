using Business.DTO;
using Business.Exceptions;
using Business.Interface;
using DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using System;
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
            if (!string.IsNullOrWhiteSpace(roleName))
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
                    throw new ForbiddenException($"Sorry. Unable to create new role {newRole}.Please try again");
                }
            }
            else
            {
                throw new Exception("New role name cannot be null or empty");
            }

            return result;
        }
    }
}