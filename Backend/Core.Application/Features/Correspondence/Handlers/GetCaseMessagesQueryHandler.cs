using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend.Core.Application.Base;
using Backend.Core.Application.Features.Correspondence.DTOs;
using Backend.Core.Application.Features.Correspondence.Queries;
using Backend.Core.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Application.Features.Correspondence.Handlers
{
    public class GetCaseMessagesQueryHandler : BaseQueryHandler, IRequestHandler<GetCaseMessagesQuery, MessageDTO[]>
    {
        public GetCaseMessagesQueryHandler(DbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<MessageDTO[]> Handle(GetCaseMessagesQuery request, CancellationToken cancellationToken)
        {
            return await DbContext
                .Set<Message>()
                .Where(message => message.CaseId == request.CaseId)
                .ProjectTo<MessageDTO>(Mapper.ConfigurationProvider)
                .ToArrayAsync(cancellationToken);
        }
    }
}