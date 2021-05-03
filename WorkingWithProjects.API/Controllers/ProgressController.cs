using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WorkingWithProjects.API.Models;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgressController : ControllerBase
    {
        private readonly IProgressRepository _progressRepository;

        public ProgressController(IProgressRepository progressRepository)
        {
            _progressRepository = progressRepository;
        }

        // GET: api/<ProgressController>
        [HttpGet]
        public IEnumerable<Progress> Get()
        {
            return _progressRepository.GetAllProgress();
        }

        // GET api/<ProgressController>/5
        [HttpGet("{id}")]
        public Progress Get(int id)
        {
            return _progressRepository.GetProgressById(id);
        }
    }
}
