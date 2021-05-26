using System;
using System.Security.Claims;
using Backend.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Backend.Infrastructure.Extensions
{
    public static class UserManagerExtensions
    {
        public static Guid GetUserGuid(this UserManager<TeamMember> userManager, ClaimsPrincipal claimsPrincipal)
        {
            var id = userManager.GetUserId(claimsPrincipal);
            return Guid.TryParse(id, out var guid) ? guid : Guid.Empty;
        }
    }
}