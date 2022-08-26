using crowdfunding.Context;
using crowdfunding.Contracts;
using crowdfunding.Dto;
using crowdfunding.Entities;
using Dapper;
using System.Data;

namespace crowdfunding.Repository
{
    public class InvestmentsRepository : IInvestmentsRepository
    {
        private readonly DapperContext _dapperContext;
        private readonly ICountryRepository _countryRepository;
        private readonly ICurrencyRepository _currencyRepository;
        private readonly ILogger<UserRepository> _logger;

        public InvestmentsRepository(DapperContext dapperContext, ICountryRepository countryRepository, ILogger<UserRepository> logger, ICurrencyRepository currencyRepository)
        {
            _dapperContext = dapperContext;
            _countryRepository = countryRepository;
            _logger = logger;
            _currencyRepository = currencyRepository;
        }

        public async Task<Investments> Add(InvestmentsDto investmentsDto)
        {
            var currency = await _currencyRepository.GetById((int)investmentsDto.InCurrencyId);
            if (currency == null)
                throw new ArgumentException("CURRENCY_NOT_FOUND");


            using (var connection = _dapperContext.CreateConnection())
            {
                var investments = await connection.QueryFirstOrDefaultAsync<Investments>("InsertInvestments", investmentsDto, commandType: System.Data.CommandType.StoredProcedure);
                return investments;
            }
        }

        public async Task<Investments> GetById(int investmentsId)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var investments = await connection.QueryFirstOrDefaultAsync<Investments>("getInvestmentsById", new { investmentsId }, commandType: System.Data.CommandType.StoredProcedure);
                return investments;
            }
        }

        public async Task<IEnumerable<Investments>> GetList()
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var investmentsList = await connection.QueryAsync<Investments>("getInvestmentsList", commandType: CommandType.StoredProcedure);
                return investmentsList.ToList();
            }
        }
    }
}
