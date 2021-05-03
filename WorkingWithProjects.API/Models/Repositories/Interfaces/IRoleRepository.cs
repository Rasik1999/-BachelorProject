using System.Collections.Generic;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.API.Models
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetAllRoles();
        Role GetRole(int roleId);
        Role AddRole(Role role);
        Role UpdateRole(Role role);
        Role DeleteRole(int roleId);
        bool CreateRelationship(int roleId, int kindId);
    }
}
