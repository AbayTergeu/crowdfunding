using crowdfunding.Contracts;
using crowdfunding.Dto;
using crowdfunding.Entities;
using crowdfunding.Helpers.Auth;
using crowdfunding.Services;
using Microsoft.AspNetCore.Mvc;

namespace crowdfunding.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CrownfundingController : ControllerBase
    {
        private readonly ILogger<CrownfundingController> _logger;
        private readonly ICountryRepository _countryRepository;
        private readonly IUserService _userService;
        private readonly IPasswordService _passwordService;

        public CrownfundingController(ILogger<CrownfundingController> logger, ICountryRepository countryRepository, IUserService userService, IPasswordService passwordService)
        {
            _logger = logger;
            _countryRepository = countryRepository;
            _userService = userService;
            _passwordService = passwordService;
        }

        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [Authorize]
        [HttpPost]
        [Route("checkPassword")]
        public IActionResult CheckPassword(string password)
        {
            var response = _passwordService.CompareHash(password, "pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=");

            if (!response)
                return BadRequest(new { message = "password is incorrect" });

            return Ok(response);
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
    }
}