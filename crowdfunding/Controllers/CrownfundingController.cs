using crowdfunding.Contracts;
using crowdfunding.Dto;
using crowdfunding.Entities;
using crowdfunding.Helpers.Auth;
using crowdfunding.Services;
using Microsoft.AspNetCore.Mvc;

namespace crowdfunding.Controllers
{
    [ApiController]
    [Route("api/crownfunding")]
    public class CrownfundingController : ControllerBase
    {
        private readonly ILogger<CrownfundingController> _logger;
        private readonly ICountryRepository _countryRepository;
        private readonly IUserService _userService;

        public CrownfundingController(ILogger<CrownfundingController> logger, ICountryRepository countryRepository, IUserService userService)
        {
            _logger = logger;
            _countryRepository = countryRepository;
            _userService = userService;
        }

        [Authorize]
        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [Authorize]
        [HttpGet]
        [Route("getCountries")]
        public async Task<IEnumerable<Country>> GetCountries()
        {
            var countries = await _countryRepository.GetCountries();
            _logger.LogInformation("countries", countries);
            return countries;
        }

        [HttpGet]
        [Route("testApi")]
        public string GetTest()
        {
            return "OK";
        }

        [Authorize]
        [HttpPost]
        [Route("country/create")]
        public async Task<Country> CreateCountry(CountryDto countryDto)
        {
            var country = await _countryRepository.AddCountry(countryDto);
            return country;
        }

        [HttpPost]
        [Route("user/create")]
        public async Task<User> CreateUser(UserDto userDto)
        {
            var user = await _userService.Add(userDto);
            return user;
        }
    }
}