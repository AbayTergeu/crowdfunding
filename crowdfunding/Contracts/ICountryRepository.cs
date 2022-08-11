using crowdfunding.Dto;
using crowdfunding.Entities;

namespace crowdfunding.Contracts
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetCountries();
        Task<Country> AddCountry(CountryDto countryDto);

        Task<Country> GetById(int id);
        
    }
}
