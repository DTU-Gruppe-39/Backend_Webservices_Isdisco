using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Jose;
namespace Isdisco_Web_API.Controllers.Businesslogic
{
    public class JwtFromP8
    {
        public JwtFromP8()
        {
        }

        public void MakeToken()
        {
            var iat = Math.Round((DateTime.UtcNow.AddMinutes(-1) - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds, 0);
            var exp = Math.Round((DateTime.UtcNow.AddMinutes(30) - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds, 0);

            var payload = new Dictionary<string, object>()
        {
            { "iat", iat },
            { "exp", exp },
            { "iss", "G6TSQJ6DQ5" },
            { "origin", "com.Rasmus-Gregersen.Isdisco" }
        };

            var extraHeader = new Dictionary<string, object>()
        {
            { "alg", "ES256" },
            { "typ", "JWT" },
            { "kid", "Q96692A9S2" }
        };

            var keyString = "MIGTAgEAMBMGByqGSM49AgEGCCqGSM49AwEHBHkwdwIBAQQgzdgv9ENf8lc74VfU\n1jCn4WEXryur2sOK6tXBfWnNJGigCgYIKoZIzj0DAQehRANCAARH8kCLw2xvoDGl\njoRv2CWGi6xo8ygK6VYrFCq6TbKyvQksKlsbVoqsmDB3N8f0c3xOsktvYxNtaUf3\nUUHcMXs8";

            CngKey privateKey = CngKey.Import(Convert.FromBase64String(keyString), CngKeyBlobFormat.Pkcs8PrivateBlob);

            string token = JWT.Encode(payload, privateKey, JwsAlgorithm.ES256, extraHeader);

            Console.WriteLine(token);
        }
    }
}
