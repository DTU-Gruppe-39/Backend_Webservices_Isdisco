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
        public List<Musicrequest> Get()
        {
            return musicrequestController.GetAllMusicRequests();
        }
        
        // GET api/musicrequest/5
        [HttpGet("{id}")]
        public Musicrequest Get(int id)
        {
            return musicrequestController.GetMusicrequest(id);
        }

        // POST api/musicrequest
        [HttpPost]
        public void Post(Musicrequest musicRequest)
        {
            musicrequestController.AddMusicrequest(musicRequest);
        }

        // POST api/musicrequest/5
        [HttpPost("{id}/upvote")]
        public void Upvote(int id, int userid)
        {
        }

        // DELETE api/musicrequest/5
        [HttpDelete("{id}/upvote")]
        public void RemoveUpvote(int id, int userid)
        {
        }


        // PUT api/musicrequest/5
        [HttpPut("{id}/upvote")]
        public void Downvote(int id)
        { 
        }

        // PUT api/musicrequest/5
        [HttpPut("{id}/upvote")]
        public void RemoveDownvote(int id)
        {
        }

        // DELETE api/musicrequest/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
