using Jose;
using JwtGenerator.Api.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;

namespace JwtGenerator.Api.Controllers
{
    [ApiController]
    [Route("Generator")]
    public class TokenGenerator : ControllerBase
    {       
        [HttpGet("Jwt")]
        public string GetToken()
        {
            string Token;
            DTO.JwtHeader header = new DTO.JwtHeader
            {
                Alg = "RS256",
                Typ = "JWT",
                Kid = "be849d93-4f38-4d20-8fae-54c6ea4bc965"//"ee56ed9b-69e4-47c0-bc26-f1c3fe1c6684"//
            };

            DTO.JwtPayload payload = new DTO.JwtPayload
            {
                Sub = "f8953ad4-3937-48fb-bc60-a9183bc3a5a9",//"nevasa_inum",//
                Aud = "f8953ad4-3937-48fb-bc60-a9183bc3a5a9",//"nevasa_inum",//
                Iss = "https://idp-qa.bancosecurity.cl/jans-auth/restv1/token",
                Exp = DateTimeOffset.UtcNow.AddYears(10).ToUnixTimeSeconds().ToString(),
                Iat = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(),
                Jti = Guid.NewGuid().ToString()
            };
            //JwksPrivate jwks = new JwksPrivate
            //{
            //    alg = SecurityAlgorithms.RsaSha256,
            //    kid = "be849d93-4f38-4d20-8fae-54c6ea4bc965",
            //    use = "sign",
            //    kty = "RSA",
            //    n = "t1E327uttTgyzgj8fMGGNKf4lTiwS09e1Rxm0oHVSdK_tsWOQPwZxf9ADD8wmhqiXlTfw1itRH7xcbZQvo0sdkyKfd1Yoxz9McQO_qzwn24gcy5RqFyDAjEMjYpHL08wv6ijUAstDpYP0Md1Ns90E3SDCcJXISVeu4FkVXt7COOUD7-Lf_e8zvKPdMP3PsIav677ZwhMLRYwvhTJCuyXZ8fNaHeELgprJZirO9vpuCMRZgrcgvtmRW17FnSrSXajbZhit_swVCwIy3Ocor6s3qFlhH_gePZv03hi4Gi7T8xMWQmOF1_OKDdlIaIUiJ3wWdFhWzHQl2dq6Jp7sXA_0Q",
            //    e = "AQAB",
            //    d = "AbNfMUqsceHzlrW-oemptRNZ2wiLmidCWffJfGp38Bdkb-2lRDUSiCO2FGcBrGxS1U00RjusX9ZNpyBp31qv7ukG3-QNznWWY7_N48727IO5CViEqWsyS_LoiuedgXLaoOyPl06DPH9n5ifzjm6eRQ_vp0eGR2hxWIv6wlBC8_IkiDd8YMqFHustLGo-jFgSas3tXJWo6RIhlSP_kSIlFMkbiWRMBnKw6X4Gflhu_09r5w_LR1zPbjaoVrG_zJby63-ZtEHe6RcGhlMlDxb7_LuqhnzbfdhexIRbXg3wsMIrucTfSguyHqExp1xVbf_cUH62SMOak-VRLDfhoGc7gQ",
            //    p = "05NwygHjd4fDVhe2JxJA_VbP7_Bf0R4ayZtJaBrrhbYn2dIqFj-R979SEeQryKklu_jE4qCy08SHyN47cH-GEYdgDChpUADxivx0kCaGBofOf_xduvoJmY1fB_zlk9LdiDxKOdeQ2v9bNvvP0tKhgERMlzqzk4hisENiN_kRa3s",
            //    q= "3c7Tjtl9kiVgBwJaCggIX5EltjIEe5fOfwV_SpD3tzJjLyqVQPx8FrDUFCI-uL7QMQNLuj0xgGNi7_dYLgO64bYAQLnapdC6p1hmC4tcaCRxhk8hUCW4XlJB0yL2NYJ2-7dxaOpXTSC6YHDGImmnQMbFTbdG78uxwLxa2y3nSiM",
            //    dp= "F9xV6QJDg_R0rB3qdgeR-sAynS2vsKbDgJ8ZrTrz-tVrMx6HjpDGxnj2KXxhD7U7wzIwChrzb_yHD7k4XNyU4x8wTs6z6cjhdLo57xPZI51nRXnRnEeck4uk_wKfZYdvYnDiMhnEhV4tDEtjybPlcNDDDn8ZR3cnIhfHWOam90c",
            //    dq = "OHMVxmo1mgcnDEGd9qWas--1wEu0dlvpMsyMW8bPNHF_apaUy6g2UHQKVWFtwwjU5VRoZmqCeaFRoa66Y2ORoTX3lIF4UvDvP_2wYsnB58M2nS7wVHx1EpQuqnRgYrfkXiWOmFvjgf6NUFQDKOjopwSvXBsD061sfJezK8rf7S8",
            //    qi = "GiBDPVIOYS82ETgl-KWhBQUoZux--Z32XJxvOpZI9G8ipL3BCKif6a0t4sDeuur0Y0e70_sZK4J9ZiJfHFyr5J5Gt8d8vgiX3IwMTzel2a0ICbkAJvc3ykqwJ-vWAig_3FmcU36QiH8jANgj7ugcVm4duqYNdvuW3uSAZi-AzuY"
            //};
            //JWK generado por Jeyson
            JwksPrivate jwks = new JwksPrivate
            {
                alg = SecurityAlgorithms.RsaSha256,
                kid = "be849d93-4f38-4d20-8fae-54c6ea4bc965",
                use = "sign",
                kty = "RSA",
                n = "jVmzquUc8mzW-WqFAAAGLjEAWsD2i_nkF0aoYXfx99UxRE2N-xlJyx2JIAHrc6Ohq2k5eFV9k9fllJ0HkNEXIfAH3gqHLAUvF9ZNWHCz2Z-syZc_UEDygNWjkOfA27neH_ECJMbylCngeNyWajKJ6Gm1ClasELTi1UwOZ09wPDaO3x7uXFn7ha5HfVjwBwcEuv3q9M6_yPkyLm9mCJgReyRKMF0qjml9SMYzGX2FxcAF6tF5V_mmDcyxqKajCtoTEFHScPOwe0pAWcQRu_DxvAKbKxzbH7UxBjvZ71FX-x5DCWvTiFwRIpWEvZx7IINcI5lCsHs36QLUk3cqwYLHQw",
                e = "AQAB",
                d = "CIYQP43xYO0PSZsSyh02QjLSQqbAN1CqYHzySm5hOQCyJ9xFY47y1DzDuBpliGOlrCB8RrVhDTlHrt6JRkJVksZWsx0PaagmXtmdcGfbcJQgZ0enmb9Q4FQBuQtApf9fVa3C41Tb6_Nahe9HYsAJcOpu8GCpn5hI1XPwqmov6nGI2tCrSO5CDj6BHSrp2ax1Qn6dcKq-z92JQpt-8WR84pTxIxGdEab638ki9uhCluLG4BFE0-fEtn-8fU3DMq-_jks8TrUx7lsFfNqdVsfXksa8YtAVRExgo_gdKdBZ-M8WuBrHapWdr9-XRDx9Jb0JTWuT_J15KflqkaDP27sBgQ",
                p = "vrvwWqfpLTl5n2wi1VA4FEaA8Lkn1fwpGUA1cubTiGziF0zRzfVrVG3_BFUZ6Jegn1P84gRZM81FnIRU5lnOib8TivJ5HkU6iboeWIoMBbR7LswzrQ8yJ3QXR7K8HiuuZHO1p7P35geri_PHYrbc-63WTMJhNNc6WogqzRREho8",
                q = "vbfP3bTb4jdwz7txw1sxeEvQ7uDzpLU2HREoOtj-r_t7_5WiJ4cccPeJ2tAZaWnjbrJJZDTBDdRzMlqWHAPE6dU1TRGOONj6vFUEalXVe2gG9ZkuGQ1LyUoPxOWu5DqjuM6eXTsw2N76F6I0W6MH3TEKYjmqvSVO61Y4k8uh7g0",
                dp = "ideDDdFZqBBogDmDNwxBaw3E87OsQW56OUB5IDAHYgnmn5Yp7iHWTm8sJPJnxfuG3n6xPJqN6O0JyOKuBMeUh2Iq-njf5Wt8sbprYetqYtkbSSfUlNZtlavFg1B9uYQyBXDGMIvUtU6HwJ4OU536OH1aaaD05V5CUtkjrZBfMas",
                dq = "lYyo2d6wmgET91yOD-358BbrqvI-fS6vanhU2xakpXq7Qzzj5v7Vh6NJ0ufJsFPdCSyXN9tx9wHqkN3hiFHcTmtYKdlV4DACbqUh5uSkdTQKkF1gfjUB8blk9tQLajNjTdHp-honpj0WrbyaQ0Yfc9gtlEJa-eDH9jEwRij2C50",
                qi = "WzQEAGYQKoaz-bATYCXGXZ7usVwNMLhkZ9yKF2u08EoWVNGbZ1wNQtbGkLCzaIfDl0_bQuVhWMvzJzOx0M2PJpeUhkaRP9VOtInK5o0woKZdhyCRPq5AiiE5kX4_aKsLbudbbqWMi2zh0wuD0e11q0cxqxDvF0cWEH_jf7c0J60"
            };


            Token = GenerarToken(jwks,payload,header); //MakeJwts(header,payload,jwks);

            return Token;
        }

