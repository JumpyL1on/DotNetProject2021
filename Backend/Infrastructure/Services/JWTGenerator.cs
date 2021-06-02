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
        private AuthOptions AuthOptions { get; }

        public JWTGenerator(IConfiguration configuration)
        {
            AuthOptions = configuration.GetSection("AuthOptions").Get<AuthOptions>();
        }

        public string CreateToken(TeamMember teamMember)
        {
            return new JwtSecurityTokenHandler()
                .WriteToken(new JwtSecurityToken(
                    AuthOptions.Issuer,
                    AuthOptions.Audience,
                    new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, teamMember.Id.ToString()),
                        new Claim(ClaimTypes.NameIdentifier, teamMember.Id.ToString()),
                        new Claim(JwtRegisteredClaimNames.UniqueName, teamMember.UserName),
                        new Claim(JwtRegisteredClaimNames.Email, teamMember.Email),
                        new Claim("role", teamMember.Role.ToString().ToLower())
                    },
                    DateTime.Now,
                    DateTime.Now.AddMinutes(AuthOptions.Lifetime),
                    new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthOptions.Key)), "HS256")));
        }
    }
}