using Business.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IUserBusiness
    {
        //Add new user
        Task<OperationalResult<UserDetail>> CreateUserAsync(UserSignUp userSignUp);

        Task<IdentityResult> CreateUserAsync(User user, string password);

        Task<OperationalResult<UserDetail>> SignIn(UserSignIn userSignIn);

        Task<OperationalResult<UserDetail>> AddRoleToUser(string userEmail, string roleName);

        Task<OperationalResult<IList<UserDetail>>> Get(UserSearchParameter userSearchParameter, int pageSize, int pageNo);
    }
}