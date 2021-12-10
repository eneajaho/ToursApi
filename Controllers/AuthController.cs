using System.Threading.Tasks;
using AutoMapper;
using ToursApi.Entities;
using ToursApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ToursApi.DTOs.User;

namespace ToursApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IAuthRepository _authRepo;
        private readonly IMapper _mapper;

        public AuthController(IAuthRepository authRepo, IMapper mapper, ITokenService tokenService)
        {
            _authRepo = authRepo;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.Email = userForRegisterDto.Email.Trim().ToLower();

            if (await _authRepo.UserExists(userForRegisterDto.Email))
                return BadRequest("A user with that email already exists!");

            var userToCreate = _mapper.Map<User>(userForRegisterDto);

            await _authRepo.Register(userToCreate, userForRegisterDto.Password);

            return Ok(new AuthUserDto
            {
                Id = userToCreate.Id,
                Name = userToCreate.Name,
                Email = userToCreate.Email,
                Role = userToCreate.Role.ToString(),
                Token = _tokenService.CreateToken(userToCreate)
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var email = userForLoginDto.Email.Trim().ToLower();

            var userFromRepo = await _authRepo.Login(email, userForLoginDto.Password);

            if (!await _authRepo.UserExists(email))
                return BadRequest("The user with the email you provided does not exist!");

            if (userFromRepo == null)
                return BadRequest("The password you entered is not correct!");

            return Ok(new AuthUserDto
            {
                Id = userFromRepo.Id,
                Name = userFromRepo.Name,
                Email = userFromRepo.Email,
                Role = userFromRepo.Role.ToString(),
                Token = _tokenService.CreateToken(userFromRepo)
            });
        }
    }
}