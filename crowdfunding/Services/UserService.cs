using crowdfunding.Contracts;
using crowdfunding.Dto;
using crowdfunding.Entities;
using crowdfunding.Helpers;
using crowdfunding.Helpers.Auth;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace crowdfunding.Services
{
    public class UserService : IUserService
    {
        private List<User> _users = new List<User>
    {
        new User { Id = 1, Name = "Test", Surname = "User", Login = "test", Password = "test" }
    };

        private readonly AppSettings _appSettings;
        private readonly IUserRepository _userRepository;

        public UserService(IOptions<AppSettings> appSettings, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var HashPassword = PasswordHelper.CryptPassword(model.Password);
            var user = await _userRepository.GetByLogin(model.Login, HashPassword);

            // return null if user not found
            if (user == null) 
                throw new ArgumentException("user not found");

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userRepository.GetList();
        }

        public async Task<User> GetById(int id)
        {
            var user = await _userRepository.GetById(id);
            return user;
        }

        // helper methods

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 15 minutes
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<User> Add(UserDto userDto)
        {
            if (await IsExistsUser(userDto.Login, userDto.Mobile))
                throw new ArgumentException("User by Login or Mobile already exists");
            userDto.Password = PasswordHelper.CryptPassword(userDto.Password);
            return await _userRepository.Add(userDto);
        }

        public async Task<bool> IsExistsUser(string userLogin, string userMobile)
        {
            var user = await _userRepository.GetUserByLoginOrMobile(userLogin, userMobile);
            if (user != null)
                return true;
            return false;
        }
    }
}
