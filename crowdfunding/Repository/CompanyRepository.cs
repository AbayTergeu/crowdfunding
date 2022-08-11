
using crowdfunding.Context;
using crowdfunding.Contracts;
using crowdfunding.Entities;
using Dapper;

namespace crowdfunding.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DapperContext _dapperContext;

        public CompanyRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            var query = "select Id, Name, Address, Country from Companies";
            using (var connection = _dapperContext.CreateConnection())
            {
                var companies = await connection.QueryAsync<Company>(query);
                return companies.ToList();
            }
        }
    }
}
