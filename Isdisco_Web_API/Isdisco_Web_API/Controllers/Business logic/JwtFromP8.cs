using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Jose;
using Security.Cryptography;
using Org.BouncyCastle;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using System.Reflection;

namespace Isdisco_Web_API.Controllers.Businesslogic
{
    public class JwtFromP8
    {

        public JwtFromP8()
        {
        }


        public string GetToken()
        {
            var dsa = GetECDsa();
            return CreateJwt(dsa, "Q96692A9S2", "G6TSQJ6DQ5");
        }

        private ECDsa GetECDsa()
        {
            /*
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            var p8Path = Path.Combine(outPutDirectory, "push-cert.p8");
            string p8_path = new Uri(p8Path).LocalPath;
            */
          

                using (TextReader reader = new StreamReader("-----BEGIN PRIVATE KEY-----\nMIGTAgEAMBMGByqGSM49AgEGCCqGSM49AwEHBHkwdwIBAQQgzdgv9ENf8lc74VfU\n1jCn4WEXryur2sOK6tXBfWnNJGigCgYIKoZIzj0DAQehRANCAARH8kCLw2xvoDGl\njoRv2CWGi6xo8ygK6VYrFCq6TbKyvQksKlsbVoqsmDB3N8f0c3xOsktvYxNtaUf3\nUUHcMXs8\n-----END PRIVATE KEY-----"))
                {
                    var ecPrivateKeyParameters =
                        (ECPrivateKeyParameters)new Org.BouncyCastle.OpenSsl.PemReader(reader).ReadObject();
                    var x = ecPrivateKeyParameters.Parameters.G.AffineXCoord.GetEncoded();
                    var y = ecPrivateKeyParameters.Parameters.G.AffineYCoord.GetEncoded();
                    var d = ecPrivateKeyParameters.D.ToByteArrayUnsigned();

                    // Convert the BouncyCastle key to a Native Key.
                    var msEcp = new ECParameters { Curve = ECCurve.NamedCurves.nistP256, Q = { X = x, Y = y }, D = d };
                    return ECDsa.Create(msEcp);
                }
            }

        private string CreateJwt(ECDsa key, string keyId, string teamId)
        {
            var securityKey = new ECDsaSecurityKey(key) { KeyId = keyId };
            var credentials = new SigningCredentials(securityKey, "ES256");

            var descriptor = new SecurityTokenDescriptor
            {
                IssuedAt = DateTime.Now,
                Issuer = teamId,
                SigningCredentials = credentials,

            };

            var handler = new JwtSecurityTokenHandler();
            var encodedToken = handler.CreateEncodedJwt(descriptor);
            return encodedToken;
        }

        public static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }

}
