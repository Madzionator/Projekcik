using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Projekcik.Api.Models
{
    public class UserInfo
    {
        private readonly TodoDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserInfo(IHttpContextAccessor httpContextAccessor, TodoDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        private IEnumerable<Claim> Claims => _httpContextAccessor?.HttpContext?.User?.Claims;
        private string _id => Claims.FirstOrDefault(x => x.Type == "id")?.Value;

        public bool IsLogged => _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        public Guid Id => _id == null ? Guid.Empty : new Guid(_id);

        public User GetCurrentUser()
        {
            var user = _context.Users.Find(Id);
            return user;
        }
    }
}
