using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Backend.Core.Application.Interfaces;
using Backend.Core.Domain.Entities;
using Backend.Core.Domain.ValueObjects;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Infrastructure.Services
{
    public class JWTGenerator : IJWTGenerator
    {
        private JWTSettings JWTSettings { get; }

        public JWTGenerator(IConfiguration configuration)
        {
            JWTSettings = configuration.GetSection("JWTSettings").Get<JWTSettings>();
        }

        public string CreateToken(TeamMember teamMember)
        {
            var claims = new Claim[]
            {
                new(ClaimsIdentity.DefaultNameClaimType, teamMember.Email),
                new("role", teamMember.Role.ToString().ToLower())
            };
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTSettings.SecurityKey));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                JWTSettings.ValidIssuer,
                JWTSettings.ValidAudience,
                claims,
                DateTime.Now,
                DateTime.Now.AddMinutes(JWTSettings.ExpiryInMinutes),
                signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
    }
}