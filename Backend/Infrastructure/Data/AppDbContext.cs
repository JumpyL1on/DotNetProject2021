using System;
using Backend.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Data
{
    public class AppDbContext : IdentityUserContext<TeamMember, Guid>
    {
        public DbSet<Case> Cases { get; protected set; }
        public DbSet<Client> Clients { get; protected set; }
        public DbSet<Message> Messages { get; protected set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}