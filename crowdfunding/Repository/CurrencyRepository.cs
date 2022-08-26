using crowdfunding.Context;
using crowdfunding.Contracts;
using crowdfunding.Dto;
using crowdfunding.Entities;
using Dapper;
using System.Data;

namespace crowdfunding.Repository
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly DapperContext _dapper;

        public CurrencyRepository(DapperContext dapperContext)
        {
            _dapper = dapperContext;
        }
        public async Task<Currency> Add(CurrencyDto currencyDto)
        {
            var query = "insert into Currensy(code, name) values(@code, @name); SELECT LAST_INSERT_ID();";

            using (var connection = _dapper.CreateConnection())
            {
                await connection.OpenAsync();
                var id = await connection.ExecuteAsync(query, currencyDto);
                var currency = new Currency
                {
                    Id = id,
                    Code = currencyDto.Code,
                    Name = currencyDto.Name
                };
                return currency;
            }
        }

        public async Task<Currency> GetById(int currencyId)
        {
            using (var connection = _dapper.CreateConnection())
            {
                connection.Open();
                var result = await connection.QueryFirstOrDefaultAsync<Currency>("getCurrencyById", new { currencyId },
                                 commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<Currency>> GetCurrencies()
        {
            var query = "select ID, code, name from Currency";
            using (var connection = _dapper.CreateConnection())
            {
                var currencies = await connection.QueryAsync<Currency>(query);
                return currencies.ToList();
            }
        }
    }
}
