using crowdfunding.Dto;
using crowdfunding.Entities;

namespace crowdfunding.Services
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> Add(UserDto userDto);
    }
}