        private string GenerarToken(JwksPrivate _jwks, DTO.JwtPayload _payload, DTO.JwtHeader _header)
        {
            RsaSecurityKey publicAndPrivateKey =GeneraLLave(_jwks);
            JsonWebTokenHandler tokenHandler = new();
            
            var claims = new System.Collections.Generic.Dictionary<string, object>
            {
                { "jti", Guid.NewGuid().ToString()},
            };

            SecurityTokenDescriptor descriptor = new()
            {
                Issuer = _payload.Iss,//"https://idp-qa.bancosecurity.cl/jans-auth/restv1/token",
                Audience = _payload.Aud,//"f8953ad4-3937-48fb-bc60-a9183bc3a5a9",
                Subject = new ClaimsIdentity(new Claim[] { new Claim("sub", _payload.Sub) }),//"f8953ad4-3937-48fb-bc60-a9183bc3a5a9") }),
                Expires = DateTime.UtcNow.AddYears(10), // Tiempo de expiraci?n del token
                IssuedAt = DateTime.UtcNow,
                NotBefore = DateTime.UtcNow,
                Claims = claims,                
                SigningCredentials = new SigningCredentials(publicAndPrivateKey, SecurityAlgorithms.RsaSha256),
            };

            string jwtstring = tokenHandler.CreateToken(descriptor);

            return jwtstring;
        }

