using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WorkingWithProjects.API.Models;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userRepository.GetAllUsers();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _userRepository.GetUserById(id);
        }
    }
}
