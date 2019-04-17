using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json.Linq;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Isdisco_Web_API.Controllers.API
{

    [Route("api/spotify-track")]
    public class SpotifyTrackService : Controller
    {
        private DAO.StorageSingleton storage = DAO.StorageSingleton.GetInstance();
        private SpotifyAuthController auth = new SpotifyAuthController();


        // GET: api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        [HttpGet("{id}")]
        public string GetTrack(String id)
        {
            Businesslogic.SpotifyControllerClass scc = new Businesslogic.SpotifyControllerClass();
            return scc.GetTrack(id);
        }

        [HttpGet("search/{songName}")]
        public string GetSearch(String songName)
        {
            Businesslogic.SpotifyControllerClass scc = new Businesslogic.SpotifyControllerClass();
            return scc.GetSearch(songName);
        }


        [HttpGet("currently-playing")]
        //[Produces("text/html")]
        public void GetCurrentlyPlayingScope()
        {
            Businesslogic.SpotifyControllerClass scc = new Businesslogic.SpotifyControllerClass();
            Response.Redirect(scc.GetCurrentlyPlayingScope());
        }


        [HttpGet("callback")]
        //[Produces("text/html")]
        public String GetCurrentlyPlayingToken(String code)
        {
            Businesslogic.SpotifyControllerClass scc = new Businesslogic.SpotifyControllerClass();
            storage.AuthorizationCodeFlowAuthCode = code;
            scc.GetCurrentlyPlayingToken();
            return scc.GetCurrentlyPlayingSong();
        }


        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
