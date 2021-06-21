using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkingWithProjects.API.Helpers;
using WorkingWithProjects.API.Models;
using WorkingWithProjects.API.Models.ViewModel;
using WorkingWithProjects.API.ViewModels;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.API.Controllers
{
    [Route("api/[controller]"), EnableCors("CorsPolicy")]
    public class ProjectsController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IProgressRepository _progressRepository;
        private readonly IProjectsHelper _projectsHelper;
        private IMapper _mapper { get; set; }

        public ProjectsController(
            IProjectRepository projectRepository,
            IMapper mapper,
            IProgressRepository progressRepository,
            IProjectsHelper projectsHelper)
        {
            _projectRepository = projectRepository;
            _progressRepository = progressRepository;
            _mapper = mapper;
            _projectsHelper = projectsHelper;
        }

        [HttpGet]
        public IActionResult GetAllProjects()
        {
            var projects = _projectRepository.GetAllProjects().ToList();
            var result = _mapper.Map<List<ProjectViewModel>>(projects);

            _projectsHelper.MappingForProjectViewModel(result);

            return Ok(result);
        }

        [HttpGet ("moderatedprojects")]
        public IActionResult GetAllModeratedProjects()
        {
            var projects = _projectRepository.GetAllModeratedProjects().ToList();
            var result = _mapper.Map<List<ProjectViewModel>>(projects);

            _projectsHelper.MappingForProjectViewModel(result);

            return Ok(result);
        }

        [HttpGet("unmoderatedprojects")]
        public IActionResult GetAllUnmoderatedProjects()
        {
            var projects = _projectRepository.GetAllUnmoderatedProjects().ToList();
            var result = _mapper.Map<List<ProjectViewModel>>(projects);

            _projectsHelper.MappingForProjectViewModel(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetProjectById(int id)
        {
            var projects = _projectRepository.GetProjectById(id);
            var result = _mapper.Map<ProjectViewModel>(projects);

            _projectsHelper.MappingForProjectViewModel(new List<ProjectViewModel> { result });

            return Ok(result);
        }

        [HttpGet("bestprojects/{projectId}")]
        public IActionResult GetBestProjects(int projectId)
        {
            var project = _projectRepository.GetProjectById(projectId);

            if (project is null)
                return BadRequest("Current project is null");

            var mapResult = _mapper.Map<ProjectViewModel>(project);

            _projectsHelper.MappingForProjectViewModel(new List<ProjectViewModel> { mapResult });

            var bestProjects = _projectsHelper.FindBestProjects(mapResult);

            return Ok(bestProjects);
        }

        [HttpGet("projectsforcategory/{categoryId}")]
        public IActionResult GetProjectsForCategory(int categoryId)
        {
            var projects = _projectRepository.GetAllProjects().Where(x => x.KindOfProjectId == categoryId);

            if (projects is null)
                return BadRequest("Current projects is null");

            var mapResult = _mapper.Map<List<ProjectViewModel>>(projects);

            _projectsHelper.MappingForProjectViewModel(mapResult);

            mapResult = mapResult.OrderByDescending(x => x.PercentageOfCompletion).ToList();

            return Ok(mapResult);
        }

        [HttpPost]
        public IActionResult CreateProject([FromBody] ProjectProgressViewModel projectViewModel)
        {
            var project = _mapper.Map<Project>(projectViewModel);
            var addedProject = _projectRepository.AddProject(project);
            _progressRepository.CreateProgress(project.ProjectId, projectViewModel.DesiredValue);

            var result = _mapper.Map<ProjectViewModel>(addedProject);

            _projectsHelper.MappingForProjectViewModel(new List<ProjectViewModel> { result });

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

            _projectsHelper.MappingForProjectViewModel(new List<ProjectViewModel> { result });

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
    }
}
