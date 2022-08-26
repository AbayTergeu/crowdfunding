using crowdfunding.Contracts;
using crowdfunding.Dto;
using crowdfunding.Helpers;
using crowdfunding.Helpers.Auth;
using crowdfunding.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace crowdfunding.Controllers
{

    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly AppSettings _appSettings;

        public AuthController(IUserService userService, IUserRepository userRepository, IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<AuthData>> Authenticate(AuthenticateRequest model)
        {
            var user = await _userRepository.GetByEmail(model.Email);
            // return null if user not found
            if (user == null)
                return BadRequest(new { message = "user not found" });

            if (!PasswordHelper.CompareHash(model.Password, user.Password))
                return BadRequest(new { message = "invalid user password" });
            var response = _userService.Authenticate(user);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return new AuthData
            {
                Token = _userService.GenerateJwtToken(user.Id),
                TokenExpirationTime = ((DateTimeOffset)DateTime.UtcNow.AddMinutes(_appSettings.JwtLifespan)).ToUnixTimeSeconds(),
                Id = user.Id.ToString()
            };
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthData>> Post([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userByEmail = await _userRepository.GetByEmail(model.Email);
            if (userByEmail != null) return BadRequest(new { email = "user with this email already exists" });
            var userByLogin = await _userRepository.GetByLogin(model.Username);
            if (userByLogin != null) return BadRequest(new { username = "user with this username already exists" });

            var dto = new UserDto
            {
                Username = model.Username,
                Email = model.Email,
                Password = model.Password
            };
            var user = _userService.Add(dto);
            return new AuthData
            {
                Token = _userService.GenerateJwtToken(user.Id),
                TokenExpirationTime = ((DateTimeOffset)DateTime.UtcNow.AddMinutes(_appSettings.JwtLifespan)).ToUnixTimeSeconds(),
                Id = user.Id.ToString()
            };
        }
    }
}
