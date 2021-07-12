using System;
using Projekcik.Database.Models;

namespace Projekcik.Core.Services
{
    public interface IUserInfo
    {
        User GetCurrentUser();
        public bool IsLogged { get; }
        public Guid Id { get; }
    }
}