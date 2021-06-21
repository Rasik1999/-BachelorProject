using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WorkingWithProjects.API.Models;
using WorkingWithProjects.API.ViewModels;

namespace WorkingWithProjects.API.Controllers
{
    [Route("api/[controller]"), EnableCors("CorsPolicy")]
    [ApiController]
    public class KindsRolesController : ControllerBase
    {
        private readonly IKindsRolesRepository _kindsRolesRepository;

        public KindsRolesController(IKindsRolesRepository kindRolesRepository)
        {
            _kindsRolesRepository = kindRolesRepository;
        }

        [HttpGet]
        public IEnumerable<RoleKindViewModel> Get()
        {
            return _kindsRolesRepository.GetAllKindsRoles();
        }

        [HttpGet("kindsforrole")]
        public IEnumerable<RoleKindViewModel> GetKindsForRole(int id)
        {
            return _kindsRolesRepository.GetAllKindsForRole(id);
        }

        [HttpGet("rolesforkind")]
        public IEnumerable<RoleKindViewModel> GetRolesForKind(int id)
        {
            return _kindsRolesRepository.GetAllRolesForKind(id);
        }

        [HttpGet("kindtorole")]
        public RoleKindViewModel GetRoleToKind(int roleId, int kindId)
        {
            return _kindsRolesRepository.GetRoleKind(kindId, roleId);
        }

        [HttpPost]
        public bool Post(int roleid, int kindid)
        {
            return _kindsRolesRepository.TryToCreateRoleKind(roleid, kindid);
        }
    }
}
