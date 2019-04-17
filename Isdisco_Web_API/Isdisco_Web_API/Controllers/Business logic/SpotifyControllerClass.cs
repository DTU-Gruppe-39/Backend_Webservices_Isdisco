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
            if (storage.ClientCredentialsFlowAuthToken == null)
            {
                auth.GetClientCredentialsFlowAuthToken();
            }

            var webClient = new WebClient();
            JObject jObject = JObject.Parse(storage.ClientCredentialsFlowAuthToken);
            string AuthToken = (string)jObject.SelectToken("access_token");
            //webClient.Headers.Add(HttpRequestHeader.Accept, "application/json");
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + AuthToken);

            var GetResponse = webClient.DownloadString("https://api.spotify.com/v1/tracks/" + id);

            return GetResponse;
        }


        public string GetSearch(String songName)
        {
            if (storage.ClientCredentialsFlowAuthToken == null)
            {
                auth.GetClientCredentialsFlowAuthToken();
            }

            var webClient = new WebClient();
            JObject jObject = JObject.Parse(storage.ClientCredentialsFlowAuthToken);
            string AuthToken = (string)jObject.SelectToken("access_token");
            //webClient.Headers.Add(HttpRequestHeader.Accept, "application/json");
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + AuthToken);
            var limit = "4";    //Number of songs that Spotify returns
            var GetResponse = webClient.DownloadString("https://api.spotify.com/v1/search?q=" + Uri.EscapeUriString(songName) + "&type=track&market=DK&limit=" + limit + "&offset=0");

            return GetResponse;
        }


        public String GetCurrentlyPlayingSong()
        {
            var webClient = new WebClient();
            JObject jObject = JObject.Parse(storage.AuthorizationCodeFlowAuthToken);
            string AuthToken = (string)jObject.SelectToken("access_token");
            webClient.Headers.Add(HttpRequestHeader.Accept, "application/json");
            webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + AuthToken);
            var GetResponse = webClient.DownloadString("https://api.spotify.com/v1/me/player/currently-playing?market=DK");
            Console.WriteLine("\n\n\n\n\n" + AuthToken + "\n\n\n\n\n");
            //Console.WriteLine("\n\n\n\n\n" + GetResponse + "\n\n\n\n\n");
            return GetResponse;
        }



        public String GetCurrentlyPlayingScope()
        {
            return auth.GetAuthorizationCodeFlowUserScope();
        }


        public void GetCurrentlyPlayingToken()
        {
            //if (storage.AuthorizationCodeFlowAuthToken == null)
            //{
            //    return auth.GetAuthorizationCodeFlowAuthToken();
            //}
            auth.GetAuthorizationCodeFlowAuthToken();
        }
    }
}
