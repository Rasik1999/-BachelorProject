using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkingWithProjects.API.Models;
using WorkingWithProjects.API.Models.ViewModel;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.API.Helpers
{
    public class ProjectsHelper : IProjectsHelper
    {
        private static IProjectRepository _projectRepository;
        private static IProgressRepository _progressRepository;
        private static IHashtagRepository _hashtagRepository;
        private static IKindOfProjectRepository _kindOfProjectRepository;
        private static IMapper _mapper { get; set; }

        public ProjectsHelper(
            IProjectRepository projectRepository,
            IMapper mapper,
            IHashtagRepository hashtagRepository,
            IProgressRepository progressRepository,
            IKindOfProjectRepository kindOfProjectRepository)
        {
            _projectRepository = projectRepository;
            _progressRepository = progressRepository;
            _hashtagRepository = hashtagRepository;
            _kindOfProjectRepository = kindOfProjectRepository;
            _mapper = mapper;
        }

        public async Task<List<ProjectViewModel>> MappingForProjectViewModelAsync(List<ProjectViewModel> projectViewModels)
        {
            foreach (var item in projectViewModels)
            {
                //Adding progress values
                Progress progress = new Progress();
                try
                {
                    progress = await _progressRepository.GetProgressByProjectIdAsync(item.ProjectId);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                if (progress != null)
                {
                    item.ProgressId = progress.ProgressId;
                    item.DesiredValue = progress.DesiredValue;
                    item.ProgressValue = progress.Value;
                    item.PercentageOfCompletion = Math.Round(progress.Value / progress.DesiredValue * 100, 2);
                }

                //Adding hashtag names to list
                var ids = item.HashtagIds is null ? null : Array.ConvertAll(item.HashtagIds.Split(","), int.Parse).ToList();

                if (ids != null)
                {
                    ids.Sort();

                    var hashtags = await _hashtagRepository.GetHashtagsByIds(ids.First(), ids.Last());

                    if (hashtags != null)
                    {
                        foreach (var hashtagId in ids)
                        {
                            item.HashtagNames.Add(hashtags.Where(x => x.HashtagId == hashtagId).Select(x => x.Name).First());
                        }
                    }
                }

                //Adding KindOfProject name
                item.KindOfProjectName = (await _kindOfProjectRepository.GetKindById(item.KindOfProjectId)).Name;
            }

            return projectViewModels;
        }

        public async Task<List<ProjectViewModel>> FindBestProjectsAsync(ProjectViewModel mapResult)
        {
            var projects = (await _projectRepository.GetAllProjects()).ToList();

            var mapResultForListOfAllProjects = _mapper.Map<List<ProjectViewModel>>(projects);

            await MappingForProjectViewModelAsync(mapResultForListOfAllProjects);

            Dictionary<ProjectViewModel, int> projectsDictionary = new Dictionary<ProjectViewModel, int>();

            foreach (var project in mapResultForListOfAllProjects)
            {
                if (project.ProjectId == mapResult.ProjectId) continue;
                projectsDictionary.Add(project, 0);

                GenerateCollisions(project, projectsDictionary, mapResult);
            }

            int i = 0;
            List<ProjectViewModel> bestProjects = new List<ProjectViewModel>();
            foreach (var result in projectsDictionary.OrderByDescending(key => key.Value))
            {
                if (i < 3)
                {
                    bestProjects.Add(result.Key);
                    i++;
                }
                else break;
            }

            return bestProjects;
        }

        public void GenerateCollisions(
            ProjectViewModel goodProject,
            Dictionary<ProjectViewModel, int> projectsDictionary,
            ProjectViewModel originalProject)
        {
            if (goodProject.KindOfProjectId == originalProject.KindOfProjectId)
            {
                projectsDictionary[goodProject]++;
            }

            projectsDictionary[goodProject] += goodProject.HashtagNames.Select(x => originalProject.HashtagNames.Contains(x)).Count();
        }
    }
}
