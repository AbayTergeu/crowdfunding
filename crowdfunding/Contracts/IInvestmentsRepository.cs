using crowdfunding.Dto;
using crowdfunding.Entities;

namespace crowdfunding.Contracts
{
    public interface IInvestmentsRepository
    {
        Task<Investments> Add(InvestmentsDto investmentsDto);

        Task<Investments> GetById(int id);

        Task<IEnumerable<Investments>> GetList();


    }
}
