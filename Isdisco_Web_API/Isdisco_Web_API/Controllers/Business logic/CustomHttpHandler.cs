using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Isdisco_Web_API.Controllers.Business_logic
{
    public class CustomHttpHandler : WinHttpHandler
    {

        public class ApnsProvider : IDisposable
        {

            HttpClient _client;
            CustomHttpHandler _handler;

            private readonly string _appBundleId = "com.Rasmus-Gregersen.Isdisco";
            private readonly string _apnBaseUrl = "https://api.development.push.apple.com:443";

            public ApnsProvider(string apnUrl, string appBundleId)
            {
                _appBundleId = appBundleId;
                _apnBaseUrl = apnUrl;
                _handler = new CustomHttpHandler();
                _client = new HttpClient(_handler);
            }

            public async Task<bool> SendAsync(string message, string deviceToken, string jwtToken, bool playSound, string debugInfo = null)
            {
                var success = false;
                var headers = GetHeaders();

                var obj = new
                {
                    aps = new
                    {
                        alert = message,
                        sound = playSound ? "default" : null
                    }
                };

                var json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                var data = new StringContent(json);

                using (var request = new HttpRequestMessage(HttpMethod.Post, _apnBaseUrl + "/3/device/" + deviceToken))
                {
                    request.Version = new Version(2, 0);
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", jwtToken);
                    request.Content = data;

                    foreach (var header in headers)
                    {
                        request.Headers.Add(header.Key, header.Value);
                    }

                    using (var response = await _client.SendAsync(request))
                    {
                        success = response.IsSuccessStatusCode;
                    }
                }

                return success;
            }

            private Dictionary<string, string> GetHeaders()
            {
                var messageGuid = Guid.NewGuid().ToString();
                var headers = new Dictionary<string, string>();

                headers.Add("apns-id", messageGuid);
                headers.Add("apns-expiration", "0");
                headers.Add("apns-priority", "10");
                headers.Add("apns-topic", _appBundleId);

                return headers;
            }

            public void Dispose()
            {
                _handler.Dispose();
                _client.Dispose();
            }
        }
    }
}
