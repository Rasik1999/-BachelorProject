using System.Collections.Generic;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.API.Models
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetAllProjects();
        Project GetProjectById(int projectId);
        Project GetProjectsByUserId(int userId);
        Project AddProject(Project project);
        Project UpdateProject(Project project);
        Project DeleteProject(int projectId);
    }
}
