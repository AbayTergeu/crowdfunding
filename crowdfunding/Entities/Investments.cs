namespace crowdfunding.Entities
{
    public class Investments
    {
        public int Id { get; set; }
        public string InvestmentNumber { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DaysCountry { get; set; }
        public int StatusId { get; set; }
        public Decimal InvestmentAmount { get; set; }
        public int CurrencyId { get; set; }
        public int LoanId { get; set; }
        public int InvestorId { get; set; }
        public Decimal InterestRate { get; set; }
    }
}
