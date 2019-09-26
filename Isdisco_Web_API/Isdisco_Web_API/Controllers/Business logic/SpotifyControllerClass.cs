using System;
using System.Collections.Generic;
using System.Net;
using Isdisco_Web_API.Models;
using Newtonsoft.Json.Linq;

namespace Isdisco_Web_API.Controllers.Businesslogic
{
    public class SpotifyControllerClass
    {
        private DAO.StorageSingleton storage = DAO.StorageSingleton.GetInstance();
        private SpotifyAuthController auth = ControllerRegistry.GetSpotifyAuthController();

        public SpotifyControllerClass()
        {
        }

        public Track GetTrack(String id)
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

            var GetResponse = SendClientCredentialsRequest(webClient, "https://api.spotify.com/v1/tracks/" + id);


            var jsonTrack = JObject.Parse(GetResponse);
            var trackId = jsonTrack["id"].ToString();
            var songName = jsonTrack["name"].ToString();
            var artistName = jsonTrack["artists"][0]["name"].ToString();
            var image_small_url = jsonTrack["album"]["images"][2]["url"].ToString();
            var image_medium_url = jsonTrack["album"]["images"][1]["url"].ToString();
            var image_large_url = jsonTrack["album"]["images"][0]["url"].ToString();
            var webplayerLink = jsonTrack["external_urls"]["spotify"].ToString();
            Track track = new Track(trackId, songName, artistName, image_small_url, image_medium_url, image_large_url, webplayerLink);

            return track;
        }

        public ListOfTracks GetPlaylist(string id)
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
            //var limit = "30";    //Number of songs that Spotify returns
            //var GetResponse = webClient.DownloadString("https://api.spotify.com/v1/playlists/" + id + "/tracks");
            var GetResponse = SendClientCredentialsRequest(webClient, "https://api.spotify.com/v1/playlists/" + id + "/tracks");

            var jsonTracks = JObject.Parse(GetResponse);
            JArray tracks = (JArray)jsonTracks["items"];
            ListOfTracks listTracks = new ListOfTracks();
            for (int i = 0; i < tracks.Count; i++)
            {
                var trackId = tracks[i]["track"]["id"].ToString();
                var thesongName = tracks[i]["track"]["name"].ToString();
                var artistName = tracks[i]["track"]["artists"][0]["name"].ToString();
                var image_small_url = tracks[i]["track"]["album"]["images"][2]["url"].ToString();
                var image_medium_url = tracks[i]["track"]["album"]["images"][1]["url"].ToString();
                var image_large_url = tracks[i]["track"]["album"]["images"][0]["url"].ToString();
                var webplayerLink = tracks[i]["track"]["external_urls"]["spotify"].ToString();
                listTracks.Tracks.Add(new Track(trackId, thesongName, artistName, image_small_url, image_medium_url, image_large_url, webplayerLink));
            }

