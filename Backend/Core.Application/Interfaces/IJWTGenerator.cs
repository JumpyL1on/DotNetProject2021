using Backend.Core.Domain.Entities;

namespace Backend.Core.Application.Interfaces
{
    public interface IJWTGenerator
    {
        string CreateToken(TeamMember teamMember);
    }
}