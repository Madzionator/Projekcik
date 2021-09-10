using System;

namespace Projekcik.Abstractions.Auth
{
    public interface IAuthManager
    {
        JsonWebToken CreateToken(Guid userId);
    }
}