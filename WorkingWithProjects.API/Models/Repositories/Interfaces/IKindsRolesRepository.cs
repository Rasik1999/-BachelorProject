using System.Collections.Generic;
using WorkingWithProjects.API.ViewModels;

namespace WorkingWithProjects.API.Models
{
    public interface IKindsRolesRepository
    {
        IEnumerable<RoleKindViewModel> GetAllKindsRoles();
        IEnumerable<RoleKindViewModel> GetAllKindsForRole(int roleId);
        IEnumerable<RoleKindViewModel> GetAllRolesForKind(int kindId);
        RoleKindViewModel GetRoleKind(int kindId, int roleId);
        bool TryToCreateRoleKind(int kindId, int roleId);
    }
}
