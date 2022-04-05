using System.Threading.Tasks;
using Business.DTO;
using DataAccess.Models;

namespace Business.Interface
{
    public interface IRoleBusiness
    {
         Task<OperationalResult<Role>> CreateRole(string roleName);
    }
}