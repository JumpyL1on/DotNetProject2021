using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Application.Base
{
    public class BaseCommandHandler
    {
        protected DbContext DbContext { get; }

        public BaseCommandHandler(DbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}