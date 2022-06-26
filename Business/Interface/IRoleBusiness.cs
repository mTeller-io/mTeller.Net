using Business.DTO;
using DataAccess.Models;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IRoleBusiness
    {
        Task<OperationalResult<Role>> CreateRole(string roleName);
    }
}