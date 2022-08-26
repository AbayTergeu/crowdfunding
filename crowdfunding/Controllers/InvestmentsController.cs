using crowdfunding.Contracts;
using crowdfunding.Dto;
using crowdfunding.Entities;
using Microsoft.AspNetCore.Mvc;

namespace crowdfunding.Controllers
{
    [ApiController]
    [Route("api/investments")]
    public class InvestmentsController : ControllerBase
    {
        private readonly ILogger<InvestmentsController> _logger;
        private readonly IInvestmentsRepository _investmentsRepository;
        private readonly IAccountRepository _accountRepository;

        public InvestmentsController(ILogger<InvestmentsController> logger, IInvestmentsRepository investmentsRepository, IAccountRepository accountRepository)
        {
            _logger = logger;
            _investmentsRepository = investmentsRepository;
            _accountRepository = accountRepository;
        }

        //[Authorize]
        [HttpGet]
        [Route("getList")]
        public async Task<IEnumerable<Investments>> GetAll()
        {
            var investments = await _investmentsRepository.GetList();
            _logger.LogInformation("investments", investments);
            return investments;
        }

        [HttpPost]
        [Route("add")]
        public async Task<Investments> AddInvestments(InvestmentsDto investmentsDto)
        {
            var investments = await _investmentsRepository.Add(investmentsDto);
            return investments;
        }

        [HttpGet]
        [Route("getAccountByClientId/{clientId}")]
        public async Task<ActionResult<Account>> GetAccountByClientId(int clientId)
        {
            var account = await _accountRepository.GetAccountByClientId(clientId);
            if (account == null)
                return BadRequest(new { message = "Account not found by clientId" });
            return account;
        }
    }
}
