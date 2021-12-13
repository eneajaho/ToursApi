using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToursApi.DTOs.User;
using ToursApi.Entities;
using ToursApi.Extensions;
using ToursApi.Helpers;
using ToursApi.Interfaces;
using ToursApi.Services;

namespace ToursApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [AuthorizedRoles(Role.Admin)]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly UserService _userService;
        private readonly IAuthRepository _authRepo;
        private readonly IMapper _mapper;

        public UserController(DataContext context, UserService userService, IAuthRepository authRepo, IMapper mapper)
        {
            _context = context;
            _userService = userService;
            _authRepo = authRepo;
            _mapper = mapper;
        }

        // GET: api/User
        [HttpGet]
        public async Task<PagedData<UserDto>> GetUsers([FromQuery] GetUsersParams userParams) =>
            await _userService.GetUsersAsync(userParams, User.GetId());

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
                return NotFound();

            return user;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserUpdateDto userUpdateDto)
        {
            if (id != userUpdateDto.Id)
                return BadRequest("The ID are mismatched");

            // if the auth user is admin he can edit any user, otherwise auth user can edit only himself
            if (id != User.GetId() && User.GetRole() == Role.User)
                return Unauthorized();
            
            var userFromRepo = await _userService.GetByIdAsync(id);

            if (userFromRepo == null)
                return NotFound();

            _mapper.Map<UserUpdateDto, User>(userUpdateDto, userFromRepo);
            
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserDto>> PostUser(UserCreateDto userCreateDto)
        {
            userCreateDto.Email = userCreateDto.Email.Trim().ToLower();

            if (await _authRepo.UserExists(userCreateDto.Email))
                return BadRequest("A user with that email already exists!");
            
            var userToCreate = _mapper.Map<User>(userCreateDto);

            await _authRepo.Register(userToCreate, userCreateDto.Password);
            
            var userForReturn = _mapper.Map<UserDto>(userToCreate);

            return CreatedAtAction("GetUser", new {id = userForReturn.Id}, userForReturn);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            
            if (user == null)
                return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}