        private RsaSecurityKey GeneraLLave(JwksPrivate jwks)
        {

            RSAParameters rsaParameters = new RSAParameters
            {
                Exponent = Base64UrlEncoder.DecodeBytes(jwks.e),
                Modulus = Base64UrlEncoder.DecodeBytes(jwks.n),
                P = Base64UrlEncoder.DecodeBytes(jwks.p),
                Q = Base64UrlEncoder.DecodeBytes(jwks.q),
                D = Base64UrlEncoder.DecodeBytes(jwks.d),
                DP = Base64UrlEncoder.DecodeBytes(jwks.dp),
                DQ = Base64UrlEncoder.DecodeBytes(jwks.dq),
                InverseQ = Base64UrlEncoder.DecodeBytes(jwks.qi)
            };

            // Crea un objeto RSACryptoServiceProvider y asigna los parámetros

            RSACryptoServiceProvider _rsa = new RSACryptoServiceProvider();
            
            _rsa.ImportParameters(rsaParameters);            

            var rsaSecurityKey = new RsaSecurityKey(_rsa)
            {
                KeyId=jwks.kid
            };

            return rsaSecurityKey;
        }

        private string Base64UrlEncode(string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            return Base64UrlEncode(bytes);
        }

        private string Base64UrlEncode(byte[] bytes)
        {
            var base64 = System.Convert.ToBase64String(bytes);
            var base64Url = base64.TrimEnd('=').Replace('+','-').Replace('/','_');
            return base64Url;
        }

