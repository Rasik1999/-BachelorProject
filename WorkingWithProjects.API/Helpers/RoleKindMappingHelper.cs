using System.Collections.Generic;
using System.Linq;
using WorkingWithProjects.API.Models;
using WorkingWithProjects.API.ViewModels;

namespace WorkingWithProjects.API.Helpers
{
    public class RoleKindMappingHelper : IRoleKindMappingHelper
    {
        private ContextDB _context;
        public RoleKindMappingHelper(ContextDB context)
        {
            _context = context;
        }

        public RoleKindViewModel MapToRoleKindView(int roleId, int kindId)
        {
            var role = _context.Roles.Where(x => x.RoleId == roleId).FirstOrDefault();
            var kind = _context.KindsOfProject.Where(x => x.KindOfProjectId == kindId).FirstOrDefault();

            RoleKindViewModel viewModel = new RoleKindViewModel()
            {
                RoleId = role.RoleId,
                RoleValue = role.Name,
                KindId = kind.KindOfProjectId,
                KindValue = kind.Name
            };

            return viewModel;
        }

        public List<RoleKindViewModel> MapToListRoleKindView()
        {
            List<RoleKindViewModel> roleKindViewModels = new List<RoleKindViewModel>();

            var roles = _context.Roles;
            var kinds = _context.KindsOfProject;

            foreach (var role in roles)
            {
                var listOfCollisions = kinds.Where(x => x.KindOfProjectRoles.Where(y => y.RoleId == role.RoleId).Any());

                foreach (var kind in listOfCollisions)
                {
                    roleKindViewModels.Add(MapToRoleKindView(role.RoleId, kind.KindOfProjectId));
                }
            }

            return roleKindViewModels;
        }

        public List<RoleKindViewModel> MapToListKindsForRoleView(int roleId)
        {
            List<RoleKindViewModel> roleKindViewModels = new List<RoleKindViewModel>();

            var role = _context.Roles.Where(x => x.RoleId == roleId).FirstOrDefault();
            var kinds = _context.KindsOfProject;

            var listOfCollisions = kinds.Where(x => x.KindOfProjectRoles.Where(y => y.RoleId == role.RoleId).Any());

            foreach (var kind in listOfCollisions)
            {
                roleKindViewModels.Add(MapToRoleKindView(role.RoleId, kind.KindOfProjectId));
            }

            return roleKindViewModels;
        }

        public List<RoleKindViewModel> MapToListRolesForKindView(int kindId)
        {
            List<RoleKindViewModel> roleKindViewModels = new List<RoleKindViewModel>();

            var roles = _context.Roles;
            var kind = _context.KindsOfProject.Where(x => x.KindOfProjectId == kindId).FirstOrDefault();

            var listOfCollisions = roles.Where(x => x.KindOfProjectRoles.Where(y => y.KindId == kind.KindOfProjectId).Any());

            foreach (var role in listOfCollisions)
            {
                roleKindViewModels.Add(MapToRoleKindView(role.RoleId, kind.KindOfProjectId));
            }

            return roleKindViewModels;
        }
    }
}
