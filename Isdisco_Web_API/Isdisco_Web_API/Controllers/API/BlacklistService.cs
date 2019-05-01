using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Isdisco_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Isdisco_Web_API.Controllers.API
{
    [Route("api/blacklist")]
    public class BlacklistService : Controller
    {
        // GET: api/blacklist
        [HttpGet]
        public List<Blacklist> Get()
        {
            return null;
        }

        // GET api/blacklist/5
        [HttpGet("{id}")]
        public Blacklist Get(int id)
        {
            return null;
        }

        // POST api/blacklist
        [HttpPost]
        public void Post(Blacklist blacklist)
        {
        }

        // DELETE api/blacklist/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
