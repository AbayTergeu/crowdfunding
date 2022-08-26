using crowdfunding.Context;
using crowdfunding.Contracts;
using crowdfunding.Entities;
using Dapper;

namespace crowdfunding.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DapperContext _dapperContext;

        public AccountRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<Account> GetAccountByClientId(int inClientId)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Open();
                var result = await connection.QueryFirstOrDefaultAsync<Account>("getAccountByClientId", new { inClientId}, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
