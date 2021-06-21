using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.API.Models
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ContextDB _context;

        public ProjectRepository(ContextDB context)
        {
            _context = context;
        }

        public async Task<Project> AddProject(Project project)
        {
            Validate(project);

            var addedEntity = _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return addedEntity.Entity;
        }

        private void Validate(Project project)
        {
            try
            {
                var hashtagIds = project.HashtagIds.Split(",");

                foreach (var id in hashtagIds)
                {
                    Int32.TryParse(id, out _);
                }
            }
            catch (Exception)
            {
                throw new Exception("Something wrong with hashtag`s ids");
            }
        }

        public async Task<Project> DeleteProject(int projectId)
        {
            var foundedProject = _context.Projects.FirstOrDefault(e => e.ProjectId == projectId);
            if (foundedProject == null) return null;

            var result = _context.Projects.Remove(foundedProject);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            return _context.Projects;
        }

        public async Task<Project> GetProjectById(int projectId)
        {
            return _context.Projects.FirstOrDefault(x => x.ProjectId == projectId);
        }

        public async Task<Project> GetProjectsByUserId(string userId)
        {
            return _context.Projects.FirstOrDefault(x => string.Equals(x.UserId, userId));
        }

        public async Task<Project> UpdateProject(Project project)
        {
            var foundedProject = _context.Projects.FirstOrDefault(e => e.ProjectId == project.ProjectId);

            if (foundedProject != null)
            {
                foundedProject.UserId = project.UserId;
                foundedProject.Title = project.Title;
                foundedProject.Description = project.Description;
                foundedProject.KindOfProjectId = project.KindOfProjectId;
                foundedProject.Photo = project.Photo;
                foundedProject.HashtagIds = project.HashtagIds;

                _context.SaveChanges();

                return foundedProject;
            }

            return null;
        }

        public IEnumerable<Project> GetAllModeratedProjects()
        {
            return _context.Projects.Where(x => x.IsModerated);
        }

        public IEnumerable<Project> GetAllUnmoderatedProjects()
        {
            return _context.Projects.Where(x => !x.IsModerated);
        }
    }
}
