using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;

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
            var redirect_uri = "https://isdisco.azurewebsites.net/api/spotify-track/callback";
            var scope = "user-read-currently-playing user-top-read";      // use a space between multiple scopes fx "user-read-private user-read-email"

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
            //redirect doesn't do anything here, but is just required for extra safety by spotify, it must match scope redirect
            postparams.Add("redirect_uri", "https://isdisco.azurewebsites.net/api/spotify-track/callback");

            var authHeader = Convert.ToBase64String(Encoding.Default.GetBytes($"{spotifyClient}:{spotifySecret}"));
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Basic " + authHeader);

            var tokenResponse = webClient.UploadValues("https://accounts.spotify.com/api/token", postparams);

            var textResponse = Encoding.UTF8.GetString(tokenResponse);
            storage.AuthorizationCodeFlowAuthToken = textResponse;

            JObject jObject = JObject.Parse(textResponse);
            string RefreshAuthToken = (string)jObject.SelectToken("refresh_token");
            storage.RefreshAuthorizationCodeFlowAuthToken = RefreshAuthToken;
            //Console.WriteLine(textResponse);

        }

        public void GetRefreshAuthorizationCodeFlowAuthToken()
        {
            var spotifyClient = "80b3eb68b8454a0c81554c61b47bcc39";
            var spotifySecret = "c2a18bfa0793457f8a59d277ba412425";

            string RefreshAuthToken = storage.RefreshAuthorizationCodeFlowAuthToken;

            var webClient = new WebClient();
            var postparams = new NameValueCollection();
            postparams.Add("grant_type", "refresh_token");
            postparams.Add("refresh_token", RefreshAuthToken);

            var authHeader = Convert.ToBase64String(Encoding.Default.GetBytes($"{spotifyClient}:{spotifySecret}"));
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Basic " + authHeader);

            var tokenResponse = webClient.UploadValues("https://accounts.spotify.com/api/token", postparams);

            var textResponse = Encoding.UTF8.GetString(tokenResponse);
            storage.AuthorizationCodeFlowAuthToken = textResponse;

        }
    }
}
