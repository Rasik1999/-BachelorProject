using System.Collections.Generic;
using System.Linq;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.API.Models
{
    public class ProgressRepository : IProgressRepository
    {
        private readonly ContextDB _context;

        public ProgressRepository(ContextDB context)
        {
            _context = context;
        }

        public IEnumerable<Progress> GetAllProgress()
        {
            return _context.Progresses;
        }

        public Progress GetProgressById(int progressId)
        {
            return _context.Progresses.FirstOrDefault(x => x.ProgressId == progressId);
        }

        public Progress GetProgressByProjectId(int projectId)
        {
            return _context.Progresses.FirstOrDefault(x => x.ProjectId == projectId);
        }

        public Progress UpdateProgress(Progress progress)
        {
            _context.Progresses.Update(progress);

            return _context.Progresses.Update(progress).Entity;
        }
    }
}
