using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json.Linq;
using Isdisco_Web_API.Models;
using Microsoft.AspNetCore.Cors;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Isdisco_Web_API.Controllers.API
{

    [Route("api/spotify-track")]
    public class SpotifyTrackService : Controller
    {
        Businesslogic.SpotifyControllerClass scc = new Businesslogic.SpotifyControllerClass();
        private DAO.StorageSingleton storage = DAO.StorageSingleton.GetInstance();
        private SpotifyAuthController auth = new SpotifyAuthController();


        // GET: api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        [HttpGet("test")]
        public List<Musicrequest> GetTest()
        {
            //Businesslogic.SpotifyControllerClass scc = new Businesslogic.SpotifyControllerClass();
            return storage.MusicrequestList;
        }


        // GET api/values/5
        [HttpGet()]
        public Track GetTrack(String id)
        {
            //Businesslogic.SpotifyControllerClass scc = new Businesslogic.SpotifyControllerClass();
            return scc.GetTrack(id);
        }

        [HttpGet("search")]
        public ListOfTracks GetSearch(String songName)
        {
            //Businesslogic.SpotifyControllerClass scc = new Businesslogic.SpotifyControllerClass();
            Response.Headers.Add("Acess-Control-Allow-Origin", "*");
            return scc.GetSearch(songName);
        }

        [HttpGet("playlist")]
        public ListOfTracks GetPlaylist(String id)
        {
            //Businesslogic.SpotifyControllerClass scc = new Businesslogic.SpotifyControllerClass();
            switch (id)
            {
                //Denmark Top 50: https://open.spotify.com/playlist/37i9dQZEVXbL3J0k32lWnN
                case "1": id = "37i9dQZEVXbL3J0k32lWnN";
                    break;
                //Ja dak: https://open.spotify.com/playlist/37i9dQZF1DX9vVjb8NqHzD
                case "2": id = "37i9dQZF1DX9vVjb8NqHzD";
                    break;
                //Fest fest fest: https://open.spotify.com/playlist/37i9dQZF1DWZByy5JrUWJv
                case "3":
                    id = "37i9dQZF1DWZByy5JrUWJv";
                    break;
            }
            return scc.GetPlaylist(id);
        }


        [HttpGet("currently-playing")]
        //[Produces("text/html")]
        public CurrentlyPlaying GetCurrentlyPlayingScope()
        {
            //Businesslogic.SpotifyControllerClass scc = new Businesslogic.SpotifyControllerClass();
            //Response.Redirect(scc.GetCurrentlyPlayingScope());
            if (storage.AuthorizationCodeFlowAuthCode == null)
            {
                storage.LoginCallback = "spotify-track/currently-playing";
                Response.Redirect(scc.GetUserScopes());
                return null;
            }
            if (storage.AuthorizationCodeFlowAuthTokenResponse == null)
            {
                scc.GetAuthorizationCodeToken();
            }
            return scc.GetCurrentlyPlayingSong();
        }

        [HttpGet("app-currently-playing")]
        //[Produces("text/html")]
        public CurrentlyPlaying GetAppCurrentlyPlayingScope()
        {
            return scc.GetAppCurrentlyPlayingSong();
        }

        [HttpGet("my-top")]
        public ListOfTracks GetMyTop()
        {
            if (storage.AuthorizationCodeFlowAuthCode == null)
            {
                storage.LoginCallback = "spotify-track/my-top";
                Response.Redirect(scc.GetUserScopes());
                return null;
            }
            if (storage.AuthorizationCodeFlowAuthTokenResponse == null)
            {
                scc.GetAuthorizationCodeToken();
            }
            return scc.GetMyTopTracks();
        }
       
         [HttpGet("callback")]
        //[Produces("text/html")]
        public void GetCurrentlyPlayingToken(String code)
        {
            //Businesslogic.SpotifyControllerClass scc = new Businesslogic.SpotifyControllerClass();
            storage.AuthorizationCodeFlowAuthCode = code;
            scc.GetAuthorizationCodeToken();
            Console.WriteLine("\n\n\n\n" + storage.LoginCallback + "\n\n\n\n");
            Response.Redirect("https://isdisco.azurewebsites.net/api/" + storage.LoginCallback);
            //return scc.GetCurrentlyPlayingSong();
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
