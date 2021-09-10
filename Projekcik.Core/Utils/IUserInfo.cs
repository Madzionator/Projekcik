using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Projekcik.Core.Exceptions;
using Projekcik.Database;
using Projekcik.Database.Models;

namespace Projekcik.Core.Utils
{
    public interface IUserInfo
    {
        User GetCurrentUser();
        public bool IsLogged { get; }
        public Guid Id { get; }
    }

    internal class UserInfo : IUserInfo
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserInfo(IHttpContextAccessor httpContextAccessor, DataContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        private IEnumerable<Claim> Claims => _httpContextAccessor?.HttpContext?.User?.Claims;
        private string _id => Claims.FirstOrDefault(x => x.Type == "id")?.Value;

        public bool IsLogged => _httpContextAccessor?.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
        public Guid Id => _id == null ? Guid.Empty : new Guid(_id);

        public User GetCurrentUser()
        {
            var user = _context.Users.Find(Id);
            if (user == null)
            {
                throw new UserNotFoundException("");
            }
            return user;
        }
    }
}