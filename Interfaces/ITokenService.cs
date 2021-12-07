using ToursApi.Entities;

namespace ToursApi.Interfaces
{
    public interface ITokenService
    {
        public string CreateToken(User user);
    }
}