using Projekcik.Database.Models;

namespace Projekcik.Core.Services
{
    public interface ITokenManager
    {
        public string GenerateAccessToken(User user);
    }
}