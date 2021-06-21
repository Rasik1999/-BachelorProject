using System.Collections.Generic;
using System.Threading.Tasks;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.API.Models
{
    public interface IProgressRepository
    {
        IEnumerable<Progress> GetAllProgress();
        Progress GetProgressById(int progressId);
        Task<Progress> GetProgressByProjectId(int projectId);
        Progress UpdateProgress(Progress progress);
        Progress CreateBlankProgress(int projectId);
        Task<Progress> CreateProgress(int projectId, decimal value);
        Progress DeletePogress(int id);
    }
}
