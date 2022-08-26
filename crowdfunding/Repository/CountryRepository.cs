using crowdfunding.Context;
using crowdfunding.Contracts;
using crowdfunding.Dto;
using crowdfunding.Entities;
using Dapper;
using System.Data;

namespace crowdfunding.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DapperContext _dapper;

        public CountryRepository(DapperContext dapperContext)
        {
            _dapper = dapperContext;
        }

        public async Task<Country> AddCountry(CountryDto countryDto)
        {
            var query = "insert into Country(code, name) values(@code, @name); SELECT LAST_INSERT_ID();";
            
            using (var connection = _dapper.CreateConnection()) 
            {
                await connection.OpenAsync();
                var id = await connection.ExecuteAsync(query, countryDto);
                var country = new Country
                {
                    Id = id,
                    Code = countryDto.Code,
                    Name = countryDto.Name
                };
                return country;
            }            
        }

        public async Task<Country> GetById(int IdCountry)
        {
            using (var connection = _dapper.CreateConnection())
            {
                connection.Open();
                var result = await connection.QueryFirstOrDefaultAsync<Country>("getCountryById", new { IdCountry },
                                 commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<Country> GetByCode(string countryCode)
        {
            using (var connection = _dapper.CreateConnection())
            {
                connection.Open();
                var result = await connection.QueryFirstOrDefaultAsync<Country>("getCountryByCode", new { countryCode },
                                 commandType: CommandType.StoredProcedure);
                return result;
            }
        }


        public async Task<IEnumerable<Country>> GetCountries()
        {
            var query = "select ID, code, name from Country";
            using (var connection = _dapper.CreateConnection())
            {
                var countries = await connection.QueryAsync<Country>(query);
                return countries.ToList();
            }
        }
    }
}
