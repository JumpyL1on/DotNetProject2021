using System;
using Backend.Core.Application.Features.Correspondence.DTOs;
using MediatR;

namespace Backend.Core.Application.Features.Correspondence.Queries
{
    public record GetAssignedCaseByIdQuery : IRequest<AssignedCaseDTO>
    {
        public Guid Id { get; init; }

        public GetAssignedCaseByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}