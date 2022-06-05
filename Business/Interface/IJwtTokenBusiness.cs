using DataAccess.Models;
using System.Collections.Generic;

namespace Business.Interface
{
    /// <summary>
    /// The interface class for IJwtTokenBusiness
    /// </summary>
    public interface IJwtTokenBusiness
    {
        string GenerateJwt(User user, IList<string> roles);
    }
}