using crowdfunding.Dto;
using crowdfunding.Entities;

namespace crowdfunding.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
