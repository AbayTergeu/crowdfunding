using crowdfunding.Context;
using crowdfunding.Contracts;
using crowdfunding.Dto;
using crowdfunding.Entities;
using Dapper;
using System.Data;

namespace crowdfunding.Repository
{    
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _dapperContext;
        private readonly ICountryRepository _countryRepository;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(DapperContext dapperContext, ICountryRepository countryRepository, ILogger<UserRepository> logger)
        {
            _dapperContext = dapperContext;
            _countryRepository = countryRepository;
            _logger = logger;
        }

        public async Task<User> Add(UserDto userDto)
        {
            if (userDto.CountryId != null)
            {
                Country? country = await _countryRepository.GetById((int)userDto.CountryId);
                if (country == null)
                    throw new ArgumentException("Country not found by id");
            }
            
            var query = "insert into Investor(Name, Surname, InvestorID, email, mobile, login, password, isAcceptedContract, CountryID)" +
                "values (@Name, @Surname, @InvestorID, @Email, @Mobile, @Username , @Password, @isAcceptedContract, @CountryId); SELECT LAST_INSERT_ID();";
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.OpenAsync();
                var trans = connection.BeginTransaction();
                try
                {
                    var id = await connection.ExecuteAsync(query, userDto);
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("error", ex);
                    trans.Rollback();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return await GetByLogin(userDto.Username, userDto.Password);
            }
        }

        public async Task<User> GetById(int userId)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var user = await connection.QueryFirstOrDefaultAsync<User>("getUserById", new { userId}, commandType: System.Data.CommandType.StoredProcedure);
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

        public async Task<User> GetByEmail(string userEmail)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var user = await connection.QueryFirstOrDefaultAsync<User>("getUserByEmail", new { userEmail }, commandType: CommandType.StoredProcedure);
                return user;
            }
        }

        public async Task<User> GetByLogin(string userLogin)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var user = await connection.QueryFirstOrDefaultAsync<User>("getUserByLogin", new { userLogin }, commandType: CommandType.StoredProcedure);
                return user;
            }
        }
    }
}
