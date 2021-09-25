using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GamblingGame.Domain.Consts;
using GamblingGame.Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace GamblingGame.Domain.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        public string CreateToken(Guid userId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Const.JwtSecret));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.Now.AddHours(4),
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(Const.IdClaimType, userId.ToString())
                }),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
