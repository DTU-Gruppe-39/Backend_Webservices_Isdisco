﻿using System;
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
            using (TextReader reader = System.IO.File.OpenText("C:\\Users\\Thomas\\Documents\\GitHub\\Backend_Webservices_Isdisco\\Isdisco_Web_API\\Isdisco_Web_API\\Controllers\\Business logic\\push-cert.p8"))
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
    }
}
