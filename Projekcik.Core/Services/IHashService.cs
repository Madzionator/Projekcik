namespace Projekcik.Core.Services
{
    public interface IHashService
    {
        public string Hash(string password);
        public bool Check(string hashed, string password);
    }
}