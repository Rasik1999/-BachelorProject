using Microsoft.AspNetCore.Mvc;
using WorkingWithProjects.API.Models;

namespace WorkingWithProjects.API.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectsController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            return Ok(_projectRepository.GetAllProjects());
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            return Ok(_projectRepository.GetProjectById(id));
        }
    }
}
