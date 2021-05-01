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

        public IEnumerable<KindOfProject> GetAllKinds()
        {
            return _context.KindsOfProject;
        }

        public KindOfProject GetKindById(int kindId)
        {
            return _context.KindsOfProject.FirstOrDefault(x => x.KindOfProjectId == kindId);
        }
    }
}
