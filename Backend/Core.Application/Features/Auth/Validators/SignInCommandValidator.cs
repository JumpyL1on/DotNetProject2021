using Backend.Core.Application.Features.Auth.Commands;
using Backend.Core.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Backend.Core.Application.Features.Auth.Validators
{
    public class SignInCommandValidator : AbstractValidator<SignInCommand>
    {
        public SignInCommandValidator(UserManager<TeamMember> userManager, SignInManager<TeamMember> signInManager)
        {
            TeamMember teamMember = null;
            RuleFor(command => command.Email)
                .MustAsync(async (email, _) =>
                {
                    teamMember = await userManager.FindByEmailAsync(email);
                    return teamMember is not null;
                })
                .DependentRules(() =>
                {
                    RuleFor(command => command.Password)
                        .MustAsync(async (password, _) =>
                        {
                            var result = await signInManager.CheckPasswordSignInAsync(teamMember, password, false);
                            return result.Succeeded;
                        });
                });
        }
    }
}