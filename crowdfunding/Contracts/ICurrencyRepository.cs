using crowdfunding.Dto;
using crowdfunding.Entities;

namespace crowdfunding.Contracts
{
    public interface ICurrencyRepository
    {
        Task<IEnumerable<Currency>> GetCurrencies();
        Task<Currency> Add(CurrencyDto currencyDto);

        Task<Currency> GetById(int id);
    }
}
