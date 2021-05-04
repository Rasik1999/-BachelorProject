using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WorkingWithProjects.API.Helpers;
using WorkingWithProjects.API.Models;
using WorkingWithProjects.API.ViewModels;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IRoleKindMappingHelper _mappingHelper;

        public RoleController(IRoleRepository roleRepository, IRoleKindMappingHelper mappingHelper)
        {
            _roleRepository = roleRepository;
            _mappingHelper = mappingHelper;
        }

        // GET: api/Role
        [HttpGet]
        public IEnumerable<Role> GetRoles()
        {
            return _roleRepository.GetAllRoles();
        }

        // GET: api/Role/5
        [HttpGet("{id}")]
        public Role GetRole(int id)
        {
            return _roleRepository.GetRole(id);
        }

        // PUT: api/Role/5
        [HttpPut]
        public Role PutRole([FromBody] Role role)
        {
            return _roleRepository.UpdateRole(role);
        }

        // POST: api/Role
        [HttpPost]
        public Role PostRole([FromBody] Role role)
        {
            return _roleRepository.AddRole(role);
        }

        // DELETE: api/Role/5
        [HttpDelete("{id}")]
        public Role DeleteRole(int id)
        {
            return _roleRepository.DeleteRole(id);
        }

        [HttpPut("connectroletokind/{roleid},{kindid}")]
        public bool PutRoleToKind(int roleid, int kindid)
        {
            return _roleRepository.CreateRelationship(roleid, kindid);
        }

        [HttpGet("showallroletokind")]
        public List<RoleKindViewModel> ShowAllRoleToKind()
        {
            return _mappingHelper.MapToListRoleKindView();
        }
    }
}
