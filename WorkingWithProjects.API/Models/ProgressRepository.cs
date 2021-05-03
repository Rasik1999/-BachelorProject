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

        public Progress CreateProgress(int projectId)
        {
            Progress newProgress = new Progress() { ProjectId = projectId };

            var result = _context.Progresses.Add(newProgress).Entity;

            _context.SaveChanges();

            return result;
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

            var result = _context.Progresses.Update(progress).Entity;

            _context.SaveChanges();

            return result;
        }
    }
}
