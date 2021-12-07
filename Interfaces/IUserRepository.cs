using System.Threading.Tasks;
using ToursApi.Entities;

namespace ToursApi.Interfaces
{
    public interface IUserRepository
    {
        void Update(User user);
        Task<bool> SaveAllAsync();
        
        // Task<PagedList<User>> GetUsersAsync(UserParams userParams);
        // Task<User> GetUserByIdAsync(int id);
        // Task<User> GetUserByUsernameAsync(string username);
        //
        // Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams);
        // Task<MemberDto> GetMemberByIdAsync(int id);
        // Task<MemberDto> GetMemberByUsernameAsync(string username);
    }
}