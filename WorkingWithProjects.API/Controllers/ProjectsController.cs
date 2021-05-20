using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkingWithProjects.API.Models;
using WorkingWithProjects.API.Models.ViewModel;
using WorkingWithProjects.API.ViewModels;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.API.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IProgressRepository _progressRepository;
        private readonly IHashtagRepository _hashtagRepository;
        private readonly IKindOfProjectRepository _kindOfProjectRepository;
        private IMapper _mapper { get; set; }

        public ProjectsController(
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

        [HttpGet]
        public IActionResult GetAllProjects()
        {
            var projects = _projectRepository.GetAllProjects().ToList();
            var result = _mapper.Map<List<ProjectViewModel>>(projects);

            MappingForProjectViewModel(result);

            return Ok(result);
        }

        [HttpGet ("moderated")]
        public IActionResult GetAllModeratedProjects()
        {
            var projects = _projectRepository.GetAllModeratedProjects().ToList();
            var result = _mapper.Map<List<ProjectViewModel>>(projects);

            MappingForProjectViewModel(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetProjectById(int id)
        {
            var projects = _projectRepository.GetProjectById(id);
            var result = _mapper.Map<ProjectViewModel>(projects);

            MappingForProjectViewModel(new List<ProjectViewModel> { result });

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateProject([FromBody] ProjectProgressViewModel projectViewModel)
        {
            var project = _mapper.Map<Project>(projectViewModel);
            var addedProject = _projectRepository.AddProject(project);
            _progressRepository.CreateProgress(project.ProjectId, projectViewModel.DesiredValue);

            var result = _mapper.Map<ProjectViewModel>(addedProject);

            MappingForProjectViewModel(new List<ProjectViewModel> { result });

            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult PutProject(int id, [FromBody] ProjectProgressViewModel projectViewModel)
        {
            var project = _mapper.Map<Project>(projectViewModel);
            project.ProjectId = id;
            var addedProject = _projectRepository.UpdateProject(project);
            var progress = _progressRepository.GetProgressByProjectId(addedProject.ProjectId);
            progress.DesiredValue = projectViewModel.DesiredValue;
            _progressRepository.UpdateProgress(progress);

            var result = _mapper.Map<ProjectViewModel>(addedProject);

            MappingForProjectViewModel(new List<ProjectViewModel> { result });

            return Ok(result);
        }

        [HttpPut("moderate/{id}")]
        public IActionResult ModerateProject(int id)
        {
            var project = _projectRepository.GetProjectById(id);
            project.IsModerated = true;
            var result =_projectRepository.UpdateProject(project);

            return Ok(result);
        }

        [HttpPut("unmoderate/{id}")]
        public IActionResult UnModerateProject(int id)
        {
            var project = _projectRepository.GetProjectById(id);
            project.IsModerated = false;
            var result = _projectRepository.UpdateProject(project);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
            var result = _projectRepository.DeleteProject(id);

            return Ok(result);
        }

        private List<ProjectViewModel> MappingForProjectViewModel(List<ProjectViewModel> projectViewModels)
        {
            foreach (var item in projectViewModels)
            {
                //Adding progress values
                var progress = _progressRepository.GetProgressByProjectId(item.ProjectId);

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

                    var hashtags = _hashtagRepository.GetHashtagsByIds(ids.First(), ids.Last());

                    if (hashtags != null)
                    {
                        foreach (var hashtagId in ids)
                        {
                            item.HashtagNames.Add(hashtags.Where(x => x.HashtagId == hashtagId).Select(x => x.Name).First());
                        }
                    }
                }

                //Adding KindOfProject name
                item.KindOfProjectName = _kindOfProjectRepository.GetKindById(item.KindOfProjectId).Name;
            }

            return projectViewModels;
        }
    }
}
