using crowdfunding.Dto;
using crowdfunding.Entities;

namespace crowdfunding.Contracts
{
    public interface IUserRepository
    {
        Task<User> GetByLogin(string login, string hashPassword);

        Task<User> GetByEmail(string email);
        Task<User> GetByLogin(string userLogin);
        Task<User> Add(UserDto userDto);

        Task<User> GetById(int id);

        Task<IEnumerable<User>> GetList();
        Task<User> GetUserByLoginOrMobile(string userLogin, string userMobile);


    }
}
