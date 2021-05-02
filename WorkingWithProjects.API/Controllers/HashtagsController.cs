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
    public class HashtagsController : ControllerBase
    {
        private readonly IHashtagRepository _hashtagRepository;

        public HashtagsController(IHashtagRepository hashtagRepository)
        {
            _hashtagRepository = hashtagRepository;
        }
        // GET: api/<HashtagsController>
        [HttpGet]
        public IEnumerable<Hashtag> Get()
        {
            return _hashtagRepository.GetAllHashtags();
        }

        // GET api/<HashtagsController>/5
        [HttpGet("{id}")]
        public Hashtag Get(int id)
        {
            return _hashtagRepository.GetHashtagById(id);
        }

        // POST api/<HashtagsController>
        [HttpPost("{Name}")]
        public Hashtag Post(string Name)
        {
            Hashtag newHashtag = new Hashtag { Name = Name };

            return _hashtagRepository.AddHashtag(newHashtag);
        }

        // PUT api/<HashtagsController>/5
        [HttpPut]
        public Hashtag Put([FromBody] Hashtag hashtag)
        {
            return _hashtagRepository.UpdateHashtag(hashtag);
        }

        // DELETE api/<HashtagsController>/5
        [HttpDelete("{id}")]
        public Hashtag Delete(int id)
        {
            return _hashtagRepository.DeleteHashtag(id);
        }
    }
}
