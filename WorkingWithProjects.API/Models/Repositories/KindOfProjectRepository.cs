using System;
using System.Collections.Generic;
using System.Linq;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.API.Models
{
    public class KindOfProjectRepository : IKindOfProjectRepository
    {
        private readonly ContextDB _context;

        public KindOfProjectRepository(ContextDB context)
        {
            _context = context;
        }

        public bool CreateRelationship(int roleId, int kindId)
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

        public IEnumerable<KindOfProject> GetAllKinds()
        {
            return _context.KindsOfProject;
        }

        public IEnumerable<KindOfProject> GetAllKindsForRole(int roleId)
        {
            return _context.KindsOfProject.Where(x => x.KindOfProjectRoles.Where(y => y.RoleId == roleId) != null);
        }

        public KindOfProject GetKindById(int kindId)
        {
            return _context.KindsOfProject.FirstOrDefault(x => x.KindOfProjectId == kindId);
        }
    }
}
