using crowdfunding.Entities;

namespace crowdfunding.Contracts
{
    public interface IAccountRepository
    {
        Task<Account> GetAccountByClientId(int inClientId);
    }
}
