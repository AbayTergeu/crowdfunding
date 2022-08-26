using crowdfunding.Dto;
using crowdfunding.Entities;

namespace crowdfunding.Services
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(User user);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> Add(UserDto userDto);
        string GenerateJwtToken(int Id);
    }
}
