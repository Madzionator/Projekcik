using System;

namespace Projekcik.Infrastructure.Api
{
    public interface IAuthManager
    {
        JsonWebToken CreateToken(Guid userId);
    }
}