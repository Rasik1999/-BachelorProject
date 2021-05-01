using System.Collections.Generic;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.API.Models
{
    public interface IProgressRepository
    {
        IEnumerable<Progress> GetAllProgress();
        Progress GetProgressById(int progressId);
        Progress GetProgressByProjectId(int projectId);
    }
}
