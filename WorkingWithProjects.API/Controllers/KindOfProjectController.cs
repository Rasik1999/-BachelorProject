using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WorkingWithProjects.API.Models;
using WorkingWithProjects.DATA;

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

        [HttpPut]
        public KindOfProject PutKind([FromBody] KindOfProject kind)
        {
            return _kindOfProjectRepository.UpdateKind(kind);
        }

        // POST: api/Role
        [HttpPost]
        public KindOfProject PostKind([FromBody] KindOfProject kind)
        {
            return _kindOfProjectRepository.AddKind(kind);
        }

        // DELETE: api/Role/5
        [HttpDelete("{id}")]
        public KindOfProject DeleteKind(int id)
        {
            return _kindOfProjectRepository.DeleteKind(id);
        }
    }
}
