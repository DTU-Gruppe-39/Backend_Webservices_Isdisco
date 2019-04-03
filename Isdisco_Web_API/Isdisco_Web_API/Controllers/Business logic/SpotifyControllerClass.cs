using System;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Isdisco_Web_API.Controllers.Businesslogic
{
    public class SpotifyControllerClass
    {
        private DAO.StorageSingleton storage = DAO.StorageSingleton.GetInstance();
        private SpotifyAuthController auth = new SpotifyAuthController();

        public SpotifyControllerClass()
        {
        }

        public string GetTrack(String id)
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

            var GetResponse = webClient.DownloadString("https://api.spotify.com/v1/tracks/" + id);

            return GetResponse;
        }


        public string GetSearch(String songName)
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
            var limit = "4";    //Number of songs that Spotify returns
            var GetResponse = webClient.DownloadString("https://api.spotify.com/v1/search?q=" + Uri.EscapeUriString(songName) + "&type=track&market=DK&limit=" + limit + "&offset=0");

            return GetResponse;
        }


    }
}