            return listTracks;
            //return JObject.Parse(GetResponse);
        }

        public ListOfTracks GetSearch(String songName)
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
            var limit = "20";    //Number of songs that Spotify returns



            var GetResponse = SendClientCredentialsRequest(webClient, "https://api.spotify.com/v1/search?q=track:" + Uri.EscapeUriString(songName) + "*&type=track&market=DK&limit=" + limit + "&offset=0");

            var jsonTracks = JObject.Parse(GetResponse);
            JArray tracks = (JArray)jsonTracks["tracks"]["items"];
            ListOfTracks listTracks = new ListOfTracks();
            for (int i = 0; i < tracks.Count; i++)
            {
                var trackId = tracks[i]["id"].ToString();
                var thesongName = tracks[i]["name"].ToString();
                var artistName = tracks[i]["artists"][0]["name"].ToString();
                var image_small_url = tracks[i]["album"]["images"][2]["url"].ToString();
                var image_medium_url = tracks[i]["album"]["images"][1]["url"].ToString();
                var image_large_url = tracks[i]["album"]["images"][0]["url"].ToString();
                var webplayerLink = tracks[i]["external_urls"]["spotify"].ToString();
                listTracks.Tracks.Add(new Track(trackId, thesongName, artistName, image_small_url, image_medium_url, image_large_url, webplayerLink));
            }

            return listTracks;
            //return GetResponse;
        }


        public CurrentlyPlaying GetAppCurrentlyPlayingSong()
        {
            if (storage.currentlyPlaying != null)
            {
                return storage.currentlyPlaying;
            }
            else
            {
                return null;
            }
        }

            public CurrentlyPlaying GetCurrentlyPlayingSong()
        {
            var webClient = new WebClient();
            JObject jObject = JObject.Parse(storage.AuthorizationCodeFlowAuthTokenResponse);
            string AuthToken = (string)jObject.SelectToken("access_token");
            webClient.Headers.Add(HttpRequestHeader.Accept, "application/json");
            webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + AuthToken);

            var GetResponse = SendAuthorizationCodeRequest(webClient, "https://api.spotify.com/v1/me/player/currently-playing?market=DK");


            var jsonTrack = JObject.Parse(GetResponse);
            var trackId = jsonTrack["item"]["id"].ToString();
            var songName = jsonTrack["item"]["name"].ToString();
            var artistName = jsonTrack["item"]["artists"][0]["name"].ToString();
            var image_small_url = jsonTrack["item"]["album"]["images"][2]["url"].ToString();
            var image_medium_url = jsonTrack["item"]["album"]["images"][1]["url"].ToString();
            var image_large_url = jsonTrack["item"]["album"]["images"][0]["url"].ToString();
            var webplayerLink = jsonTrack["item"]["external_urls"]["spotify"].ToString();
            int duration = Int32.Parse(jsonTrack["item"]["duration_ms"].ToString());
            int progress = Int32.Parse(jsonTrack["progress_ms"].ToString());
            CurrentlyPlaying track = new CurrentlyPlaying(new Track(trackId, songName, artistName, image_small_url, image_medium_url, image_large_url, webplayerLink), duration, progress);

            return track;



            //return GetResponse;
        }

        public ListOfTracks GetMyTopTracks()
        {
            var webClient = new WebClient();
            JObject jObject = JObject.Parse(storage.AuthorizationCodeFlowAuthTokenResponse);
            string AuthToken = (string)jObject.SelectToken("access_token");
            webClient.Headers.Add(HttpRequestHeader.Accept, "application/json");
            webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + AuthToken);

            var GetResponse = SendAuthorizationCodeRequest(webClient, "https://api.spotify.com/v1/me/top/tracks");


            var jsonTracks = JObject.Parse(GetResponse);
            JArray tracks = (JArray)jsonTracks["items"];
            ListOfTracks listTracks = new ListOfTracks();
            for (int i = 0; i < tracks.Count; i++)
            {
                var trackId = tracks[i]["id"].ToString();
                var thesongName = tracks[i]["name"].ToString();
                var artistName = tracks[i]["artists"][0]["name"].ToString();
                var image_small_url = tracks[i]["album"]["images"][2]["url"].ToString();
                var image_medium_url = tracks[i]["album"]["images"][1]["url"].ToString();
                var image_large_url = tracks[i]["album"]["images"][0]["url"].ToString();
                var webplayerLink = tracks[i]["external_urls"]["spotify"].ToString();
                listTracks.Tracks.Add(new Track(trackId, thesongName, artistName, image_small_url, image_medium_url, image_large_url, webplayerLink));
            }

            return listTracks;

            //return JObject.Parse(GetResponse);
        }



        public String GetUserScopes()
        {
            return auth.GetAuthorizationCodeFlowUserScope();
        }

        public void GetAuthorizationCodeToken()
        {
            //if (storage.AuthorizationCodeFlowAuthToken == null)
            //{
            //    return auth.GetAuthorizationCodeFlowAuthToken();
            //}
            auth.GetAuthorizationCodeFlowAuthToken();
        }


        private String SendClientCredentialsRequest(WebClient webClient, string url)
        {
            string GetResponse;
            try
            {
                GetResponse = webClient.DownloadString(url);
            }
            catch (WebException e)
            {
                HttpWebResponse webResp = (HttpWebResponse)e.Response;
                if (webResp.StatusCode == HttpStatusCode.Unauthorized)
                {
                    //Token expires or invalid, request new token
                    auth.GetClientCredentialsFlowAuthToken();

                    //Set new token
                    JObject jObject = JObject.Parse(storage.ClientCredentialsFlowAuthToken);
                    string AuthToken = (string)jObject.SelectToken("access_token");
                    //webClient.Headers.Add(HttpRequestHeader.Accept, "application/json");
                    webClient.Headers.Set(HttpRequestHeader.Authorization, "Bearer " + AuthToken);
                    GetResponse = webClient.DownloadString(url);
                }
                else
                {
                    throw new WebException("Something went wrong with accessing spotify's api");
                }
            }

            if (String.IsNullOrEmpty(GetResponse))
            {
                throw new WebException("Something went wrong with accessing spotify's api. No data was returned.");
            }
            return GetResponse;
        }


        private String SendAuthorizationCodeRequest(WebClient webClient, string url)
        {
            string GetResponse;
            try
            {
                GetResponse = webClient.DownloadString(url);
            }
            catch (WebException e)
            {
                HttpWebResponse webResp = (HttpWebResponse)e.Response;
                if (webResp.StatusCode == HttpStatusCode.Unauthorized)
                {
                    //Token expires or invalid, request new token
                    auth.GetRefreshAuthorizationCodeFlowAuthToken();

                    JObject jObject = JObject.Parse(storage.AuthorizationCodeFlowAuthTokenResponse);
                    string AuthToken = (string)jObject.SelectToken("access_token");
                    webClient.Headers.Set(HttpRequestHeader.Authorization, "Bearer " + AuthToken);

                    GetResponse = webClient.DownloadString(url);
                }
                else
                {
                    throw new WebException("Something went wrong with accessing spotify's api");
                }
            }

            if (String.IsNullOrEmpty(GetResponse))
            {
                throw new WebException("Something went wrong with accessing spotify's api. No data was returned.");
            }
            return GetResponse;
        }


    }
}
