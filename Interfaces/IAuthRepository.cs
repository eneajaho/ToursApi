using System.Threading.Tasks;
using ToursApi.Entities;

namespace ToursApi.Interfaces
{
    public interface IAuthRepository
    {
        Task Register(User user, string password);
        Task<User?> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}