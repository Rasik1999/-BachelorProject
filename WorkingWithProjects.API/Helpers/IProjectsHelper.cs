using System.Collections.Generic;
using System.Threading.Tasks;
using WorkingWithProjects.API.Models.ViewModel;

namespace WorkingWithProjects.API.Helpers
{
    public interface IProjectsHelper
    {
        List<ProjectViewModel> MappingForProjectViewModel(List<ProjectViewModel> projectViewModels);
        List<ProjectViewModel> FindBestProjects(ProjectViewModel mapResult);
        public void GenerateCollisions(
            ProjectViewModel goodProject,
            Dictionary<ProjectViewModel, int> projectsDictionary,
            ProjectViewModel originalProject);
    }
}
