using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.negocio.Clases;

namespace TR.negocio.Token
{
    public class Token
    {
        const string Secret = "TurismoReal";

        public string CreateToken(TR_Acceso acceso)
        {
            var payload = new Dictionary<string, object>
            {
                {"run" , acceso.USUARIO1},
                {"constrasena" , acceso.CONTRASENA }
            };

            IJwtAlgorithm algoritm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncode = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algoritm, serializer, urlEncode);

            var token = encoder.Encode(payload, Secret);
            return token;
        }

        public string ValidateToken(string token)
        {
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                JwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var json = decoder.Decode(token, Secret, verify: true);
                return json;
            }
            catch (TokenExpiredException)
            {

                return "El tiempo de vida del token ha expirado";
            }
            catch (SignatureVerificationException)
            {
                return "El token ingresado posee una firma invalida";
            }
        }
    }
}
