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
            if (storage.AuthToken == null) {
                auth.GetClientCredentialsAuthToken();
            }

            var webClient = new WebClient();
            JObject jObject = JObject.Parse(storage.AuthToken);
            string AuthToken = (string)jObject.SelectToken("access_token");
            var authHeader = AuthToken;
            //webClient.Headers.Add(HttpRequestHeader.Accept, "application/json");
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + authHeader);

            var GetResponse = webClient.DownloadString("https://api.spotify.com/v1/tracks/" + id);

            return GetResponse;
        }

        [HttpGet("search/{song}")]
        public string GetSearch(String song)
        {
            if (storage.AuthToken == null)
            {
                auth.GetClientCredentialsAuthToken();
            }

            var webClient = new WebClient();
            JObject jObject = JObject.Parse(storage.AuthToken);
            string AuthToken = (string)jObject.SelectToken("access_token");
            var authHeader = AuthToken;
            //webClient.Headers.Add(HttpRequestHeader.Accept, "application/json");
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + authHeader);
            //webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + authHeader);
            var limit = "4";    //Number of songs that Spotify returns
            var GetResponse = webClient.DownloadString("https://api.spotify.com/v1/search?q=" + Uri.EscapeUriString(song) + "&type=track&market=DK&limit=" + limit + "&offset=0");

            return GetResponse;
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
