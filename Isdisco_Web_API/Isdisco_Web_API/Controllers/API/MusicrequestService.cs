using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Isdisco_Web_API.Controllers.Businesslogic;
using Isdisco_Web_API.Models;
using Isdisco_Web_API.Utility;
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
            throw new APIException(HttpStatusCode.NoContent,"Testing");

            return musicrequestController.GetMusicrequest(id);
        }

        // POST api/musicrequest
        [HttpPost]
        public void Post([FromBody] Musicrequest musicRequest)
        {
            musicrequestController.AddMusicrequest(musicRequest);
        }

        // POST api/musicrequest/5/upvote
        [HttpPut("{id}/upvote/{userid}")]
        public void Upvote(int id, int userid)
        {
            musicrequestController.UpvoteMusicrequest(id, userid);
        }

        // DELETE api/musicrequest/5/upvote
        [HttpDelete("{id}/upvote/{userid}")]
        public void RemoveUpvote(int id, int userid)
        {
            musicrequestController.RemoveUpvoteMusicrequest(id, userid);
        }


        // PUT api/musicrequest/5/downvote
        [HttpPut("{id}/downvote")]
        public void Downvote(int id)
        {
            musicrequestController.DownvoteMusicrequest(id);
        }

        // PUT api/musicrequest/5/downvote
        [HttpDelete("{id}/downvote")]
        public void RemoveDownvote(int id)
        {
            musicrequestController.RemoveDownvoteMusicrequest(id);
        }

        // DELETE api/musicrequest/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            musicrequestController.DeleteMusicrequest(id);
        }
    }
}
