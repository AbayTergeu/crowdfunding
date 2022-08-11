using crowdfunding.Dto;
using crowdfunding.Entities;

namespace crowdfunding.Contracts
{
    public interface ICountryRepository
    {
        public Task<IEnumerable<Country>> GetCountries();
        public Task<Country> AddCountry(CountryDto countryDto);
    }
}
