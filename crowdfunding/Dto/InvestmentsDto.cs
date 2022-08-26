namespace crowdfunding.Dto
{
    public class InvestmentsDto
    {
        public string InInvestmentNumber { get; set; }
        public DateTime InCreateDate { get; set; } = DateTime.Now;
        public DateTime InStartDate { get; set; }
        public DateTime? InEndDate { get; set; }
        public int InDaysCountry { get; set; }
        public int InStatusId { get; set; } = 1;
        public Decimal InInvestmentAmount { get; set; }
        public int InCurrencyId { get; set; }
        public int InLoanId { get; set; }
        public int InUserId { get; set; }
        public Decimal InInterestRate { get; set; }
    }
}
