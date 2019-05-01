﻿using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace Isdisco_Web_API.Controllers
{
    public class SpotifyAuthController
    {
        private DAO.StorageSingleton storage = DAO.StorageSingleton.GetInstance();
        public SpotifyAuthController()
        {
        }

       
         //see https://developer.spotify.com/web-api/authorization-guide/#client_credentials_flow
        public void GetClientCredentialsFlowAuthToken()
        {
            var spotifyClient = "80b3eb68b8454a0c81554c61b47bcc39";
            var spotifySecret = "c2a18bfa0793457f8a59d277ba412425";

            var webClient = new WebClient();

            var postparams = new NameValueCollection();
            postparams.Add("grant_type", "client_credentials");

            var authHeader = Convert.ToBase64String(Encoding.Default.GetBytes($"{spotifyClient}:{spotifySecret}"));
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Basic " + authHeader);

            var tokenResponse = webClient.UploadValues("https://accounts.spotify.com/api/token", postparams);

            var textResponse = Encoding.UTF8.GetString(tokenResponse);
            storage.ClientCredentialsFlowAuthToken = textResponse;
            //Console.WriteLine(textResponse);
        }


        public string GetAuthorizationCodeFlowUserScope()
        {
            var spotifyClient = "80b3eb68b8454a0c81554c61b47bcc39";
            //var spotifySecret = "c2a18bfa0793457f8a59d277ba412425";
            var redirect_uri = "https://localhost:5001/api/spotify-track/callback";
            var scope = "user-read-currently-playing";      // use a space between multiple scopes fx "user-read-private user-read-email"

            return "https://accounts.spotify.com/authorize?client_id=" + Uri.EscapeUriString(spotifyClient) + "&response_type=code&redirect_uri=" + redirect_uri + "&scope=" + Uri.EscapeUriString(scope);
        }


        public void GetAuthorizationCodeFlowAuthToken()
        {
            var spotifyClient = "80b3eb68b8454a0c81554c61b47bcc39";
            var spotifySecret = "c2a18bfa0793457f8a59d277ba412425";
            var code = storage.AuthorizationCodeFlowAuthCode;

            var webClient = new WebClient();

            var postparams = new NameValueCollection();
            postparams.Add("grant_type", "authorization_code");
            postparams.Add("code", code);
            postparams.Add("redirect_uri", "https://localhost:5001/api/spotify-track/callback");

            var authHeader = Convert.ToBase64String(Encoding.Default.GetBytes($"{spotifyClient}:{spotifySecret}"));
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Basic " + authHeader);

            var tokenResponse = webClient.UploadValues("https://accounts.spotify.com/api/token", postparams);

            var textResponse = Encoding.UTF8.GetString(tokenResponse);
            storage.AuthorizationCodeFlowAuthToken = textResponse;
            //Console.WriteLine(textResponse);

        }
    }
}