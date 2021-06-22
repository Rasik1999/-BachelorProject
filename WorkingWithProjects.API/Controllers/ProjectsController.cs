using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IActionResult> GetAllProjectsAsync()
        {
            var projects = (await _projectRepository.GetAllProjects()).ToList();
            var result = _mapper.Map<List<ProjectViewModel>>(projects);

            await _projectsHelper.MappingForProjectViewModelAsync(result);

            return Ok(result);
        }

        [HttpGet("moderatedprojects")]
        public IActionResult GetAllModeratedProjects()
        {
            var projects = _projectRepository.GetAllModeratedProjects().ToList();
            var result = _mapper.Map<List<ProjectViewModel>>(projects);

            _projectsHelper.MappingForProjectViewModelAsync(result);

            return Ok(result);
        }

        [HttpGet("unmoderatedprojects")]
        public IActionResult GetAllUnmoderatedProjects()
        {
            var projects = _projectRepository.GetAllUnmoderatedProjects().ToList();
            var result = _mapper.Map<List<ProjectViewModel>>(projects);

            _projectsHelper.MappingForProjectViewModelAsync(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectByIdAsync(int id)
        {
            var projects = await _projectRepository.GetProjectById(id);
            var result = _mapper.Map<ProjectViewModel>(projects);

            try
            {
                var mapResult = await _projectsHelper.MappingForProjectViewModelAsync(new List<ProjectViewModel> { result });

                return Ok(mapResult.FirstOrDefault());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("bestprojects/{projectId}")]
        public async Task<IActionResult> GetBestProjectsAsync(int projectId)
        {
            var project = await _projectRepository.GetProjectById(projectId);

            if (project is null)
                return BadRequest("Current project is null");

            var mapResult = _mapper.Map<ProjectViewModel>(project);

            try
            {
                var bestProjects = await _projectsHelper.MappingForProjectViewModelAsync(new List<ProjectViewModel> { mapResult });

                bestProjects = await _projectsHelper.FindBestProjectsAsync(mapResult);

                return Ok(bestProjects);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("projectsforcategory/{categoryId}")]
        public async Task<IActionResult> GetProjectsForCategoryAsync(int categoryId)
        {
            var projects = await _projectRepository.GetAllProjects();
            projects = projects.Where(x => x.KindOfProjectId == categoryId);

            if (projects is null)
                return BadRequest("Current projects is null");

            var mapResult = _mapper.Map<List<ProjectViewModel>>(projects);

            await _projectsHelper.MappingForProjectViewModelAsync(mapResult);

            mapResult = mapResult.OrderByDescending(x => x.PercentageOfCompletion).ToList();

            return Ok(mapResult);
        }

        [HttpGet("projectsforuser/{userId}")]
        public async Task<IActionResult> GetProjectsForUserAsync(string userId)
        {
            var projects = _projectRepository.GetProjectsByUserId(userId);

            if (projects is null)
                return BadRequest("Current projects is null");

            var mapResult = _mapper.Map<List<ProjectViewModel>>(projects);

            await _projectsHelper.MappingForProjectViewModelAsync(mapResult);

            mapResult = mapResult.OrderByDescending(x => x.PercentageOfCompletion).ToList();

            return Ok(mapResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProjectAsync([FromBody] ProjectProgressViewModel projectViewModel)
        {
            var project = _mapper.Map<Project>(projectViewModel);
            var addedProject = await _projectRepository.AddProject(project);
            await _progressRepository.CreateProgress(project.ProjectId, projectViewModel.DesiredValue);

            var result = _mapper.Map<ProjectViewModel>(addedProject);

            await _projectsHelper.MappingForProjectViewModelAsync(new List<ProjectViewModel> { result });

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectAsync(int id, [FromBody] ProjectProgressViewModel projectViewModel)
        {
            var project = _mapper.Map<Project>(projectViewModel);
            project.ProjectId = id;
            var addedProject = _projectRepository.UpdateProject(project);
            var progress = await _progressRepository.GetProgressByProjectIdAsync(addedProject.ProjectId);
            progress.DesiredValue = projectViewModel.DesiredValue;
            _progressRepository.UpdateProgress(progress);

            var result = _mapper.Map<ProjectViewModel>(addedProject);

            await _projectsHelper.MappingForProjectViewModelAsync(new List<ProjectViewModel> { result });

            return Ok(result);
        }

        [HttpPut("moderate/{id}")]
        public async Task<IActionResult> ModerateProjectAsync(int id)
        {
            var project = await _projectRepository.GetProjectById(id);
            project.IsModerated = true;
            var result = _projectRepository.UpdateProject(project);

            return Ok(result);
        }

        [HttpPut("unmoderate/{id}")]
        public async Task<IActionResult> UnModerateProjectAsync(int id)
        {
            var project = await _projectRepository.GetProjectById(id);
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
