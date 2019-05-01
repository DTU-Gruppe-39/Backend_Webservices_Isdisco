using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Isdisco_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Isdisco_Web_API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/user
        [HttpGet]
        public List<User> Get()
        {
            return null;
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return null;
        }

        // POST api/user
        [HttpPost]
        public void Post(User user)
        {
        }

        // PUT api/user/5
        [HttpPut]
        public void Put(User user)
        {
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
