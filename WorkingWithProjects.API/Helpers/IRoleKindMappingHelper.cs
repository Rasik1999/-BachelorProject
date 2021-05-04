using System.Collections.Generic;
using WorkingWithProjects.API.ViewModels;

namespace WorkingWithProjects.API.Helpers
{
    public interface IRoleKindMappingHelper
    {
        RoleKindViewModel MapToRoleKindView(int roleId, int kindId);
        List<RoleKindViewModel> MapToListRoleKindView();
    }
}
