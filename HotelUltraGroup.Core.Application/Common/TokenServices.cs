using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using HotelUltraGroup.Core.Application.Common.Interfaces;

namespace HotelUltraGroup.Core.Application.Common
{
    public class TokenServices : ITokenServices
    {
        public async Task<string> GenerateTokenAsync(string _user, string _id, string _rol, TokenConfigDTO _TokenConfigDTO)
        {
            var claims = new[]
           {
            new Claim(JwtRegisteredClaimNames.UniqueName, _user),
            new Claim("User", _user),
            new Claim("Id", _id),
            new Claim(ClaimTypes.Role, _rol),
            };
            IdentityModelEventSource.ShowPII = true;
            var keybuffer = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_TokenConfigDTO.key));
            DateTime expireTime = DateTime.Now.AddMinutes(int.Parse(_TokenConfigDTO.durationInMinutes));
            var token = new JwtSecurityToken(issuer: _TokenConfigDTO.issuer, audience: _TokenConfigDTO.audience, claims, expires: expireTime, signingCredentials: new SigningCredentials(keybuffer, SecurityAlgorithms.HmacSha256));

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenAsString;

        }

    }
}