        static JsonWebKey GetJWKFromRSA(RSA rsa)
        {
            var parameters = rsa.ExportParameters(true);
            var exponent = Base64UrlEncoder.Encode(parameters.Exponent);
            var modulus = Base64UrlEncoder.Encode(parameters.Modulus);

            var jwk = new JsonWebKey
            {
                Kty = "RSA",
                E = exponent,
                N = modulus,
                D = Base64UrlEncoder.Encode(parameters.D),
                P = Base64UrlEncoder.Encode(parameters.P),                
                Alg = "RS256",
                Use = "sig"
            };

            return jwk;
        }

        [HttpGet("Jwk")]
        public string GetKey()
        {
            // Genera una nueva clave RSA
            using var rsa = RSA.Create(2048); // Selecciona el tamaño de clave RSA deseado
                        
            RsaSecurityKey publicAndPrivateKey = new(rsa.ExportParameters(true))
            {
                KeyId = "be849d93-4f38-4d20-8fae-54c6ea4bc965"                
            };
            JsonWebKey jwk1 = JsonWebKeyConverter.ConvertFromRSASecurityKey(publicAndPrivateKey);
            jwk1.Use = "sign";
            jwk1.Alg = SecurityAlgorithms.RsaSha256;

            JsonWebKey jwk2 = new JsonWebKey
            {
                Kty = jwk1.Kty,
                E = jwk1.E,
                Use = jwk1.Use,
                Kid = jwk1.Kid,
                Alg = jwk1.Alg,
                N = jwk1.N,
            };

            

            IList<JsonWebKey> jwksList = new List<JsonWebKey>
            {
                jwk1, jwk2                
            };

            Dictionary<string, IList<JsonWebKey>> jwksDict = new()
            {
                { "keys", jwksList }
            };

            string jwksStr = SerializeObject(jwksDict) ;

            JsonWebTokenHandler tokenHandler = new();

            SecurityTokenDescriptor descriptor = new()
            {
                Issuer = "https://idp-qa.bancosecurity.cl/jans-auth/restv1/token",
                Audience = "f8953ad4-3937-48fb-bc60-a9183bc3a5a9",
                Subject = new ClaimsIdentity(new Claim[] { new Claim("sub", "f8953ad4-3937-48fb-bc60-a9183bc3a5a9") }),
                Expires = DateTime.UtcNow.AddYears(10), // Tiempo de expiraci?n del token
                IssuedAt= DateTime.UtcNow,                
                SigningCredentials = new SigningCredentials(publicAndPrivateKey, SecurityAlgorithms.RsaSha256),
            };

            string jwtstring = tokenHandler.CreateToken(descriptor);

            return jwksStr + jwtstring;
        }

        private static string SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            });
        }

        static DefaultContractResolver contractResolver = new DefaultContractResolver {NamingStrategy = new CamelCaseNamingStrategy() };

        static void RemoveNullProperties(JObject obj)
        {
            foreach (JProperty prop in obj.Properties().ToList())
            {
                if (prop.Value.Type == JTokenType.Null)
                {
                    prop.Remove();
                }
                else if (prop.Value.Type == JTokenType.Object)
                {
                    RemoveNullProperties((JObject)prop.Value);
                }
            }
        }

    }
}
