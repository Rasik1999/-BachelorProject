using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkingWithProjects.API.Models;
using WorkingWithProjects.DATA;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkingWithProjects.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KindOfProjectController : ControllerBase
    {
        private readonly IKindOfProjectRepository _kindOfProjectRepository;

        public KindOfProjectController(IKindOfProjectRepository kindOfProjectRepository)
        {
            _kindOfProjectRepository = kindOfProjectRepository;
        }

        // GET: api/<KindOfProjectController>
        [HttpGet]
        public IEnumerable<KindOfProject> Get()
        {
            return _kindOfProjectRepository.GetAllKinds();
        }

        // GET api/<KindOfProjectController>/5
        [HttpGet("{id}")]
        public KindOfProject Get(int id)
        {
            return _kindOfProjectRepository.GetKindById(id);
        }
    }
}
