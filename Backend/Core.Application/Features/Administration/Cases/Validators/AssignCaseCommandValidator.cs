using Backend.Core.Application.Features.Administration.Cases.Commands;
using Backend.Core.Domain.Entities;
using Backend.Core.Domain.Enums;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Application.Features.Administration.Cases.Validators
{
    public class AssignCaseCommandValidator : AbstractValidator<AssignCaseCommand>
    {
        public AssignCaseCommandValidator(DbContext dbContext)
        {
            RuleFor(command => command.Id)
                .MustAsync(async (guid, token) =>
                {
                    var @case = await dbContext
                        .Set<Case>()
                        .FindAsync(new object[] {guid}, token);
                    return @case != null && @case.TeamMemberId == null;
                })
                .DependentRules(() =>
                {
                    var teamMembers = dbContext.Set<TeamMember>();
                    RuleFor(command => command.TeamMemberId)
                        .MustAsync(async (guid, token) =>
                        {
                            var director = await teamMembers
                                .FindAsync(new object[] {guid}, token);
                            return director != null && director.Role == Role.Director;
                        })
                        .DependentRules(() =>
                        {
                            RuleFor(command => command.AssigneeId)
                                .MustAsync(async (guid, token) =>
                                {
                                    var manager = await teamMembers
                                        .FindAsync(new object[] {guid}, token);
                                    return manager != null && manager.Role == Role.Manager;
                                });
                        });
                });
        }
    }
}