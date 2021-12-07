using System.Threading.Tasks;
using AutoMapper;
using ToursApi.Entities;
using ToursApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ToursApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        // public async Task<PagedList<User>> GetUsersAsync(UserParams userParams)
        // {
        //     var users = _context.Users
        //         .OrderByDescending(u => u.LastActive)
        //         .Include(u => u.Photos)
        //         .AsQueryable();
        //
        //     users = users.Where(x => x.Gender == userParams.Gender);
        //
        //     // make sure query doesn't return authenticated user
        //     users = users.Where(x => x.Username != userParams.Username);
        //
        //     if (userParams.MinAge != 18 || userParams.MaxAge != 99)
        //     {
        //         // Dob = date of birth
        //         var minDob = DateTime.Today.AddYears(-userParams.MaxAge - 1);
        //         var maxDob = DateTime.Today.AddYears(-userParams.MinAge);
        //
        //         users = users.Where(x => x.Birthday >= minDob && x.Birthday <= maxDob);
        //     }
        //
        //     if (!string.IsNullOrEmpty(userParams.OrderBy))
        //     {
        //         users = userParams.OrderBy switch
        //         {
        //             "created" => users.OrderByDescending(u => u.CreatedAt),
        //             _ => users.OrderByDescending(u => u.LastActive)
        //         };
        //     }
        //
        //     if (!string.IsNullOrEmpty(userParams.LastActive))
        //     {
        //         users = userParams.LastActive switch
        //         {
        //             // last active needs to be later than today minus number of days/months/years
        //             "day" => users.Where(x => x.LastActive.CompareTo(DateTime.Today.AddDays(-1)) >= 0),
        //             "week" => users.Where(x => x.LastActive.CompareTo(DateTime.Today.AddDays(-7)) >= 0),
        //             "month" => users.Where(x => x.LastActive.CompareTo(DateTime.Today.AddMonths(-1)) >= 0),
        //             "year" => users.Where(x => x.LastActive.CompareTo(DateTime.Today.AddYears(-1)) >= 0),
        //             _ => users
        //         };
        //     }
        //
        //     return await PagedList<User>.CreateAsync(
        //         users, userParams.PageNumber, userParams.PageSize
        //     );
        // }

        // public async Task<User> GetUserByIdAsync(int id)
        // {
        //     var query = _context.Users.Where(u => u.Id == id)
        //         .Include(u => u.Photos)
        //         .FirstOrDefaultAsync();
        //
        //     // var query2 = GetAll()
        //     //     .Include(p => p.Photos)
        //     //     .FirstOrDefaultAsync(u => u.Id == id);
        //
        //     /* Both queries generate the same SQL query, so they have the same execution speed. */
        //
        //     return await query;
        // }
        //
        // public async Task<User> GetUserByUsernameAsync(string username)
        // {
        //     return await _context.Users.Where(u => u.Username == username)
        //         .Include(u => u.Photos)
        //         .FirstOrDefaultAsync();
        // }

        // public async Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams)
        // {
        //     var members = _context.Users
        //         .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
        //         // make sure query doesn't return authenticated member
        //         .Where(x => x.Username != userParams.Username)
        //         .OrderByDescending(u => u.LastActive)
        //         .AsQueryable();
        //
        //     members = members.Where(x => x.Gender == userParams.Gender);
        //
        //     if (userParams.MinAge != 18 || userParams.MaxAge != 99)
        //     {
        //         members = members.Where(x => x.Age >= userParams.MinAge && x.Age <= userParams.MaxAge);
        //     }
        //
        //     if (!string.IsNullOrEmpty(userParams.OrderBy))
        //     {
        //         members = userParams.OrderBy switch
        //         {
        //             "created" => members.OrderByDescending(u => u.CreatedAt),
        //             _ => members.OrderByDescending(u => u.LastActive)
        //         };
        //     }
        //
        //     if (!string.IsNullOrEmpty(userParams.LastActive))
        //     {
        //         members = userParams.LastActive switch
        //         {
        //             // last active needs to be later than today minus number of days/months/years
        //             "day" => members.Where(x => x.LastActive.CompareTo(DateTime.Today.AddDays(-1)) >= 0),
        //             "week" => members.Where(x => x.LastActive.CompareTo(DateTime.Today.AddDays(-7)) >= 0),
        //             "month" => members.Where(x => x.LastActive.CompareTo(DateTime.Today.AddMonths(-1)) >= 0),
        //             "year" => members.Where(x => x.LastActive.CompareTo(DateTime.Today.AddYears(-1)) >= 0),
        //             _ => members
        //         };
        //     }
        //
        //     return await PagedList<MemberDto>.CreateAsync(
        //         members, userParams.PageNumber, userParams.PageSize
        //     );
        // }

        // public async Task<MemberDto> GetMemberByIdAsync(int id)
        // {
        //     return await _context.Users
        //         .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
        //         .SingleOrDefaultAsync(u => u.Id == id);
        // }

        // public async Task<MemberDto> GetMemberByUsernameAsync(string username)
        // {
        //     return await _context.Users
        //         .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
        //         .SingleOrDefaultAsync(u => u.Username == username);
        // }
    }
}