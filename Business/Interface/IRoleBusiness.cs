using System.Threading.Tasks;
using Business.DTO;

namespace Business.Interface
{
    public interface IRoleBusiness
    {
         Task<OperationalResult> CreateRole(string roleName);
    }
}