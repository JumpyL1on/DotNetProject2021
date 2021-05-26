using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Backend.Core.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Backend.Core.Domain.Entities
{
    public class TeamMember : IdentityUser<Guid>
    {
        [Required] public Role Role { get; set; }
        [Required] public bool IsDeleted { get; set; }
        public ICollection<Case> Cases { get; protected set; }

        public TeamMember(string userName) : base(userName)
        {
        }

        protected TeamMember()
        {
        }
    }
}