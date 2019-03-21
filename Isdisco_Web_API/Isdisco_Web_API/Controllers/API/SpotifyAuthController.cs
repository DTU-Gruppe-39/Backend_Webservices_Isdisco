using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace Isdisco_Web_API.Controllers.API
{
    public class SpotifyAuthController
    {
        public SpotifyAuthController()
        {
        }

       
         //see https://developer.spotify.com/web-api/authorization-guide/#client_credentials_flow
        public void GetClientCredentialsAuthToken()
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
        }

    }
}
