using System.Collections.Generic;
using System.Threading.Tasks;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.API.Models
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllProjects();
        IEnumerable<Project> GetAllModeratedProjects();
        IEnumerable<Project> GetAllUnmoderatedProjects();
        Task<Project> GetProjectById(int projectId);
        List<Project> GetProjectsByUserId(string userId);
        Task<Project> AddProject(Project project);
        Project UpdateProject(Project project);
        Project DeleteProject(int projectId);
    }
}
