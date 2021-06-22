using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public KindOfProject AddKind(KindOfProject kind)
        {
            var result = _context.KindsOfProject.Add(kind);
            _context.SaveChanges();

            return result.Entity;
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

        public KindOfProject DeleteKind(int id)
        {
            var kind = _context.KindsOfProject.Where(x => x.KindOfProjectId == id).FirstOrDefault();
            var result = _context.KindsOfProject.Remove(kind);
            _context.SaveChanges();

            return result.Entity;
        }

        public IEnumerable<KindOfProject> GetAllKinds()
        {
            return _context.KindsOfProject;
        }

        public IEnumerable<KindOfProject> GetAllKindsForRole(int roleId)
        {
            return _context.KindsOfProject.Where(x => x.KindOfProjectRoles.Where(y => y.RoleId == roleId) != null);
        }

        public async Task<KindOfProject> GetKindById(int kindId)
        {
            return await _context.KindsOfProject.FirstOrDefaultAsync(x => x.KindOfProjectId == kindId);
        }

        public KindOfProject UpdateKind(KindOfProject kind)
        {
            var result = _context.KindsOfProject.Update(kind);
            _context.SaveChanges();

            return result.Entity;
        }
    }
}
