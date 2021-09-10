using System;

namespace Projekcik.Infrastructure.Auth
{
    public class AuthOptions
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public TimeSpan Expiry { get; set; }
    }
}
