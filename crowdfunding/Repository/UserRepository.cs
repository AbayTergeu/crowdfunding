using crowdfunding.Context;
using crowdfunding.Contracts;
using crowdfunding.Dto;
using crowdfunding.Entities;
using crowdfunding.Helpers;
using Dapper;
using System.Data;

namespace crowdfunding.Repository
{    
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _dapperContext;
        private readonly ICountryRepository _countryRepository;

        public UserRepository(DapperContext dapperContext, ICountryRepository countryRepository) {
            _dapperContext = dapperContext;
            _countryRepository = countryRepository;
        }

        public async Task<User> Add(UserDto userDto)
        {
            Country? country = await _countryRepository.GetById(userDto.CountryId);
            if (country == null)
                throw new ArgumentException("Country not found by id");
            
            var query = "insert into Investor(Name, Surname, InvestorID, email, mobile, login, password, isAcceptedContract, CountryID)" +
                "values (@Name, @Surname, @InvestorID, @Email, @Mobile, @Login, @Password, @isAcceptedContract, @CountryId); SELECT LAST_INSERT_ID();";
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.OpenAsync();
                var id = await connection.ExecuteAsync(query, userDto);
                return await GetByLogin(userDto.Login, userDto.Password);
            }
        }

        public async Task<User> GetById(int userId)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var user = await connection.QueryFirstOrDefaultAsync<User>("getInvestorById", new { userId}, commandType: System.Data.CommandType.StoredProcedure);
                return user;
            }
        }

        public async Task<User> GetUserByLoginOrMobile(string userLogin, string userMobile)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var user = await connection.QueryFirstOrDefaultAsync<User>("getUserByLoginOrMobile", new { userLogin, userMobile}, commandType: CommandType.StoredProcedure);
                return user;
            }
        }

        public async Task<User> GetByLogin(string userLogin, string userPassword)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var user = await connection.QueryFirstOrDefaultAsync<User>("getUserByLoginAndPassword", new { userLogin, userPassword}, commandType: CommandType.StoredProcedure);
                return user;
            }
        }

        public async Task<IEnumerable<User>> GetList()
        {
            var query = "select * from Investor";
            using (var connection = _dapperContext.CreateConnection())
            {
                var userList = await connection.QueryAsync<User>(query);
                return userList;
            }
        }
    }
}
