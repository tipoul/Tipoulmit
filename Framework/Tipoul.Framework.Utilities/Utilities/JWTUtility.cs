using Microsoft.IdentityModel.Tokens;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.Utilities.Utilities
{
    public class JWTUtility
    {
        private const string Secret = "^&%&^%&^hjsdfb2%%%asdv234234^&%&^%&^hjsdfb2%%%";
        private const string Issuer = "http://tipoul.com";
        private const string Audience = "http://clients.tipoul.com";

        public static string GenerateToken(Dictionary<string, string> claims)
        {
            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));


            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims.Select(f => new Claim(f.Key, f.Value ?? string.Empty))),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = Issuer,
                Audience = Audience,
                SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static bool ValidateCurrentToken(string token)
        {
            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = Issuer,
                    ValidAudience = Audience,
                    IssuerSigningKey = mySecurityKey
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
