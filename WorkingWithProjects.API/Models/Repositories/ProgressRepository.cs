using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<Progress> CreateProgress(int projectId, decimal value)
        {
            Progress newProgress = new Progress() { ProjectId = projectId, DesiredValue = value };

            var result = _context.Progresses.Add(newProgress).Entity;

            await _context.SaveChangesAsync();

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

        public async Task<Progress> GetProgressByProjectIdAsync(int projectId)
        {
            try
            {
                var something = await _context.Progresses.FirstOrDefaultAsync(x => x.ProjectId == projectId);
                return something;
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return await Task.FromResult(new Progress());
            }
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
