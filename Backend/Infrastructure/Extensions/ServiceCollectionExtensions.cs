using Backend.Core.Application.Interfaces;
using Backend.Core.Domain.Entities;
using Backend.Infrastructure.Data;
using Backend.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(builder => builder.UseNpgsql(connection));
            services
                .AddIdentityCore<TeamMember>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                    options.User.AllowedUserNameCharacters += ' ';
                })
                .AddSignInManager()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<AppDbContext>();
            services.AddScoped<DbContext, AppDbContext>();
            services.AddScoped<IJWTGenerator, JWTGenerator>();
            services.AddTransient<IEmailSender, EmailSender>();
            return services;
        }
    }
}