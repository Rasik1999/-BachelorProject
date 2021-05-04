using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WorkingWithProjects.API.Helpers;
using WorkingWithProjects.API.Models;
using WorkingWithProjects.API.ViewModels;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KindOfProjectController : ControllerBase
    {
        private readonly IKindOfProjectRepository _kindOfProjectRepository;
        private readonly IRoleKindMappingHelper _mappingHelper;

        public KindOfProjectController(IKindOfProjectRepository kindOfProjectRepository, IRoleKindMappingHelper mappingHelper)
        {
            _kindOfProjectRepository = kindOfProjectRepository;
            _mappingHelper = mappingHelper;
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

        [HttpPut("connectroletokind/{roleid},{kindid}")]
        public bool PutRoleToKind(int roleid, int kindid)
        {
            return _kindOfProjectRepository.CreateRelationship(roleid, kindid);
        }

        [HttpGet("showallroletokind")]
        public List<RoleKindViewModel> ShowAllRoleToKind()
        {
            return _mappingHelper.MapToListRoleKindView();
        }
    }
}
