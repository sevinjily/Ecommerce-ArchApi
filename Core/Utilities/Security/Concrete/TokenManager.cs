using Core.Entities.Concrete;
using Core.Utilities.Security.Abstract;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Concrete
{
    public class TokenManager : ITokenService
    {
        public Task<Token> CreateAccessToken(AppUser appUser, List<string> roles)
        {
           Token token = new();
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier,appUser.Id),
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(""));
            token.ExpiredDate= DateTime.Now.AddMinutes(2);
            JwtSecurityToken securityToken = new
                (
                issuer: "",
                audience: "",
                expires:token.ExpiredDate,
                notBefore:DateTime.Now,
                claims:claims,
                signingCredentials:new SigningCredentials(key,SecurityAlgorithms.HmacSha512)
                );
 
        }

        public string RefreshToken()
        {
            throw new NotImplementedException();
        }
    }
}
