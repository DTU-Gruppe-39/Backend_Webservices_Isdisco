using System;
using Newtonsoft.Json;

namespace Isdisco_Web_API.Models
{
    public class AppleNotification
    {

        public class ApsPayload
        {
            [JsonProperty("alert")]
            public string AlertBody { get; set; }
        }

        // Your custom properties as needed

        [JsonProperty("aps")]
        public ApsPayload Aps { get; set; }

        public AppleNotification()
        {
        }
    }
}
