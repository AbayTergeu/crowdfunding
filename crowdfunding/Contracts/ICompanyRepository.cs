using crowdfunding.Entities;

namespace crowdfunding.Contracts
{
    public interface ICompanyRepository
    {
        public Task<IEnumerable<Company>> GetCompanies();
    }
}
