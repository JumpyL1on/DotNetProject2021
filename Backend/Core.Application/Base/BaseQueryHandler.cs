using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Application.Base
{
    public class BaseQueryHandler
    {
        protected DbContext DbContext { get; }
        protected IMapper Mapper { get; }

        public BaseQueryHandler(DbContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }
    }
}