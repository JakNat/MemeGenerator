using Server.Infrastructure.DTO;
using System;

namespace Server.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(Guid userId, string role);
    }
}
