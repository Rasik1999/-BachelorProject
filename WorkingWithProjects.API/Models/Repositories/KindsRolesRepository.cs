using System;
using System.Collections.Generic;
using System.Linq;
using WorkingWithProjects.API.Helpers;
using WorkingWithProjects.API.ViewModels;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.API.Models
{
    public class KindsRolesRepository : IKindsRolesRepository
    {
        private readonly IRoleKindMappingHelper _mappingHelper;
        private readonly ContextDB _context;

        public KindsRolesRepository(ContextDB context, IRoleKindMappingHelper mappingHelper)
        {
            _context = context;
            _mappingHelper = mappingHelper;
        }

        public bool TryToCreateRoleKind(int kindId, int roleId)
        {
            try
            {
                KindOfProject kind = _context.KindsOfProject.Where(x => x.KindOfProjectId == kindId).FirstOrDefault();
                Role role = _context.Roles.Where(x => x.RoleId == roleId).FirstOrDefault();

                kind.KindOfProjectRoles.Add(new KindOfProjectRole() { RoleId = role.RoleId, KindId = kind.KindOfProjectId });

                _context.KindsOfProject.Update(kind);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public IEnumerable<RoleKindViewModel> GetAllKindsRoles()
        {
            return _mappingHelper.MapToListRoleKindView();
        }

        public IEnumerable<RoleKindViewModel> GetAllRolesForKind(int kindId)
        {
            return _mappingHelper.MapToListRolesForKindView(kindId);
        }

        public IEnumerable<RoleKindViewModel> GetAllKindsForRole(int roleId)
        {
            return _mappingHelper.MapToListRolesForKindView(roleId);
        }

        public RoleKindViewModel GetRoleKind(int kindId, int roleId)
        {
            return _mappingHelper.MapToRoleKindView(roleId, kindId);
        }
    }
}
