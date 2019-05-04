using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Isdisco_Web_API.Controllers.Businesslogic;
using Isdisco_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Isdisco_Web_API.Controllers.API
{
    [Route("api/musicrequest")]
    public class MusicrequestService : Controller
    {
        MusicrequestController musicrequestController = new MusicrequestController();

        // GET: api/musicrequest
        [HttpGet]
        public List<MusicRequest> Get()
        {
            return null;
        }

        // GET api/musicrequest/5
        [HttpGet("{id}")]
        public MusicRequest Get(int id)
        {
            return null;
        }

        // POST api/musicrequest
        [HttpPost]
        public void Post(MusicRequest musicRequest)
        {
        }

        // PUT api/musicrequest/5
        // Upvotes/downvotes
        [HttpPut("{id}")]
        public void Put(int id, int userid)
        {
        }

        // DELETE api/musicrequest/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
