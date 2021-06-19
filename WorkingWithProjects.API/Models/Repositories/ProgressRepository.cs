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

        public Progress CreateBlankProgress(int projectId)
        {
            Progress newProgress = new Progress() { ProjectId = projectId };

            var result = _context.Progresses.Add(newProgress).Entity;

            _context.SaveChanges();

            return result;
        }

        public Progress CreateProgress(int projectId, decimal value)
        {
            Progress newProgress = new Progress() { ProjectId = projectId, DesiredValue = value };

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
            var result = _context.Progresses.Update(progress);

            _context.SaveChanges();

            return result.Entity;
        }

        public Progress DeletePogress(int id)
        {
            var result =_context.Progresses.Remove(_context.Progresses.Where(x => x.ProgressId == id).FirstOrDefault()).Entity;

            _context.SaveChanges();

            return result;
        }
    }
}
