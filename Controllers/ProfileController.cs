using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToursApi.DTOs.User;
using ToursApi.Entities;
using ToursApi.Extensions;
using ToursApi.Services;

namespace ToursApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public ProfileController(UserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<UserDto?> GetUserProfile() => 
            await _userService.GetUserByIdAsync(User.GetId());

        [HttpPut]
        public async Task<ActionResult> UpdateUserProfile(SelfUserUpdateDto userUpdateDto)
        {
            if (userUpdateDto.Id != User.GetId())
                return Unauthorized();

            var userFromRepo = await _userService.GetByIdAsync(User.GetId());

            if (userFromRepo == null)
                return NotFound();
            
            _mapper.Map<SelfUserUpdateDto, User>(userUpdateDto, userFromRepo);

            await _userService.SaveChangesAsync();

            return NoContent();
        }
    }
}